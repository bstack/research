
// Euler problem 5: https://projecteuler.net/problem=5
//
// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

let getRemainder subject divisor =
    subject % divisor

let getRemainderFor1To20 sub:int = 
    let countSequence = seq {1 .. 10}
    let remainderMap = Seq.map (fun(element) -> getRemainder sub element) countSequence
    let remainderValue = remainderMap |> Seq.sum
    remainderValue

let rec getAnswer n =
    let remainder = getRemainderFor1To20 n
    printfn "Processed number: %d which has remainder: %d" n remainder 
    if remainder = 0 then n
    else getAnswer (n+1)

getAnswer 1