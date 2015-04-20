module Hash
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks

/// Hash
type Hash() = 

/// Elements of a hashtable are lists. 
    let mutable bucket = new List<List<int>>()

/// Main hashfunction.
    let mutable hashFunc : int -> int = fun x -> x + 1

/// Create internal lists ih a hashtable
    member h.Hash(someHashFunc : int -> int) = 
        for i = 0 to 9 do
            let intList = new List<int>()
            bucket.Add(intList)
        hashFunc <- someHashFunc

/// Insert value in hashtable.
    member h.InsertToHashTable(newElement : int) = 
        bucket.[hashFunc(newElement)].Add(newElement)


/// Check of element's exictence in a hashtable.
    member h.Exist(newElement : int) = 
        let res = bucket.[hashFunc(newElement)].Exists(fun x -> x = newElement)
        res
       
/// Remove element from hashtable.
    member h.Remove(newElement : int) = 
        bucket.[hashFunc(newElement)].Remove(newElement)

