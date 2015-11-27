open System.Collections.Generic

let h = 0.1

let pBeginning i t (y_0 : float) (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) = 
    //printfn("----------beginning meaning %A  %A  %A  %A %A") y_0 delta.[i] delta2.[i] delta3.[i] delta4.[i]
    y_0 + t * delta.[i] + t * (t - 1.0) * delta2.[i] / 2.0 + t * (t - 1.0) * (t - 2.0) * delta3.[i] / 6.0 + t * (t - 1.0) * (t - 2.0) * (t - 3.0) * delta4.[i] / 24.0

let pEnding i t (yList : float list) (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) = 
    let y_n = yList.[i]
    if (i - 4 >= 0) then
       //printfn("----------ending meaning(5)    %A  %A  %A  %A %A") y_n delta.[i - 1] delta2.[i - 2] delta3.[i - 3] delta.[i - 4]
       y_n + ( t * delta.[i - 1]) + t * (t + 1.0) * delta2.[i - 2] / 2.0  + t * (t + 1.0) * (t + 2.0) * delta3.[i - 3] / 6.0 + t * (t + 1.0) * (t + 2.0) * (t + 3.0) * delta4.[i - 4] / 24.0
    else 
        //printfn("----------ending meaning(4)    %A  %A  %A  %A") y_n delta.[i - 1] delta2.[i - 2] delta3.[i - 3] 
        y_n + ( t * delta.[i - 1]) + t * (t + 1.0) * delta2.[i - 2] / 2.0  + t * (t + 1.0) * (t + 2.0) * delta3.[i - 3] / 6.0

let pMiddle index t (yList : float list) (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) = 
    let y_0 = yList.[index]
    let y_1 = yList.[index - 1]
    let y_2 = yList.[index - 2]
    //printfn("----------middle meaning       %A  %A  %A  %A %A") y_0 delta.[index] delta2.[index - 1] delta3.[index - 1] delta4.[index - 2]
    y_0 + t * delta.[index] + t * (t - 1.0) * delta2.[index - 1] / 2.0 + t * (t - 1.0) * (t + 1.0) * delta3.[index - 1] / 6.0 + t * (t - 1.0) * (t + 1.0) * (t - 2.0) * delta4.[index - 2] / 24.0

let createD list = 
    let newList = new List<float>()
    for i = 0 to (List.length list - 2) do
        let element = list.[i + 1] - list.[i]
        newList.Insert(i, element)
    Array.toList(newList.ToArray())

let print (list : (float * float) list) (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) =
    printfn "x      y      delta    delta2    delta3    delta4"
    for k = 0 to list.Length - 1 do
        if k < delta4.Length then 
           printfn "%A  %A  %A  %A  %A  %A" (fst list.[k]) (snd list.[k]) delta.[k] delta2.[k] delta3.[k] delta4.[k]
        elif (k < delta3.Length) then
           printfn "%A  %A  %A  %A  %A" (fst list.[k]) (snd list.[k]) delta.[k] delta2.[k] delta3.[k]
        elif (k < delta2.Length) then
           printfn "%A  %A  %A  %A" (fst list.[k]) (snd list.[k]) delta.[k] delta2.[k]
        elif (k < delta.Length) then
           printfn "%A  %A  %A" (fst list.[k]) (snd list.[k]) delta.[k]
        else
           printfn "%A  %A" (fst list.[k]) (snd list.[k])

let findP i (list : (float * float) list) xx x_0 (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) place = 
    let t = (xx - x_0) / h
    let yList = List.map(fun x -> (snd x)) list

    if place = 0 then 
       let res = pBeginning i t (snd list.[i]) delta delta2 delta3 delta4
       printfn "beginning    %A    %A    %A" xx t res
    else if place = 1 then 
        let res = pEnding i t yList delta delta2 delta3 delta4
        printfn "ending       %A    %A    %A" xx t res
    else 
        let res = pMiddle i t yList delta delta2 delta3 delta4
        printfn "middle       %A    %A    %A" xx t res

let rec revInter (tList : float list) (list : (float * float) list) yy i (delta : float list) (delta2 : float list) (delta3 : float list) (delta4 : float list) = 
    let t = tList.Head
    let count = tList.Length - 1
    let x_0 = fst list.[i]
    let y_0 = snd list.[i]
    let t1 = (1.0 / delta.[i]) * (yy - y_0 - (t * (t - 1.0)) * delta2.[i - 1] / 2.0 - (t * (t - 1.0) * (t + 1.0)) * delta3.[i - 1] / 6.0 - (t * (t - 1.0) * (t + 1.0)) * delta4.[i - 2] / 24.0)
    let newList = t1 :: tList
    if (abs(t1 - t) < 0.0000001) then 
        printfn " %A      %A         %A            %A" count t t1 (t1 - t)
        let xx = t1 * h + (fst list.[i])
        printfn "\nt* = %A  x* = %A" t1 xx
    else 
        printfn " %A      %A         %A            %A" count t t1 (t1 - t)
        revInter newList list yy i delta delta2 delta3 delta4


let main (list : (float * float) list) (xxList : float list) yy = 
    let yList = List.map(fun x -> (snd x)) list
    let delta = createD yList
    let delta2 = createD delta
    let delta3 = createD delta2
    let delta4 = createD delta3
    print list delta delta2 delta3 delta4

    printfn "\ntableType    x_i*        t         P(x_i*)"
    findP 1 list xxList.Head (fst list.Tail.Head) delta delta2 delta3 delta4 0

    findP (list.Length - 1) list xxList.Tail.Head (fst list.[list.Length - 1]) delta delta2 delta3 delta4 1

    printfn "           three tables for x_3*"
    let index = List.findIndex((=) (fst list.[2])) (List.map(fun x -> (fst x)) list)
    findP index list xxList.[2] (fst list.[2]) delta delta2 delta3 delta4 0

    let endIndex = List.findIndex((=) (fst list.[3])) (List.map(fun x -> (fst x)) list)
    findP endIndex list xxList.[2] (fst list.[3]) delta delta2 delta3 delta4 1

    findP index list xxList.[2] (fst list.[2]) delta delta2 delta3 delta4 2

    printfn "\n\ncount  t_k         t_(k + 1)        (t_k - t_(k + 1))"
    revInter [0.0] list yy 3 delta delta2 delta3 delta4

let dataList = [(0.0, 1.623250); (0.1, 1.664792); (0.2, 1.701977); (0.3, 1.734832); (0.4, 1.763404); (0.5, 1.787764); (0.6, 1.808002); (0.7, 1.824230); (0.8, 1.836580); (0.9, 1.845201)]
let xxList = [0.172544; 0.815445; 0.269765]
let yy = 1.739372

main dataList xxList yy
//open System.Collections.Generic
//
//let h = 0.1
//
//
//let createD list = 
//    let newList = new List<float>()
//    for i = 0 to (List.length list - 2) do
//        let element = list.[i + 1] - list.[i]
//        newList.Insert(i, element)
//    Array.toList(newList.ToArray())
//
//
//let ll = [-0.9; -1.2; -0.3; 2.4; 7.5; 15.6; 27.3; 43.2; 63.9]
//let m = createD ll
//let m2 = createD m
//let m3 = createD m2
//let m4 = createD m3
//let m5 = createD m4
//let m6 = createD m5
//let m7= createD m6
//
//printfn "%A" ll
//printfn "%A" m
//printfn "%A" m2
//printfn "%A" m3
//printfn "%A" m4
//printfn "%A" m5
//printfn "%A" m6
//printfn "%A" m7
