let rec fact n =
    if n < 0 then None
    elif n = 1 then Some 1
    else 
        match fact (n - 1) with
        | Some x -> Some (n * x)
        | None -> None
