let rec fibonacci n =
    if n < 0 then None
    elif n = 0 || n = 1 || n = 2 then Some 1
    else 
        match fibonacci (n - 1) with
            | None -> None
            | Some x -> 
                        let previous =  fibonacci(n - 2)
                        match previous with
                        | None -> None
                        | Some y -> Some (x + y)