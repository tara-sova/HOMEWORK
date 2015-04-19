module Computer
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks

/// Class for Computer.
type Computer() =
     let mutable isInfected : bool = false
     let mutable osType : int = 0
     let mutable name : string = ""

/// Get index of infection.
     member c.InfectionIndex(system : string) = 
         if (system = "W") then 50
         elif (system = "L") then 70
         else 0

/// Infect or not by special index.
     member c.TryToInfect(extraIndex : int) = 
         if (osType < extraIndex) then
            isInfected <- true
            ()
         else ()

/// Get computer's health condition.
     member c.GetHealthCondition : bool = isInfected

/// Get computer's operation system type.
     member c.GetOSType : int = osType

/// Get computer's name.
     member c.GetName : string = name

/// Change computer's health option.
     member c.SetHealthCondition(condition : bool) = isInfected <- condition

/// Change computer's operation system option.
     member c.SetOSType(systemType : int) = osType <- systemType

/// Change computer's name option.
     member c.SetName(newName : string) = name <- newName
