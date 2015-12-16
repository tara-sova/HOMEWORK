open System.Collections.Generic

let e = 2.7182818284
let f x = (1.0 / (1.3 - e ** (- x)))
let d2F x = 0.591716 * (e ** x) * (0.769231 + (e ** x)) / (((e ** x) - 0.769231) ** 3.0)
let d4F x = (e ** x) * (0.269329 + 3.85141 * (e ** x) + 5.00683 * (e ** (2.0 * x)) + 0.591716 * (e ** (3.0 * x))) / (((e ** x) - 0.769231) ** 5.0) 
let interval = (0.0, 0.4)

let rec maximum f interval t (maxFunc : float) = 
    if t >= 1.0 - 0.0001 then maxFunc
    else
        let x = ((1.0 - t) * (fst interval)) + (t * (snd interval))
        let rrr = f x
        if abs(f x) > maxFunc then 
           maximum f interval (t + 0.001) (abs(f x))
        else maximum f interval (t + 0.001) maxFunc

let middleRectangle (a, b) f d2F n = 
    let h = (b - a) / n
    let mutable sum = 0.0
    for i = 1 to int(n) do
        let x = a + ((2.0 * float(i)) - 1.0) * h / 2.0
        sum <- sum + f(x)
    let sum = h * sum
    let max = maximum d2F (a, b) 0.0 (-1.0)
    let r = ((b - a) ** 3.0) * max / (24.0 * n * n) 
    (sum, r)

let trapeze (a, b) f d2F n = 
    let h = (b - a) / n
    let mutable sum = 0.0
    for i = 1 to (int(n) - 1) do
        let x = a + float(i) * h
        sum <- sum + f x
    let sum = h * (((f a + f b) / 2.0) + sum)
    let max = maximum d2F (a, b) 0.0 (-1.0)
    let r = ((b - a) ** 3.0) * max / (12.0 * n * n) // without minus
    (sum, r)

let Simpson (a, b) f d4F n = 
    let h = (b - a) / n
    let mutable sum1 = 0.0
    let mutable sum2 = 0.0
    for i = 1 to (int(n) - 1) do
        let x1 = a + float(i) * h
        sum1 <- sum1 + f x1
        let x2 = a + (2.0 * float(i) - 1.0) * h / 2.0
        sum2 <- sum2 + f x2
    let max = maximum d4F (a, b) 0.0 (-1.0)
    let sum1 = (f a + f b + 2.0 * sum1 + 4.0 * (sum2 + f(a + (2.0 * n - 1.0) * h / 2.0))) * h / 6.0
    let r = ((b - a) ** 5.0) * max / (2880.0 * n * n) // the same
    (sum1, r)

let JR Jn (Jn2 : float) k =
    (Jn - (2.0 ** k) * Jn2) / (1.0 - (2.0 ** k))

let main =
    let mR1 = middleRectangle interval f d2F 8.0
    let t1 = trapeze interval f d2F 8.0
    let s1 = Simpson interval f d4F 8.0
    let mR2 = middleRectangle interval f d2F 16.0
    let t2 = trapeze interval f d2F 16.0
    let s2 = Simpson interval f d4F 16.0

    let JR_mR = JR (fst mR1) (fst mR2) 2.0
    let JR_t = JR (fst t1) (fst t2) 2.0
    let JR_s = JR (fst s1) (fst s2) 4.0

    printfn "Middle rectangle\nn = 8   %A\nevaluation of r  %A\nn = 16   %A\nevaluation of r  %A\nJR  %A\n" (fst mR1) (snd mR1) (fst mR2) (snd mR2) JR_mR
    printfn "Trapeze method\nn = 8   %A\nevaluation of r  %A\nn = 16   %A\nevaluation of r  %A\nJR  %A\n" (fst t1) (snd t1) (fst t2) (snd t2) JR_t
    printfn "Simpson's method\nn = 8   %A\nevaluation of r  %A\nn = 16   %A\nevaluation of r  %A\nJR  %A\n" (fst s1) (snd s1) (fst s2) (snd s2) JR_s