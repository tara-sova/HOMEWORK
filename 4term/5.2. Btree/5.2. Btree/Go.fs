module Go
open tree

let tree = new BTree<int>()
tree.InsertElement 5
tree.InsertElement 2
tree.InsertElement 1
tree.InsertElement 3
tree.InsertElement 8
tree.InsertElement 6
tree.InsertElement 9

tree.RemoveElement 4
tree.RemoveElement 5

printfn "%A" (tree.IsElementExist 1)

for i in tree do
    printf "%A " i
let a = 0
a

