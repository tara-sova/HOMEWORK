type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec mapTree (tree  : 'a Tree) (f : 'a -> 'b) = 
    match tree with
    | Tree (value, left, right) -> Tree (f value, mapTree left f, mapTree right f)
    | Tip(value) -> Tip(f value)

let myTree = Tree(0, Tree(1, Tip(2), Tip(3)), Tip(4))

let result = mapTree myTree (fun x -> x + 1)