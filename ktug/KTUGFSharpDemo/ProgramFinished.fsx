open System
open System.IO

type MyType = { Answer:int; Pixels:int[] }

let getRecordsFromFile filePath = 
    let lines = File.ReadAllLines(filePath)
    let commaSeparatedElements = Array.map (fun (line:string) -> line.Split(',')) lines
    let commaSeparatedElementsWithoutHeaders = commaSeparatedElements.[1 .. ]
    let integerize (xs:string[]) = Array.map (fun (element:string) -> Convert.ToInt32(element)) xs
    let commaSeparatedElementsWithoutHeadersAsInt = Array.map integerize commaSeparatedElementsWithoutHeaders
    let recordize (intArray:int[][]) = Array.map (fun (array:int[]) -> { Answer = array.[0]; Pixels = array.[1 .. ] }) intArray
    let records = recordize commaSeparatedElementsWithoutHeadersAsInt
    records

let records = getRecordsFromFile @"D:\Temp\Day1Tutorial\trainingsample.csv"
let validationRecords = getRecordsFromFile @"D:\Temp\Day1Tutorial\validationsample.csv"

let calculateDistance (p1: int[]) (p2: int[]) =
    Array.map2 (fun p1 p2 -> (p1 - p2)*(p1 - p2)) p1 p2 |>
    Array.sum |>
    float |>
    sqrt

let classify (unknown:int[]) =
    let newMap = records |> Array.map (fun (record) -> record, calculateDistance unknown record.Pixels)
    let record, distance = newMap |> Array.minBy (fun (record, distance) -> distance)
    record.Answer

let evaluateClassifier = 
    let res = 
        validationRecords |>
        Array.map (fun (rec1) ->  rec1.Answer, classify(rec1.Pixels)) |>
        Array.filter(fun(answer, classification) -> answer = classification) |>
        fun(x) -> float x.Length/float 500
    res

let x = evaluateClassifier
printfn  "Res: %f" x


System.Console.ReadKey() |> ignore