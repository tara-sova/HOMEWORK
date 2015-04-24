module Stack
open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks

type Stack() = 
     let stack = new List<int>()

/// Push value to a Stack.
     member s.Push(value : int) = stack.Add(value)

/// Take Stack's top element.
     member s.Pop() = 
         if s.IsEmpty() then failwith "Stack is empty"
         let element = stack.[stack.Count - 1]
         stack.RemoveAt(stack.Count - 1)
         element

/// Check of existence elements in Stack.
     member s.IsEmpty() = 
         if (stack.Count = 0) then true
         else false

let s = new Stack()
s.Push(3)
s.Push(2)
s.Push(1)
let isE1 = s.IsEmpty()
let res1 = s.Pop()
let res2 = s.Pop()
let res3 = s.Pop()
let isE2 = s.IsEmpty()
let fail = s.Pop()