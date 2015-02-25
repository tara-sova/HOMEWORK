let rec fibonacci n =
    if n < 0 then None
    elif n = 0 || n = 1 || n = 2 then Some 1
    else
        match fibonacci (n - 1) with
        | None -> None
        | Some x -> Some(x + (match fibonacci(n - 2) with 
                              | None -> None 
                              | Some x -> Some x).Value
                              )