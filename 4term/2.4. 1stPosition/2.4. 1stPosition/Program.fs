let rec search number list = 
    if List.head(list) = number then Some(list)
    elif (List.length list = 1 && List.head list <> number) then None
    else 
         match search number list.Tail with
         | Some(list) -> Some(list)
         | None -> None

let getPosition number list = 
    let optionRes = search number list 
    if optionRes.IsNone then "No such number"
    else (List.length list - optionRes.Value.Length).ToString()

let list = [1;2;3;4;5]
let result = getPosition 6 [1;2;3;4;5]
result