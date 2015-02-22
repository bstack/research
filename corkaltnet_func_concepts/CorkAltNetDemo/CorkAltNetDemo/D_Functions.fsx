// STEP 1: building blocks
let add2 x = x + 2
let mult3 x = x * 3
let square x = x * x


// STEP 2: pipelining lists into functions
[1..10] |> List.map add2 |> printfn "%A"
[1..10] |> List.map mult3 |> printfn "%A"
[1..10] |> List.map square |> printfn "%A"


//  STEP 3: create new functions composed of the functions above (>> = composition operator)
let add2ThenMult3 = add2 >> mult3
let mult3ThenSquare = mult3 >> square 

// could have been written as this
//let add2ThenMult3 x = mult3 (add2 x)
//let mult3ThenSquare x = square (mult3 x) 

// test it
add2ThenMult3 5
mult3ThenSquare 5


// STEP 4: extending existing functions
let logMsg msg x = printf "%s%i" msg x; x     //without linefeed 
let logMsgN msg x = printfn "%s%i" msg x; x
let mult3ThenSquareLogged = 
   logMsg "before=" 
   >> mult3 
   >> logMsg " after mult3=" 
   >> square
   >> logMsgN " result="

mult3ThenSquareLogged 5
[1..10] |> List.map mult3ThenSquareLogged //apply to a whole list


// STEP 5: can do this instead
let listOfFunctions = [
   mult3; 
   square;
   add2;
   logMsgN "result=";
   ]

// compose all functions in the list into a single one
let allFunctions = List.reduce (>>) listOfFunctions 

//test
allFunctions 5


// demo partial application
let add x y = x + y

let add42 = add 42

add42 2