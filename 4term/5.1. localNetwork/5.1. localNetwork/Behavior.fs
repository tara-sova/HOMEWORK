module Behavior
open Computer
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks
open System.IO
open Microsoft.FSharp.Collections

/// Class that describe behavior of system in infection process.
type Behavior() = 
     let mutable compList : Computer list = []
     let mutable infectedComputers = Array.create 4 false//is private?

/// Change a system condition because of thread of infection.
     member b.Behavior (matrix : int [,]) (computersFromStuff : Computer list) = 
         compList <- computersFromStuff
         infectedComputers <- Array.create (Array2D.length1 matrix) false
         b.FillingOfArray

/// Fill bool list that demonstrate computers which is infect.
     member b.FillingOfArray = 
         for i = 0 to (Array.length infectedComputers - 1) do
             infectedComputers.[i] <- compList.[i].GetHealthCondition
         infectedComputers

/// Auxiliary process of infection.
     member b.InternalInfection (matrix : int[,]) (extraIndex : int) = 
         infectedComputers <- b.FillingOfArray
         for i = 0 to (infectedComputers.Length - 1) do
             if infectedComputers.[i] then
                for j = 0 to (infectedComputers.Length - 1) do
                    let forI = (compList.[i].GetHealthCondition)
                    let forJ = (compList.[j].GetHealthCondition)
                    let compose = forI && forJ
                    let notCompose = not compose
                    let mIJ = matrix.[i, j]
                    if ( (matrix.[i, j] = 1) && ( notCompose ) ) then
                       compList.[j].TryToInfect(extraIndex)
         infectedComputers = b.FillingOfArray
  
/// Get array of coputers that are infected.
     member b.GetArray() = infectedComputers

/// Get health condition of intrested computer.
     member b.GetComputerHealthCondition (name : int) = compList.[name].GetHealthCondition

