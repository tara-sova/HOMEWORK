let func x l = List.map (fun y -> y * x) l

let func1 : int -> int list -> int list =
    fun x -> List.map (fun y -> y * x)

let func2 : int -> int list -> int list =
    fun x -> List.map (fun y -> ((*) x) y)

let func3 : int -> int list -> int list =
    fun x -> List.map ((*) x)

let func4 : int -> int list -> int list =
    (*) >> List.map