type Expression = 
    | Number of int
    | Add of Expression * Expression
    | Minus of Expression * Expression
    | Multiply of Expression * Expression
    | Division of Expression * Expression

let rec Calculate exp = 
    match exp with
    | Number n -> n
    | Add (x, y) -> (Calculate x) + (Calculate y)
    | Minus (x, y) -> (Calculate x) - (Calculate y)
    | Multiply (x, y) -> Calculate x * Calculate y
    | Division (x, y) -> if (Calculate y = 0) then 0
                         else Calculate x / Calculate y

let tree1 = Add(Number 0, Add( Add(Number 1, Add(Number 2, Number 3)), Number 4)) // result = 10
let tree2 = Add(Number 0, Minus( Multiply(Number 1, Division(Number 18, Number 3)), Number 4)) // result = 2