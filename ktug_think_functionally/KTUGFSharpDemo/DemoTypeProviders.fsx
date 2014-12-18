#r @"D:\scm\product\reporting\misc\KTUGFSharpDemo\packages\FSharp.Data.2.1.0\lib\net40\FSharp.Data.dll"

open FSharp.Data

let wb = WorldBankData.GetDataContext()
let ireland = wb.Countries.Ireland
wb.Countries.``Czech Republic``.Indicators.``Central government debt, total (% of GDP)``
|> Seq.maxBy fst
|> fun value -> printf "Year: %d Value:%f" (fst value) (snd value) 

let fb = FreebaseData.GetDataContext()
for rel in fb.Society.Religion.Religions |> Seq.take 10 do
    printfn "%s" rel.Name

System.Console.ReadLine() |> ignore