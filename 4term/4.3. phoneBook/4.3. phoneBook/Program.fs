open System.IO
open System.Runtime.Serialization.Formatters.Binary

let writeValue outputStream (x: 'a) =
    let formatter = new BinaryFormatter()
    formatter.Serialize(outputStream, box x)

let readValue inputStream =
    let formatter = new BinaryFormatter()
    let res = formatter.Deserialize(inputStream)
    unbox res

let createNote (book : (string * string) list) =
    System.Console.WriteLine("Name:")
    let name = System.Console.ReadLine()
    System.Console.WriteLine("Number:")
    let number = System.Console.ReadLine()
    (name, number) :: book

let rec phoneByNameSearch (book : (string * string) list) (searchName : string) =
    if (book.Length = 0) then "No note"
    else
        let (name, num) = book.Head
        if (name = searchName) then num
        else phoneByNameSearch book.Tail searchName

let rec phoneByNumberSearch (book : (string * string) list) (searchNumber : string) =
    if (book.Length = 0) then "No note"
    else
        let (name, num) = book.Head
        if (num = searchNumber) then name
        else phoneByNumberSearch book.Tail searchNumber

let rec correctOder (book : (string * string) list) (list : string list) pos = 
    if (pos < 0) then list
    else
        let (name, num) = book.[pos]
        correctOder book (name :: num :: list) (pos - 1)

let rec recordInPair (book : (string * string) list) (list : string list) pos = 
    if (pos < 1) then book
    else
        let (name, num) = (list.[pos - 1], list.[pos])
        recordInPair ((name, num) :: book) list (pos - 2)


let rec menu (book : (string * string) list) = 
    System.Console.WriteLine("Press:\n0 -- exit\n1 -- add a note\n2 -- find phone by name\n3 -- find name by number\n4 -- save data into file\n5 -- read data from file\n")
    let choice = System.Console.ReadLine()
    match choice with
    | "0" -> System.Console.WriteLine("GameOver")
    | "1" ->
             let newBook = createNote book
             System.Console.WriteLine("\nAdded")
             menu newBook
    | "2" ->
             let bookForSearch = book
             System.Console.WriteLine("Name:")
             let result = phoneByNameSearch bookForSearch (System.Console.ReadLine())
             System.Console.WriteLine("{0}\n", result)
             menu book
    | "3" ->
             let bookForSearch = book
             System.Console.WriteLine("Number:")
             let result = phoneByNumberSearch bookForSearch (System.Console.ReadLine())
             System.Console.WriteLine("{0}\n", result)
             menu book
    | "4" ->
             let makeData = new FileStream("data.txt", FileMode.Create)
             writeValue makeData (correctOder book [] (book.Length - 1))
             makeData.Close()
             System.Console.WriteLine("Data is written")
             menu book
    | "5" -> 
             let writeData = new FileStream("data.txt", FileMode.Open);
             if (book.IsEmpty) then 
                System.Console.WriteLine("Book is empty\n")
                menu book
             else
                 let list = readValue writeData
                 System.Console.WriteLine("Data is received")
                 writeData.Close()
                 menu (recordInPair [] list (list.Length - 1))
    | _ ->
           System.Console.WriteLine("No such command")
           menu (book)
let start = 
    menu[]
