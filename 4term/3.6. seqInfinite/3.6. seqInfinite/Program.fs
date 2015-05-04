let rec div n lessN = 
    if (n = 1 || n = 0) then 2
    elif (lessN = 1) then n
    elif (n % lessN = 0) then 2
    else div n (lessN - 1)

let isprime n =
    let rec check i =
        i > n/2 || (n % i <> 0 && check (i + 1))
    check 2

//let seqInfinite = Seq.initInfinite (fun index ->
//     div index (index - 1) ) |> Seq.distinct
//printfn "%A" seqInfinite


isprime 6;