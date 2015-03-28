let rec div n lessN = 
    if (n = 1 || n = 0) then 2
    elif (lessN = 1) then n
    elif (n % lessN = 0) then 2
    else div n (lessN - 1)

let seqInfinite = Seq.initInfinite (fun index ->
     div index (index - 1) ) |> Seq.distinct
printfn "%A" seqInfinite