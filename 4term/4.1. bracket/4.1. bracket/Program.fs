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

let rec smth (list : string list) pos counter openB closeB=
    if (List.isEmpty list) then "Balance is destroyed"
    elif (pos = list.Length) then
        if (openB = closeB) then "Ok"
        else "Balance is destroyed"
    elif (list.[pos] = "(" || list.[pos] = "[" || list.[pos] = "{") then 
        smth list (pos + 1) counter (openB + 1) closeB
    else
        if (pos - 1 - (2 * counter) >= 0) then
           if (list.[pos] = ")" && list.[pos - 1 - (2 * counter)] = "(") then 
             smth list (pos + 1) (counter + 1) openB (closeB + 1)
           elif (list.[pos] = "}" && list.[pos - 1 - (2 * counter)] = "{") then 
               smth list (pos + 1) (counter + 1) openB (closeB + 1)
           elif (list.[pos] = "]" && list.[pos - 1 - (2 * counter)] = "[") 
               then smth list (pos + 1) (counter + 1) openB (closeB + 1)
           else 
               smth [] pos counter openB (closeB + 1)
        else 
            smth [] pos counter openB (closeB + 1)

let isBalance (s : string)=
    let (list : string list) = []
    let nL = intoL list s (s.Length - 1)
    let result = smth nL 0 0 0 0
    result

isBalance "{[({)]";
isBalance "{[([{}])]}"
isBalance "{[)";
isBalance ")](";