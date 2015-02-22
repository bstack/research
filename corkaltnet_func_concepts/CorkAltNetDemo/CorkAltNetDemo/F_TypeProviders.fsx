// http://blogs.msdn.com/b/dsyme/archive/2013/01/30/twelve-type-providers-in-pictures.aspx
#r @"D:\Temp\research\ktug_think_functionally\packages\FSharp.Data.2.1.1\lib\net40\FSharp.Data.dll"

open FSharp.Data
open System

let wb = WorldBankData.GetDataContext()
let ireland = wb.Countries.Ireland

let outOfSchoolStats = wb.Countries.Ireland.Indicators.``Children out of school, primary, female``

let printDataForElement = fun value -> printf "\nYear: %d Value:%f" (fst value) (snd value)
outOfSchoolStats
    |> Seq.filter(fun(value) -> (fst value) > 2008)
    |> Seq.iter printDataForElement





