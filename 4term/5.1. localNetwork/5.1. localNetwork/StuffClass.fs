module StuffClass
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks
open System.IO
open Microsoft.FSharp.Collections
open Computer

/// Class which provide interaction of system with input data.
type StuffClass (info : string list, matrixList : string list) = 
     let mutable compList : Computer list = []
     let mutable size : int = 5
     let mutable stuffMatrix = Array2D.create size size 0


/// Start of infection process.
     member s.Start() = 
         size <- int info.Head
 
         for i in 1 .. 3 .. (size * 3) do
             let comp = new Computer()
             let sign : string = info.[i]
             let isInfected = 
                 if (sign = "+") then true
                 else false
             let name = info.[i + 1]
             let systemType = info.[i + 2]
              
             comp.SetHealthCondition(isInfected)
             comp.SetOSType(comp.InfectionIndex(systemType))
             comp.SetName(name)
              
             let someList = compList @ [comp]
             compList <- someList
              
         stuffMatrix <- Array2D.create size size 0
         for i = 0 to (size - 1) do
             for j = 0 to (size - 1) do
                 stuffMatrix.[i, j] <- (int (matrixList.[i].Chars(j).ToString()) )

/// Get computers's list.
     member s.GetArrayOfComputers() = compList


/// Get matrix of system interaction.
     member s.GetMatrix() = stuffMatrix


        
