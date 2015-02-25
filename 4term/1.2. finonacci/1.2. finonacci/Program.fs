let rec fibonacci n =
    if n < 0 then None
    elif n = 0 || n = 1 || n = 2 || n = 3 then Some 1
    else 
        match fibonacci n with
        | Some x -> Some(x - 1) + Some(x - 2)
        | None -> None