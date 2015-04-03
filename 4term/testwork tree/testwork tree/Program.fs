type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec go (tree : Tree<'a>) (list : 'a list) (f: 'a -> bool)= 
    match tree with
    | Tree (value, left, right) -> let res = go (Tip value) list f @ go left list f @ go right list f
                                   res
    | Tip(value) -> 
                    if (f value = true) then (value :: list)
                    else list

let isEven n = 
    if (n % 2 = 0) then true
    else false

let result (tree : Tree<int>) (f: 'a -> bool)= 
    let res = go tree [] f
    res

let myTree = Tree(0, Tree(1, Tip(2), Tip(3)), Tip(4))
result myTree isEven

