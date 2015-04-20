module WorkProcess
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks
open Hash

let f (newElement : int) =
    let mutable sum = 0
    for i = 0 to (newElement - 1) do
        sum <- sum + i * i
    let res = sum % 10
    res

let mutable hash = new Hash()
hash.Hash(f)
hash.InsertToHashTable(5)
hash.InsertToHashTable(7)
let hash1 = hash

let is5 = hash.Exist(5)
let is7 = hash.Exist(7)

hash.Remove(7)
let not7 = hash.Exist(7)

let hash2 = hash
hash2


