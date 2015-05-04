//let check (x : int) list= 
//    if (x % 2 = 0) then 1
//    else 0

//let record list (extralist : bool list) = 
//    if ((List.head extralist) = false) then  

let countWithMap (list : int list) = 
    let extraList = list |> List.map (fun x -> (x % 2))
    ((List.length extraList) - (List.sum extraList))

let countWithFilter (list : int list) = 
    let res = list |> List.filter (fun x -> (x % 2 = 0))
    res.Length

let check (x : int) = 
    if (x % 2 = 0) then 1
    else 0
let countWithFold (list : int list) = 
    let count = List.fold (fun acc x -> acc + (check x)) 0 list
    count