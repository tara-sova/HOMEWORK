let rec search number list = 
    if (List.head(list) = number) then list
    elif ((List.length list = 1) && (List.head list <> number)) then
        failwith "No such number in a list" 
    else
        search number list.Tail

let rec getPosition number list = 
    List.length(list) - List.length(search number list)

getPosition 5 [1; 2; 3];;