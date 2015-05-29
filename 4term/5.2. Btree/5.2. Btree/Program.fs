module tree
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks 
open System
open System.Collections
open System.Collections.Generic                             
                                                                                 
let mutable flag : bool = false                          

type Tree<'a> = 
    | Tree of 'a * Tree<'a> * Tree<'a> 
    | Tip of 'a
    | None
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

type Enumerator<'a when 'a:comparison>(tree : Tree<'a>) =
     let rec treeToList tree =
         match tree with
         | Tree(value, left, right) -> value :: treeToList left @ treeToList right
         | Tip value -> [value]
         | None -> []

     let list = ref (treeToList tree) 

     interface IEnumerator with
          member e.get_Current() =
              let current = (!list).Head :> obj 
              list := (!list).Tail
              current

          member e.MoveNext() = 
              match !list with
              | [] -> false
              | _ -> true

          member e.Reset() = list := (treeToList tree)

     interface IEnumerator<'a> with
          member e.get_Current() = (!list).Head
          member e.Dispose () = ()

type BTree<'a when 'a:comparison>() =
     let mutable listB = []
     let mutable tree = None
     
     member b.InsertElement n = 
         let rec insert tree n = 
             match tree with
             | Tree(value, left, right) -> 
                                           if (n < value) then Tree ( value, insert left n, right)
                                           elif (n > value) then Tree ( value, left, insert right n)
                                           else Tree(value, left, right)
             | Tip value -> 
                            if (n < value) then Tree (value, Tip(n), None)
                            elif (n > value) then Tree (value, None, Tip(n))
                            else Tip value
             | None -> Tip n
         tree <- insert tree n
         tree

     member b.RemoveElement n  = 
         let rec remove firstTree n = 
             match firstTree with
             | Tree(value, left, right) -> 
                                           if (n < value) then Tree (value, remove left n, right)
                                           elif (n > value) then Tree (value, left, remove right n)
                                           else 
                                               if (left = None && right <> None) then 
                                                  Tree (right.GetValue(), right.GetLeft(), right.GetRight())
                                               elif (right = None && left <> None) then 
                                                    Tree (left.GetValue(), left.GetLeft(), left.GetRight())
                                               else
                                                   let rec recSearchElement treeIn detectFlag =
                                                       match treeIn with
                                                       | Tree (v, l, r) -> 
                                                                           if detectFlag = false then 
                                                                              let someTree = Tree (v, l, recSearchElement r true)
                                                                              Tree(List.head listB, someTree.GetLeft(), someTree.GetRight())
                                                                           else
                                                                               if l = None then
                                                                                  listB <- treeIn.GetValue() :: listB
                                                                                  Tree(r.GetValue(), r.GetLeft(), r.GetRight())
                                                                               else
                                                                                   Tree (v, recSearchElement l true, r)
                                                       | Tip v -> 
                                                                  listB <- treeIn.GetValue() :: listB
                                                                  None
                                                       | None -> None
                                                                       
                                                   let res = recSearchElement firstTree false
                                                   res
                                           
             | Tip value ->
                            if value = n then None
                            else Tip value
             | None -> None
         tree <- remove tree n


     member b.IsElementExist n = 
         let rec check someTree n = 
             match someTree with
             | Tree(value, left, right) -> 
                                           if value = n then true
                                           elif n > value then check right n
                                           else check left n
             | Tip value ->
                            if value = n then true
                            else false
             | None -> false
         check tree n

     interface IEnumerable with
         member e.GetEnumerator() = new Enumerator<'a>(tree) :> IEnumerator