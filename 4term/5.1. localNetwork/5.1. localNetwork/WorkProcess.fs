module WorkProcess
open Behavior
open StuffClass

let rand = new System.Random()
let extraIndex = rand.Next(71, 80)

let infoList = "3" :: "+" :: "0" :: "W" :: "-" :: "1" :: "L" :: "-" :: "2" :: ["W"]
let matrixList = "001":: "101" :: ["110"]

let stuff = new StuffClass (infoList, matrixList)
stuff.Start()
let behavior = new Behavior()
    
behavior.Behavior (stuff.GetMatrix())  (stuff.GetArrayOfComputers())
behavior.InternalInfection (stuff.GetMatrix()) extraIndex
let conditionOf0 = behavior.GetComputerHealthCondition(0) //true
let conditionOf1 = (behavior.GetComputerHealthCondition(1)) //false
let conditionOf2 = (behavior.GetComputerHealthCondition(2)) //true



