open System
open System.IO

type LetterData = { Answer:int; Pixels:int[] }

let readLetterData location =

    let lines = File.ReadAllLines(location)

    // Get comma separated elements for each line (string required due to .Split)
    let commaSeparatedElements = Array.map (fun (line:string) -> line.Split(',')) lines

    // slice off headers
    let commaSeparatedElementsWithoutHeaders = commaSeparatedElements.[1 .. ]

    // declare a function that takes in an array of strings but returns an array of integers
    let integerize (xs) = Array.map (fun (element:string) -> Convert.ToInt32(element)) xs

    // Array map all string[] into int[]s
    let commaSeparatedElementsWithoutHeadersAsInt = Array.map integerize commaSeparatedElementsWithoutHeaders

    // For all 2d array, return collection of types
    let records = Array.map (fun (array:int[]) -> { Answer = array.[0]; Pixels = array.[1 .. ] }) commaSeparatedElementsWithoutHeadersAsInt
    records

let trainingLetters = readLetterData @"D:\scm\product\reporting\misc\KTUGFSharpDemo\KTUGFSharpDemo\trainingsample.csv"
let validationLetters = readLetterData @"D:\scm\product\reporting\misc\KTUGFSharpDemo\KTUGFSharpDemo\validationsample.csv"

let calculateDistanceBetweenTwoLetters (leftPixelCollection) (rightPixelCollection) =
    Array.map2 (fun p1 p2 -> (p1 - p2)*(p1 - p2)) leftPixelCollection rightPixelCollection |>
    Array.sum |>
    float |>
    sqrt

let classify (unknown:int[]) =
    let newMap = trainingLetters |> Array.map (fun (trainingLetter) -> trainingLetter, calculateDistanceBetweenTwoLetters unknown trainingLetter.Pixels)
    let record, distance = newMap |> Array.minBy (fun (record, distance) -> distance)
    record.Answer


let evaluateClassifier = 
    let res = 
        validationLetters |>
        Array.map (fun (rec1) ->  rec1.Answer, classify(rec1.Pixels)) |>
        Array.filter(fun(answer, classification) -> answer = classification) |>
        fun(correctAnswers) -> float correctAnswers.Length/float 500
    res