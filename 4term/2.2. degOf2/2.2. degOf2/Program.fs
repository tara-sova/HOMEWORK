let rec upDeg n =
    if (n = 1) then 2            
    else
        2 * upDeg(n - 1)
let rec createAList n = 
//    [upDeg(n); upDeg(n + 1); upDeg(n + 2); upDeg(n + 3); upDeg(n + 4)]
//createAList 4;;
    let list = [0]
    //List.map (fun n -> n * n * n) createAList;;
    if (list.Length = 5) then printfn "ololo"

