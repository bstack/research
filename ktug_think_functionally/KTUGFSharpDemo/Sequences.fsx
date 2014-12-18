open System

let seq1 = seq { 0 .. 11 .. 100 }
Seq.iter (fun x -> printfn "Number %d" x) seq1

let seq2 = seq { for i in 1 .. 10 do yield i * i }
let seq3 = seq { for i in 1 .. 10 -> i * i }

// Utilising mutable Arraylist and converting into a sequence
let mutable arrayList1 = new System.Collections.ArrayList(10)
for i in 1 .. 10 do arrayList1.Add(i) |> ignore
let seqCast : seq<int> = Seq.cast arrayList1
Seq.iter (fun x -> printfn "Number %d" x) seqCast

// Using Seq.unfold
// Seq.unfold uses an option type for the state, which enables you to terminate the sequence by returning the None value
let seq4 = Seq.unfold (fun state -> if (state > 20) then None else Some(state, state + 1)) 0
Seq.iter (fun x -> printfn "Number %d" x) seq4

// pipelining sequences
let res = 
    seq { 0 .. 11 .. 100 }
    |> Seq.map (fun x -> x*2)
    |> Seq.map (fun x -> x+1)
    |> Seq.max
    |> float
    |> sqrt

System.Console.ReadLine() |> ignore