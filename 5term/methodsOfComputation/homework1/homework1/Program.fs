//let p (x : float) = 
//   (pown x 3) - 0.2 * (pown x 2) + 0.5 * x + 1.5
//
//let dP (x : float) = 3.0 * (pown x 2) - 0.4 * x + 0.5

let rec factorial n res = 
    if n = 1.0 then res
    else factorial (n - 1.0) (res * n)

let p1 x = 
    128.0 * (pown x 3) - 256.0 * (pown x 6) + 160.0 * (pown x 4) - 32.0 * (pown x 2) + 1.0

let dP1 x = 
    384.0 * (pown x 2) - 1536.0 * (pown x 5) + 640.0 * (pown x 3) - 64.0 * x

let p2 x = 
    (pown x 3) + 2.0 * (pown x 2) - 1.75 * x - 1.25

let dP2 x = 
    3.0 * (pown x 2) + 4.0 * x - 1.75

let p3 x = //(pown x 3) + 4.0 * sin(x)
    (pown x 3) + 4.0 * (x - ((pown x 3) / (factorial 3.0 1.0)) + ((pown x 5) / (factorial 5.0 1.0)))

let dP3 x = 
    3.0 * (pown x 2) + 4.0 * (1.0 - ((pown x 2) / (factorial 2.0 1.0)) + ((pown x 4) / factorial 4.0 1.0))
 

let rec solve (f : float -> float) (dF : float -> float) (interval : float * float) (x_0 : float) = 
    let eps : float = 0.00001 //0.001 //0.00001
    let px = f x_0
    let dPx = dF x_0
    let x_k = x_0 - ( px / dPx )
    let difference = x_k - x_0
    if abs difference > eps then solve f dF interval x_k
    else x_0
    

let act (interval : float * float) (f : float -> float) (dF : float -> float) =
    let (x_0 : float) = (fst interval + snd interval) / 2.0
    let solution = solve f dF interval x_0
    solution

let result = act (-1.0, 1.0) p1 dP1