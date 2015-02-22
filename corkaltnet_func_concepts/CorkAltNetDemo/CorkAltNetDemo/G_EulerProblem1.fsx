// Euler problem 1: https://projecteuler.net/problem=1

// If we list all the natural numbers below 10 that are multiples of 3 or 5, 
// we get 3, 5, 6 and 9. The sum of these multiples is 23.

// Find the sum of all the multiples of 3 or 5 below 1000.

let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""

let multiplesOf3 = seq { 0 .. 3 .. 1000 } |> Set.ofSeq
let multiplesOf5 = seq { 0 .. 5 .. 1000 } |> Set.ofSeq

let multiplesOf3Or5 = Set.union multiplesOf3 multiplesOf5
printSeq multiplesOf3Or5

let sum = multiplesOf3Or5 |> Seq.sum
printfn "Answer:%d" sum