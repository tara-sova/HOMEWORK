let rec compair (list) head repeat =
    if ((List.head list) = head) then true
       else
           if ((List.length list) = 1) then repeat
           else
               compair list.Tail head repeat

let rec smth list repeat = 
    if ((List.length list) = 1) then repeat
    else 
        let repeat = compair (list.Tail) (list.Head) repeat
        smth list.Tail repeat

let action list =
    let repeat = false
    smth list repeat