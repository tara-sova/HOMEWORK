let isEven (n : int) = 
    if (n % 2 = 0) then n
    else 0

let rec fib n =
    if n <= 1
    then 1
    else fib(n - 1) + fib(n - 2)    

let rec sum (list : int list) (count : int) = 
    if (fib(count) <= 1000000) then
       let listWithAdd = (isEven(fib (count))) :: list
       sum listWithAdd (count + 1)
    else
        list

let act = 
    let list = sum [] 0
    let result = List.sum list
    result