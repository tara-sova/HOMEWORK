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
type StuffClass (info : (string * string * string) array, matrixArr : int [] []) = 
     let mutable compList : Computer list = []
     let mutable size : int = 5
     let mutable stuffMatrix = Array2D.create size size 0


/// Start of infection process.
     member s.Start() = 
         //size <- int info.Head
         size <- info.Length
 
         //for i in 1 .. 3 .. (size * 3) do
         for i = 0 to 2 do
             let comp = new Computer()
             //let sign : string = info.[i]
             let (fst, snd, trd) = info.[i]
             let sign : string = fst
             let isInfected = 
                 sign = "+"
             let name = snd
             let systemType = trd
              
             comp.SetHealthCondition(isInfected)
             comp.SetOSType(comp.InfectionIndex(systemType))
             comp.SetName(name)
              
             let someList = compList @ [comp]
             compList <- someList
              
         stuffMatrix <- Array2D.create size size 0
         for i = 0 to (size - 1) do
             for j = 0 to (size - 1) do
                 stuffMatrix.[i, j] <- matrixArr.[i].[j]

/// Get computers's list.
     member s.GetArrayOfComputers() = compList


/// Get matrix of system interaction.
     member s.GetMatrix() = stuffMatrix


        
