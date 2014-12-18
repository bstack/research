// demonstrating recursion and pattern matching
let list1 = [ 1; 5; 100; 450; 788 ]

// Pattern matching by using the cons pattern and a list 
// pattern that tests for an empty list. 
let rec printList listx =
    match listx with
    | head :: tail -> printf "%d " head; printList tail
    | [] -> printfn ""

printList list1

// demonstrating pattern matching
let filter123 x =
    match x with
    | 1 | 2 | 3 -> printfn "Found 1, 2, or 3!"
    | a -> printfn "%d" a

let filterWithWhen x =
    match x with
    | 1 | 2 | 3 -> printfn "Found 1, 2, or 3!"
    | withinValidNumberRange when withinValidNumberRange > 0 -> printfn "Found a valid number"
    | _ -> printfn "The test value is out of range."

let filterWithError x =
    match x with
    | 1 | 2 | 3 -> printfn "Found 1, 2, or 3!"
    | withinValidNumberRange when withinValidNumberRange > 0 -> printfn "Found a valid number"
    | _ -> failwith "Unknown report type" "The test value is out of range."

// 
let x = Some 99
let result = match x with 
| Some i -> i * 2
| None -> 0