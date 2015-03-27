type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec hightOfTree (tree : Tree<'a>) = 
    match tree with
    | Tree (value, left, right) -> 
           let hight =  1 + max (hightOfTree left) (hightOfTree right)
           hight
    | Tip(value) -> 1

let myTree = Tree(0, Tree(1, Tip(2), Tip(3)), Tip(4))
