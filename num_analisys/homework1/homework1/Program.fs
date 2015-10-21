open System.Collections.Generic


let rec factorial n res = 
    if n = 1.0 then res
    else factorial (n - 1.0) (res * n)

let p1 x = 
    128.0 * (pown x 8) - 256.0 * (pown x 6) + 160.0 * (pown x 4) - 32.0 * (pown x 2) + 1.0

let dP1 x = 
    1024.0 * (pown x 7) - 1536.0 * (pown x 5) + 640.0 * (pown x 3) - 64.0 * x

let p2 x = 
    (pown x 3) + 2.0 * (pown x 2) - 1.75 * x - 1.25

let dP2 x = 
    3.0 * (pown x 2) + 4.0 * x - 1.75

let p3 x = //(pown x 3) + 4.0 * sin(x)
    (pown x 3) + 4.0 * (x - ((pown x 3) / (factorial 3.0 1.0)) + ((pown x 5) / (factorial 5.0 1.0)))

let dP3 x = 
    3.0 * (pown x 2) + 4.0 * (1.0 - ((pown x 2) / (factorial 2.0 1.0)) + ((pown x 4) / factorial 4.0 1.0))
 
let p x = x * x + x
let dP x = 2.0 * x + 1.0

let rec solve (f : float -> float) (dF : float -> float) (x_0 : float) (counter : int) = 
    let eps : float = 0.0000001 //0.001 //0.00001
    let px = f x_0
    let dPx = dF x_0
    let x_k = x_0 - (px / dPx)
    let difference = x_k - x_0
    if abs difference > eps then 
       System.Console.WriteLine("{0}    {1}    {2}", counter, x_0, px)
       solve f dF x_k (counter + 1)
    else 
        [float(counter); x_0; px]
    

let act (interval : float * float) (f : float -> float) (dF : float -> float) =
    let rank = (snd interval - fst interval) / 100.0
    let list = new List<float>()
    list.Insert(0, fst interval)
    System.Console.WriteLine("k     x_k    P(x_k)")
    for i = 0 to 99 do
        if (f list.[i]) * (f (list.[i] + rank)) < 0.0 then
           System.Console.WriteLine("\n                                     x_0 = {0}", list.[i])
           let resList = solve f dF list.[i] 0
           System.Console.WriteLine("{0}    {1}   {2}\n\n", int32(resList.Head), resList.Tail.Head, resList.Tail.Tail.Head)
        list.Insert(i + 1, list.[i] + rank)

let mainFunc = 
    System.Console.WriteLine("function = 128.0 * (x ^ 8) - 256.0 * (x ^ 6) + 160.0 * (x ^ 4) - 32.0 * (x ^ 2) + 1.0
                              \ninterval = (0.058, 2.122)")
    act (0.058, 2.122) p1 dP1
    System.Console.WriteLine("\ninterval = (-2.122, -0.058)")
    act (-2.122, -0.058) p1 dP1

    System.Console.WriteLine("function = (x ^ 3) + 2.0 * (x ^ 2) - 1.75 * x - 1.25
                              \ninterval = (0.44, 2.3)")
    act (0.44, 2.3) p2 dP2
    System.Console.WriteLine("\ninterval = (-3.0, -0.38)")
    act (-3.0, -0.38) p2 dP2

    System.Console.WriteLine("function = (x ^ 3) + 4.0 * sin(x)
                              \ninterval = (-1.0, 1.0)")
    act (-1.0, 1.0) p3 dP3
