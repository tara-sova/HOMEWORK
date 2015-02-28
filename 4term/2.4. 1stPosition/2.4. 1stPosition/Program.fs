let rec search number list = 
    if (List.head(list) = number) then list
    else
        search number list.Tail
let rec getPosition number list = 
    List.length(list) - List.length(search number list)