let rec action (list : char list) = 
    if (List.length(list) = 1) then [List.head(list)]
    else
        action(list.Tail) @ [list.Head]
let act (str : string) = 
  let list = [for s in str -> s]
  let newList = action(list)
  list.Equals(newList : char list)