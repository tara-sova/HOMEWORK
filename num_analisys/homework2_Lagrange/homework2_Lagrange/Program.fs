open System.Collections.Generic

let Pi = 3.14159265

let c x = cos(x)
let dC x = cos(x)

let c10 x = cos(10.0 * x)
let dC10_6 x = -1000000.0 * cos(10.0 *x)
let dC10_12 x = 1000000000000.0 * cos(10.0 * x)

let rec factorial n = 
    if n = 1 then 1
    else n * factorial (n - 1)

let LagrangePolinom (list : List<float * float>) (x : float) = 
    let mutable mainRes = 0.0
    let mutable result = 1.0
    for i = 0 to list.Count - 1 do
        for j = 0 to list.Count - 1 do
            if (i <> j) then 
                result <- result * ((x - (fst list.[j])) / ((fst list.[i]) - (fst list.[j])))
            else result <- result + 0.0
        mainRes <- mainRes + (result * (snd list.[i]))
        result <- 1.0
    mainRes

let rec maximumMod f interval t (maxFunc : float) = 
    if t >= 1.0 - 0.0001 then maxFunc
    else
        let x = ((1.0 - t) * (fst interval)) + (t * (snd interval))
        let rrr = f x
        if abs(f x) > maxFunc then 
           maximumMod f interval (t + 0.001) (abs(f x))
        else maximumMod f interval (t + 0.001) maxFunc

let findA_i (f : float -> float) (dF : float -> float) (listOfPair : List<float * float>) interval x_i = 
    let n = listOfPair.Count
    let mutable w = 1.0
    for i = 0 to (n - 1) do
        let diff = x_i - (fst listOfPair.[i])
        w <- w * (x_i - (fst listOfPair.[i]))
    let maxOfMod = maximumMod dF interval 0.0 -100.0
    let A_i = ( abs w / float(factorial n)) * maxOfMod
    A_i

let action (f : float -> float) dF (interval : float * float) (nodes : float list) = 
    let n = 20.0
    let list = new List<float * float>()
    System.Console.WriteLine("x_i         L(x_i)         f(x_i)         |L - f|         A_i")
    for j = 0 to nodes.Length - 1 do
        list.Insert(j, (nodes.[j], f (nodes.[j])))
    for i = 0 to 20 do
        let x_i = fst interval + ((snd interval - fst interval) / n) * (float i)
        let Lagrange_x_i = LagrangePolinom list x_i 
        let difference = abs (Lagrange_x_i - f x_i)
        let A_i = findA_i f dF list interval x_i
        System.Console.WriteLine("{0}         {1}         {2}         {3}          {4}"
                                 , System.Math.Round(x_i, 5), System.Math.Round(Lagrange_x_i, 5)
                                 , System.Math.Round(f x_i, 5), System.Math.Round(difference, 5)
                                 , System.Math.Round(A_i, 5) )

let changeTable condition (list : float list) (interval : float * float)= 
    if condition = 0 then 
       System.Console.WriteLine ("\n\ntable for double number of nodes")
       list @ List.map (fun x -> x / 2.001) list
    elif condition = 1 then 
         System.Console.WriteLine ("\n\ntable for right part of interval")
         List.map (fun x -> 
                            if x >= 0.0 then snd interval - (x / 2.0)
                            else snd interval + (x / 2.0)
                            ) list
    elif condition = 2 then
         System.Console.WriteLine ("\n\ntable for left part of interval")
         List.map (fun x -> 
                            if x >= 0.0 then fst interval + (x / 2.0)
                            else fst interval - (x / 2.0)
                            ) list
    else
        System.Console.WriteLine ("\n\ntable for middle part of interval")
        List.map (fun x -> x / 2.0) list

let mainFunc = 
    let fList = [Pi/6.0; Pi/4.0; Pi/3.0; Pi/2.0]
    let fInterval = (0.0, Pi/2.0)
    System.Console.WriteLine("f = cos(x) \nsimple table")
    action c dC fInterval fList
    for i = 0 to 2 do
        action c dC fInterval (changeTable i fList fInterval)

    let gList = [-0.87; -0.69; -0.11; 0.31; 0.58; 0.97]
    let gInterval = (-1.0, 1.0)
    System.Console.WriteLine("\n\ng = cos(10 * x) \nsimple table")
    action c10 dC10_6 gInterval gList
    for i = 0 to 3 do
        if i = 0 then action c10 dC10_12 gInterval (changeTable i gList gInterval)
        else action c10 dC10_6 gInterval (changeTable i gList gInterval)
 







/// test of Lagrange
//let l1 (nodes : float list) f = 
//    let list = new List<float * float>()
//    for j = 0 to 4 do
//        list.Insert(j, (nodes.[j], f (nodes.[j])))
//    LagrangePolinom list 1.0 t
//
//let ll = l1 [-1.5; -0.75; 0.0; 0.75; 1.5] t
//////ll
////let r = action t dT (-2.0, 2.0) [-1.5; -0.75; 0.0; 0.75; 1.5]
////r



///// test of Lagrange Galya 
//let l1 (nodes : float list) f = 
//    let list = new List<float * float>()
//    for j = 0 to 4 do
//        list.Insert(j, (nodes.[j], f (nodes.[j])))
//    LagrangePolinom list 1.0 
//
//let ll = l1 [-1.5 * Pi; -Pi; -Pi / 2.0; 0.0; Pi; 1.5 * Pi] c
//ll
////let r = action t dT (-2.0, 2.0) [-1.5; -0.75; 0.0; 0.75; 1.5]
////r




//let res1 = action t dT (-2.0, 2.0) [-1.5; -0.75; 0.0; 0.75; 1.5]
//res1
//let res = maximumMod s (0.0, Pi/4.0) 0.0 -100.0