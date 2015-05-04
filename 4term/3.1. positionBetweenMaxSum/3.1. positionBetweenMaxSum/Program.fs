//let rec createAResult (list : int list) (position : int) (max : int) (pair : int*int)= 
//    if (position = ((List.length list) - 2)) then pair
//    else
//        let positionSum = (list.[position] + list.[position + 2])
//        let somePosition = position + 1
//        if ((list.[position] + list.[position + 2]) > max) then 
//           createAResult list somePosition positionSum (somePosition, positionSum)
//        else
//            createAResult list (position + 1) (max) pair
//
//let action (list : int list) = 
//    let position = 0
//    let max = -1
//    let (first, second) = createAResult list position max (position, max)
//    first


let rec findPos (list : int list) coolPos length sum =
    if (list.Length = 2) then
       if (list.Head + list.Tail.Head) > sum then (length - (list.Length - 1))
       else coolPos
    else
        if (list.Head + list.Tail.Head) > sum then
           findPos list.Tail (length - (list.Length - 1)) length (list.Head + list.Tail.Head)
        else
            findPos list.Tail coolPos length sum

let start (list : int list) = 
    findPos list (-1) (list.Length) (-1)

start [1; 5; 6; 2]
