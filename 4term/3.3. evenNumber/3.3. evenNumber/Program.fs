let check (x : int) list= 
    if (x % 2 = 0) then x
    else 2*x

let record list (extralist : bool list) = 
    if ((List.head extralist) = false) then  

let action (list : int list) = 
    let list1 = [0]
    let extraList = list |> List.map (fun x -> (x % 2))
