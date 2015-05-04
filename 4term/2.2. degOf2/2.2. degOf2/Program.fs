let rec upDeg n =
    if (n = 1) then 2            
    else
        2 * upDeg(n - 1)

let rec createList n = 
    [upDeg(n); upDeg(n + 1); upDeg(n + 2); upDeg(n + 3); upDeg(n + 4)]

