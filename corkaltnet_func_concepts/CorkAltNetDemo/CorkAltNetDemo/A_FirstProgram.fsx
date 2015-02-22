// Analyze a string for duplicate words
let wordCount (text:string) =
    let words = text.Split [|' '|]
    let wordSet = Set.ofArray words
    let nWords = words.Length
    let nDups = words.Length - wordSet.Count
    (nWords,nDups)

let showWordCount text =
    let nWords,nDups = wordCount text
    printfn "--> %d words in the text" nWords
    printfn "--> %d duplicate words" nDups

// let keyword
// immutability
// function definitions
// spacing defines scope
// tuples
// sets, arrays
// explicit/implicit typing
// comments







let (nWords,nDups) = wordCount "All the king's horses and all the king's men";;
nWords;;
nDups;;
nWords - nDups;;
showWordCount "Couldn't put Humpty together again";;