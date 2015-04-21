// function passed as parameter to other function
open System;


let add3 x = x + 3
let multiply4 x = x * 4

let calculateSquareOfFunctionResult myFunction n = 
    let functionResult = myFunction n
    functionResult * functionResult

calculateSquareOfFunctionResult add3 5
calculateSquareOfFunctionResult multiply4 5

// function that returns another function:
let functionGenerator (n1:int) (operation) (n2:int)  = 
    let generatedFunction = match operation with
        | "+" -> fun(n1,n2)->n1+n2
        | "-" -> fun(n1,n2)->n1-n2
        | "*" -> fun(n1,n2)->n1*n2
        | _ -> failwith "Unknown operation"
    generatedFunction




// using object methods as first class functions
open System.IO;
[@"d:\temp";@"c:\windows"] |> List.map Directory.GetDirectories


