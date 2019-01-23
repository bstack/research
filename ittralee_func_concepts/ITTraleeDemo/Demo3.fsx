// euler problem
let getRemainder subject divisor = subject % divisor;;

let getRemainderFor1ToN subject n = 
    seq {1 .. n}
    |> Seq.map (fun(element) -> getRemainder subject element)
    |> Seq.sum

let rec getAnswer subject =
    match getRemainderFor1ToN subject 20 with
    | 0 -> subject
    | _ -> getAnswer (subject+1)