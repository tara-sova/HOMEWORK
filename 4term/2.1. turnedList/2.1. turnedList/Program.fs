let rec action list = 
    if (List.length(list) = 1) then [List.head(list)]
    else
        action(list.Tail) @ [list.Head]
