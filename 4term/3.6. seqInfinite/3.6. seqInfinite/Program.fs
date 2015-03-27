let rec div n lessN = 
    if (n = 1 || n = 0) then 0
    elif (lessN = 1) then n
    elif (n % lessN = 0) then 0
    else div n (lessN - 1)

let seqInfinite = Seq.initInfinite (fun index ->
     div index (index - 1) ) |> Seq.distinct |> Seq.skip 1 |> Seq.take 10
printfn "%A" seqInfinite