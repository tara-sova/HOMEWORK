module WorkProcess
open tree
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks

let myTree : Tree<int> = Tree ( 7, Tree (5, Tip(3), Tree(6, Tip(4), None)), Tree (10, Tip(8), Tree(12, Tip(11), None)) )
let newTree : Tree<int> = Tree ( 7, Tree (5, Tip(3), Tip(6)), Tree (10, Tip(8), Tree(12, None, Tip(13))) )
let ttree : Tree<int> = Tree ( 14, Tree (12, Tip 10, Tip 13), Tree(18, None, Tree (20, None, Tip 21)) )
let tree4 : Tree<int> = Tree ( 5, Tree(2, Tip 1, Tip 3), Tree(11, Tree(9, Tree(7, None, Tip 8), None), Tip 12) )
//let (lol : Tree<int>) = myTree.RemoveElement 8 myTree // val lol : Tree<int> = Tree (7,Tree (3,Tip 2,Tip 4),Tree (9,Tip 1,None))
//let (tr : Tree<int>) = newTree.RemoveElement(10).RemoveElement(5)
//let tr1 = tr.Clean
//
//let is7 = tr1.IsElementExist 6
//let is5 = tr1.IsElementExist 5
//let is10 = tr1.IsElementExist 10
//let is11= tr1.IsElementExist 11
//is11
let tree4R = tree4.RemoveElement(5);
let r = ttree.RemoveElement(14)


let trr = myTree.RemoveElement(10)
trr

