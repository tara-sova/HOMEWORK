//let rec read (str : string) position (array : string array) = 
//    if (position < str.Length) then
//       array.[position] <- str.Chars(position).ToString()
//       read str (position + 1) array
//    else
//        array
  
let rec intoL (list : string list) (s : string) (pos : int) = 
    if (pos >= 0) then
       let l = s.Chars(pos).ToString() :: list
       intoL l s (pos - 1)
    else
        list

let rec matching (list : string list) (stackList : string list) =
    if (list.Length = 0 && stackList.Length = 0) then "Correct"
    elif (list.Head = "{" || list.Head = "[" || list.Head = "(") then
       matching list.Tail (list.Head :: stackList)
    elif ((list.Head = "}" || list.Head = "]" || list.Head = ")") && stackList.IsEmpty) then "Incorrect"
    elif list.Head = "}" then
         if stackList.Head = "{" then matching list.Tail stackList.Tail
         else "Incorrect"
    elif list.Head = "]" then
         if stackList.Head = "[" then matching list.Tail stackList.Tail
         else "Incorrect"
    elif list.Head = ")" then
         if stackList.Head = "(" then matching list.Tail stackList.Tail
         else "Incorrect"
    else "Wrong record"
        

let isBalance (s : string) =
    let list = intoL [] s (s.Length - 1)
    if list.IsEmpty then "Empty string"
    else 
        let result = matching list []
        result

let res1 = isBalance "{[({)]"; // - 
let res2 = isBalance "{[([{}])]}" // +
let res3 = isBalance "{[)"; // -
let res4 = isBalance ")]("; // -
let res5 = isBalance "[()([])]";; // +
let res6 = isBalance "[({}){()}()]";; //+