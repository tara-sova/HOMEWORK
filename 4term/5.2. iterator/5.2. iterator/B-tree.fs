module tree
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks                              
                                                             
let mutable oldValue : int = 0                          
let mutable newValue : int = 0                     
let mutable flag : bool = false                            
let mutable removeFlag : bool = false                    

type Tree<'a> = //: IEnumerable<ElementType> :
    | Tree of int * Tree<'a> * Tree<'a> 
    | Tip of int
    | None
     member t.InsertElement (n : int) (someTree : Tree<'a>) = 
          match t with
          | Tree(value, left, right) -> 
                                        if (n < value) then Tree ( value, left.InsertElement n someTree, right)
                                        elif (n > value) then Tree ( value, left, right.InsertElement n someTree)
                                        else someTree
          | Tip value -> 
                         if (n < value) then Tree (value, Tip(n), None)
                         elif (n > value) then Tree (value, None, Tip(n))
                         else someTree
          | None -> None
//
//     member t.IsATip = 
//         match t with
//         | Tree (value, left, right) -> 
//                                        if (left = None && right = None) then true
//                                        else false
//         | Tip value -> true
//         | None -> false

     member t.RemoveElement (n : int)  = 
         match t with
         | Tree(value, left, right) -> 
                                       if (n < value) then Tree (value, left.RemoveElement n, right)
                                       elif (n > value) then Tree (value, left, right.RemoveElement n)
                                       else 
                                           if (left = None && right <> None) then 
                                              Tree (right.GetValue(), right.GetLeft(), right.GetRight())
                                           elif (right = None && left <> None) then 
                                                Tree (left.GetValue(), left.GetLeft(), left.GetRight())
                                           else
                                               let rec recSearchElement tree detectFlag =
                                                   match tree with
                                                   | Tree (v, l, r) -> 
                                                                       if detectFlag = false then Tree (v, l, recSearchElement r true)
                                                                       else
                                                                           if l = None then
                                                                              newValue <- tree.GetValue()
                                                                              Tree(r.GetValue(), r.GetLeft(), r.GetRight())
                                                                           else
                                                                                Tree (v, recSearchElement l true, r)
                                                   | Tip v -> 
                                                              newValue <- v
                                                              None
                                                   | None -> None
                                                                       
                                               recSearchElement t false
                                           
         | Tip value ->
                        if value = n then None
                        else Tip value
         | None -> None

     member t.GetLeft() = 
         match t with
         | Tree (value, left, right) -> left
         | Tip value -> None
         | None -> None

    member t.GetRight() = 
         match t with
         | Tree (value, left, right) -> right
         | Tip value -> None
         | None -> None

    member t.GetValue() = 
        match t with
        | Tree (value, left, right) -> value
        | Tip value -> value
        | None -> failwith "No profit"

     member t.IsElementExist (n : int) = 
         match t with
         | Tree(value, left, right) -> 
                                       if value = n then true
                                       elif n > value then right.IsElementExist n
                                       else left.IsElementExist n
         | Tip value ->
                        if value = n then true
                        else false
         | None -> false

type Enumerator<'a>(tree : Tree<'a>) =
    let rec treeToList tree =
       match tree with
       | Tree(value, left, right) ->  value :: treeToList left @ treeToList right
       | Tip value -> [value]
       | None -> []
    let list = ref (treeToList tree) 

    interface IEnumerator with
       member e.getCurrent() =


     interface IEnumerable<'a> with
        member e.GetEnumerator() = new Enumerator<'a>(tree) :> IEnumerator