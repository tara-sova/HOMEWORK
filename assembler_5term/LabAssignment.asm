; -------------------------------------------------------------------------------------	;
;	������������ ������ �1 �� ����� ���������������� �� ����� ����������				;
;	������� �2.3																		;
;	�������� ������� �������� ������																;
;																						;
;	�������� ������ LabAssignment.asm													;
;	�������� ������� �� ����� ����������, ������������� � ������������ � ��������		;
; -------------------------------------------------------------------------------------	;
;	�������: 
;		����������� ������ ��������� �����������

.DATA
pixel dword ?

.CODE
; -------------------------------------------------------------------------------------	;
; ������������ ���������� ����� �������� ������������ �����������						;
; void Kernel_asm( PBYTE pDst, PBYTE pSrc, int Width )									;
; ���������:																			;
;	pDst   - ����� ������� - ���������� ���������										;
;   pSrc   - ����� ������� ��������� �����������											;
;	Width  - ������ ����������� � �������� (���������� ��������)							;
; ��������!!! ��� ���������� ������ ���������� ���������� ���������� ��������� � �����	;
;	Tuning.h � ������������ � ��������													;
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

	finit

; ������� G_x. ���������� a11, a21, a31. ����� ���������� a13, a23, a33. � �� ������ ����� �������� ������.
	movzx eax, byte ptr[rdx]				; �������� ����� ������� �� ������ [rdx] � ����������� ������ �� 8 ���� ; a11
	mov pixel, eax							; �������� ������� � rax
	fild pixel								; st(0) = a11

	movzx eax, byte ptr[rdx + r8]			; a21
	mov pixel, eax
	fiadd pixel								; st(0) = a11 + a21

	movzx eax, byte ptr[rdx + 2 * r8]		; a31
	mov pixel, eax
	fiadd pixel								; st(0) = a11 + a21 + a31

	movzx eax, byte ptr[rdx + 2]			; a31
	mov pixel, eax
	fild pixel								; st(0) = a31    st(1) = a11 + a21 + a31

	movzx eax, byte ptr[rdx + r8 + 2]		; a32
	mov pixel, eax
	fiadd pixel								; st(0) = a31 + a32    st(1) = a11 + a21 + a31

	movzx eax, byte ptr[rdx + 2 * r8 + 2]	; a33
	mov pixel, eax
	fiadd pixel								; st(0) = a31 + a32 + a33    st(1) = a11 + a21 + a31
	
	fxch st(1)								; st(0) = a11 + a21 + a31    st(1) = a31 + a32 + a33
	fsubp									; st(0) =  st(1) - st(0) = x
	fmul st(0), st(0)						; �������� � �������: st(0) = x * x = X



; G_y. ������� ���������� a11, a12, a13. ����� ���������� a31, a32, a33. �������� �� ������ ����� ������.
	movzx eax, byte ptr[rdx]				; a11		
	mov pixel, eax
	fild pixel								; st(0) = a11    st(1) = X

	movzx eax, byte ptr[rdx + 1]			; a12
	mov pixel, eax
	fiadd pixel								; st(0) = a11 + a12    st(1) = X

	movzx eax, byte ptr[rdx + 2]			; a13
	mov pixel, eax
	fiadd pixel								; st(0) = a11 + a12 + a13    st(1) = X

	movzx eax, byte ptr[rdx + 2 * r8]		; a31
	mov pixel, eax
	fild pixel								; st(0) = a31    st(1) = a11 + a12 + a13    st(2) = X

	movzx eax, byte ptr[rdx + 2 * r8 + 1]	; a32
	mov pixel, eax
	fiadd pixel								; st(0) = a31 + a32    st(1) = a11 + a12 + a13    st(2) = X

	movzx eax, byte ptr[rdx + 2 * r8 + 2]	; a33
	mov pixel, eax
	fiadd pixel								; st(0) = a31 + a32 + a33    st(1) = a11 + a12 + a13    st(2) = X
	
	fxch st(1)								; st(0) = a11 + a12 + a13    st(1) = a31 + a32 + a33    st(2) = X
	fsubp									; st(0) = st(1) - st(0) = y    st(1) = X
	fmul st(0), st(0)						; st(0) = y * y = Y    st(1) = X

; ������� G:
	faddp 									; st(0) = X + Y  
	fsqrt									; st(0) = sqrt(X + Y)

	fist pixel
	mov		eax, pixel						; ����������� r9 � rax
	mov		r10d, 255						; ���� ��������� 
	cmp		eax, r10d						;     ������ 255,
	cmovg	eax, r10d						;        �� ���������� 255
	
	mov		byte ptr [rcx], al				; ���������

	ret
Kernel ENDP
END
