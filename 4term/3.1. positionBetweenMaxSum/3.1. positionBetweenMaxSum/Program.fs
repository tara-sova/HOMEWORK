let rec createAResult (list : int list) (position : int) (max : int) (pair : int*int)= 
    if (position = ((List.length list) - 2)) then pair
    else
        let positionSum = (list.[position] + list.[position + 2])
        let somePosition = position + 1
        if ((list.[position] + list.[position + 2]) > max) then 
           createAResult list somePosition positionSum (somePosition, positionSum)
        else
            createAResult list (position + 1) (max) pair

let action (list : int list) = 
    let position = 0
    let max = -1
    let (first, second) = createAResult list position max (position, max)
    first