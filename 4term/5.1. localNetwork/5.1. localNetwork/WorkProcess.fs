module WorkProcess
open Behavior
open StuffClass

let rand = new System.Random()
let extraIndex = rand.Next(71, 80)

let infArr = [|("+", "0", "W"); ("-", "1", "L"); ("-", "2", "W")|]
let matrixArr = [| [|0; 0; 1|]; [|1; 0; 1|]; [|1; 1; 0|] |]

let stuff = new StuffClass (infArr, matrixArr)
stuff.Start()
let behavior = new Behavior()
    
behavior.Behavior (stuff.GetMatrix())  (stuff.GetArrayOfComputers()) |> ignore
behavior.InternalInfection (stuff.GetMatrix()) extraIndex |> ignore
let conditionOf0 = behavior.GetComputerHealthCondition(0) //true
let conditionOf1 = (behavior.GetComputerHealthCondition(1)) //false
let conditionOf2 = (behavior.GetComputerHealthCondition(2)) //true


