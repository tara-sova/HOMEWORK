; -------------------------------------------------------------------------------------	;
;	Лабораторная работа №1 по курсу Программирование на языке ассемблера				;
;	Вариант №2.8																		;
;	Выполнил студент Тарасова Полина																;
;																						;
;	Исходный модуль LabAssignment.asm													;
;	Содержит функцию на языке ассемблера, разработанную в соответствии с заданием		;
; -------------------------------------------------------------------------------------	;
;	Задание: 
;		Реализовать фильтр обработки изображений

.CODE
; -------------------------------------------------------------------------------------	;
; Осуществляет фильтрацию одной цветовой составляющей изображения						;
; void Kernel_asm( PBYTE pDst, PBYTE pSrc, int Width )									;
; Параметры:																			;
;	pDst   - адрес пиксела - результата обработки										;
;   pSrc   - адрес пиксела исходного изображения											;
;	Width  - ширина изображения в пикселах (количество столбцов)							;
; Внимание!!! Для корректной работы приложения необходимо определить константы в файле	;
;	Tuning.h в соответствии с заданием													;
; -------------------------------------------------------------------------------------	;
Kernel PROC	; [RCX] - pDst
			; [RDX] - pSrc
			; R8    - Width

; --------------------------------------------------------------------------------------------------;
;   
;       m11 m12 m13   -1  0  1			  g11 g12 g13   -1 -1 -1
; G_x = m21 m22 m23 = -1  0  1		G_y = g21 g22 g23 =  0  0  0	G = sqrt( (G_x) ^ 2 + (G_y) ^ 2 )
;	    m31 m32 m33   -1  0  1			  g31 g32 g33    1  1  1
;
;     a11 a12 a13		b11 b12 b13		 
; A = a21 a22 a23	B = b21 b22 b23       
;     a31 a32 a33		b31 b32 b33
;    
;     b22 =   a11 * m11 + a12 * m12 + a13 * m13 +
;			+ a21 * m21 + a22 * m22 + a23 * m23 +
;			+ a31 * m31 + a32 * m32 + a33 * m33
; --------------------------------------------------------------------------------------------------;
	xor rax, rax									; Обнуление решистров rax и rbx
	xor rbx, rbx									; для последующего использования

													; Обнуление регистров для:
	vpxor ymm0, ymm0, ymm0							; -- будем использовать при обработке результата
	vpxor ymm1, ymm1, ymm1							; -- будем использовать для выгрузки данных из памяти
	vpxor ymm2, ymm2, ymm2							; -- элементы А, которые после применения G_x больше 0
	vpxor ymm3, ymm3, ymm3							; -- элементы А, которые после применения G_y больше 0
	vpxor ymm4, ymm4, ymm4							; -- элементы А, которые после применения G_x меньше 0
	vpxor ymm5, ymm5, ymm5							; -- элементы А, которые после применения G_y меньше 0

	vpmovzxbw xmm1, qword ptr[rdx]					; Загрузка данных по адресу [rdx] с расширением нулями ; a11
	vpmovzxwd ymm1, xmm1							; Загрузка результата в ymm1 с расширением нулями
	vcvtdq2ps ymm1, ymm1							; dword -> float
	vaddps ymm4, ymm4, ymm1							; a11 G_x(-)
	vaddps ymm5, ymm5, ymm1							; a11 G_y(-)

	vpmovzxbw xmm1, qword ptr[rdx + r8]				; a21
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm4, ymm4, ymm1							; a21 G_x(-)

	vpmovzxbw xmm1, qword ptr[rdx + 2 * r8]			; a22
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm4, ymm4, ymm1							; a31 G_x(-)
	vaddps ymm3, ymm3, ymm1							; a31 G_y(+)

	vpmovzxbw xmm1, qword ptr[rdx + 2]				; a13
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm2, ymm2, ymm1							; a13 G_x(+)
	vaddps ymm5, ymm5, ymm1							; a31 G_y(-)

	vpmovzxbw xmm1, qword ptr[rdx + r8 + 2]			; a23
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm2, ymm2, ymm1							; a23 G_x(+)

	vpmovzxbw xmm1, qword ptr[rdx + 2 * r8 + 2]		; a33
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm2, ymm2, ymm1							; a33 G_x(+)
	vaddps ymm3, ymm3, ymm1							; a33 G_y(+)

	vpmovzxbw xmm1, qword ptr[rdx + 1]				; a12
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm5, ymm5, ymm1							; a12 G_y(-)

	vpmovzxbw xmm1, qword ptr[rdx + 2 * r8 + 1]		; a32
	vpmovzxwd ymm1, xmm1
	vcvtdq2ps ymm1, ymm1
	vaddps ymm3, ymm3, ymm1							; a32 G_y(+)

	vsubps ymm2, ymm2, ymm4							; G_x = G_x(+) - G_x(-)
	vsubps ymm3, ymm3, ymm5							; G_y = G_y(+) - G_y(-)

	vmulps ymm2, ymm2, ymm2							; (G_x) ^ 2
	vmulps ymm3, ymm3, ymm3							; (G_y) ^ 2

	vaddps ymm2, ymm2, ymm3							; ((G_x) ^ 2 + (G_y) ^ 2)
	vsqrtps ymm2, ymm2								; G = sqrt( (G_x) ^ 2 + (G_y) ^ 2 )
	vcvtps2dq ymm1, ymm2							; float -> dword
	
		
	vpackssdw xmm2, xmm1, xmm1						; Конвертируем в 
	vpackuswb xmm3, xmm2, xmm2						;				 нужный вид 
	vmovq rax, xmm3									; Сохраняем результат в rax

	vperm2i128 ymm0, ymm1, ymm1, 1					; Перемещаем в ymm0 старшие биты ymm1
	vpackssdw xmm2, xmm0, xmm0						; Упаковка с насыщением в xmm2
	vpackuswb xmm3, xmm2, xmm2						; Упаковка в байты
	vmovq rbx, xmm3									; Сохраняем в rbx

	mov dword ptr [rcx], eax						; Возвращаем
	mov dword ptr [rcx + 4], ebx					;			 результат
	ret
Kernel ENDP
END
