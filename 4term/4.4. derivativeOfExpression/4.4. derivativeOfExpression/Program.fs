type Expression =
    | X
    | Const of int
    | Neg of Expression
    | Add of Expression * Expression
    | Mul of Expression * Expression
    | Div of Expression * Expression

let rec Derivative x : Expression =
    match x with
    | X -> Const(1)
    | Const(n) -> Const(0)
    | Neg(e) -> Neg(Derivative(e))
    | Add(e1, e2) -> Add(Derivative(e1), Derivative(e2))
    | Mul(e1, e2) -> Add(Mul(Derivative(e1), e2), Mul(e1, Derivative(e2)))
    | Div(e1, e2) -> Div( Add(Mul(Derivative(e1), e2), Neg(Mul(e1, Derivative(e2)))), Mul(e2, e2))

let rec recExp (exp : Expression) : string = 
    match exp with
    | X -> "x"
    | Const x -> sprintf "%A" x
    | Neg x -> sprintf "(-%s)" (recExp x)
    | Add(e1, e2) -> 
                     let first = recExp e1
                     let second = recExp e2
                     if (first = "0") then second
                     elif (second = "0") then first
                     else "(" + first + "+" + second + ")"
    | Mul(e1, e2) -> 
                     let first = recExp e1
                     let second = recExp e2
                     if (first = "0" || second = "0") then "0"
                     elif (first = "1") then second
                     elif (second = "1") then first
                     else "(" + first + " * " + second + ")"
    | Div(e1, e2) ->
                     let first = recExp e1
                     let second = recExp e2
                     if (first = "0") then "0"
                     elif (second = "1") then first
                     elif (second = "0") then "0"
                     else "(" + first + " / " + second + ")"

let test (exp : Expression) = 
    let derivativeExp = Derivative(exp)
    recExp(derivativeExp)

let result1 = test (Add( Mul(X, Const(3)), Const(6) )) // input: (3 * x) + 6,  result: 3
let result2 = test (Div(Const(5), X)) // input: (5 / x),  result: ((-5) / (x * x))