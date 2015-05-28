type Rounding (precision : int) =
    member this.Bind (x : float , rest : float -> float) =
         rest (System.Math.Round (x, precision))  
    member this.Return (x : float) = 
        System.Math.Round(x, precision)

let start = 
   Rounding 3 {
      let! a = 2.0 / 12.0
      let! b = 3.5
      return a / b
   }
start