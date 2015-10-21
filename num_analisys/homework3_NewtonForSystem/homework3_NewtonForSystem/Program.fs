open System.Collections.Generic

let eps = 0.00001
let e = 2.71828
let ch (x : float) = ((e ** x) + (e ** -x)) / 2.0
let sh (x : float) = ((e ** x) - (e ** -x)) / 2.0

let fs k x y = (ch(k * (x ** 2.0) + y) - x + y - 1.0) * k / k 
let gs a x y = (((x - 0.1) ** 2.0 / a ** 2.0) - (y ** 2.0) / 2.0 - 0.8) * a / a 

let dFs_x k x y = (2.0 * k * sh(k * ((x ** 2.0) + y)) - 1.0) * k / k
let dFs_y k x y = (sh(k * (x ** 2.0)) + 1.0) * y / y * k / k

let dGs_x a x y = (2.0 * x - 0.2 + y - y) / (a ** 2.0)
let dGs_y a x y = x - x - y + a - a

let delta_x f g dF_y dG_y x y = - (f x y) * (dG_y x y) + (dF_y x y) * (g x y)
let delta_y f g dF_x dG_x x y = - (g x y) * (dF_x x y) + (f x y) * (dG_x x y)
let delta dF_x dF_y dG_x dG_y x y = (dF_x x y) * (dG_y x y) - (dG_x x y) * (dF_y x y) 

let aList = [0.7; 0.8; 0.9; 1.0; 1.1; 1.2]
let kList = [0.1; 0.2; 0.3; 0.4; 0.5]

let find_primary_approx f g = 
    let rec outFunc x_i y_i = 
        let rec inFunc x_i y_i = 
            if y_i > 2.01 - 0.0001 then (-100500.0, -100500.0)
            else 
                let resF = f x_i y_i
                let resG = g x_i y_i
                if abs(resF) < 0.1 && abs(resG) < 0.1 then (x_i, y_i) 
                else inFunc x_i (y_i + 0.01)
        let dot = inFunc x_i y_i
        match dot with
        | (-100500.0, -100500.0) -> 
                                    if x_i < 2.01 - 0.0001 then outFunc (x_i + 0.01) y_i 
                                    else (-100500.0, -100500.0)
        | (_, _) -> dot
    outFunc 0.0 0.0                     

let rec newton x_0 y_0 f g dF_x dF_y dG_x dG_y (step : int) = 
    System.Console.WriteLine("{0}    {1}    {2}    {3}    {4}", step, x_0, y_0, f x_0 y_0, g x_0 y_0)
    let x_k = x_0 + (delta_x f g dF_y dG_y x_0 y_0) / (delta dF_x dF_y dG_x dG_y x_0 y_0)
    let y_k = y_0 + (delta_y f g dF_x dG_x x_0 y_0) / (delta dF_x dF_y dG_x dG_y x_0 y_0)
    if abs(x_k - x_0) <= eps && abs(y_k - y_0) <= eps then
       System.Console.WriteLine("{0}    {1}    {2}    {3}    {4}", step, x_k, y_k, f x_k y_k, g x_k y_k)
    else
        newton x_k y_k f g dF_x dF_y dG_x dG_y (step + 1)



let mainFunc = //(f : float -> float -> float -> float) (g : float -> float -> float -> float) (kList : float list) (aList : float list) = 
    //let mutable first_approx = (0.0, 0.0)
    let mutable counter = 0
    for i = 0 to (kList.Length - 1) do
        for j = 0 to aList.Length - 1 do 
            let f_with_k = fs kList.[i]
            let g_with_a = gs aList.[j]
            let first_approx = find_primary_approx f_with_k g_with_a
            System.Console.WriteLine("step x_k    y_k    f    g")
            let dF_x_with_k = dFs_x kList.[i]
            let dF_y_with_k = dFs_y kList.[i]
            let dG_x_with_a = dGs_x aList.[j]
            let dG_y_with_a = dGs_y aList.[j]
            let newtonRes = newton (fst first_approx) (snd first_approx) f_with_k g_with_a dF_x_with_k dF_y_with_k dG_x_with_a dG_y_with_a 0
            System.Console.WriteLine("\n\n\n")
    System.Console.WriteLine("Stop")




//let fk = fs kList.[0]
//let ccch = ch(0.0)
//let fkk = fk 0.0 
//let fkkk = fkk 0.0
//fkk

//let a = gs 0.1 0.0 0.0
//a

//let r x y z = x + y + z
//let ff (f : float -> float -> float -> float) (k : float) = 
//    let d = fun (f : float -> float -> float -> float) (x : float) (y : float) (z : float) -> f x y (k : float)
//    d
//let t x y = ff r 1.0
//let h = fun t o p -> t 2.0 3.0
//h
//
//let c y = cos(y)
//let (d : float -> float -> float) = fun c -> c(0.0)
//d
//
//let test (x : int) (y : int) = x + y
//let test2 (test : int -> int) = 
//    let a = fun 2 -> test 2
//    a
//
//let add a b = a + b //'a -> 'a -> 'a
//let addOne = add 1 //'a -> 'a
//let x = addOne 10 // 11

//////////////////////////////////////////////////let c x y z = (z + x + y*x) * x / x * y / y * z / z 
//////////////////////////////////////////////////let res11 =  c 3.0//x3 y1 z4
//////////////////////////////////////////////////let res = res11 1.0 4.0
//let resPlus = c 0.0
//let res = resPlus 1.0
//////////////////////////////////////////////////res


