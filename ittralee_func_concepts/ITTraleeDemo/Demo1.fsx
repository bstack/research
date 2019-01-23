let f x = 3 * x + 2;;

let g x = 4-5 * x;;

// composition
let fg = f >> g;;

// pipelining
let res = 2 |> f |> g;;

fg 2;;


// higher order functions, functions being passed as parameters
let doSomething (x:int) (y:int) operator = operator x y;;

let multiplyOperator = (*);;
let additionOperator = (+);;


let addTwoNums x y = doSomething x y additionOperator;;
addTwoNums 3 5;;

let multTwoNums x y = doSomething x y multiplyOperator;;
multTwoNums 3 5;;


// functions being retured from functions
let genFunc x y dir =
    match dir with
    | "MULT" -> fun x y -> x*y
    | _ -> fun x y -> x+y

let generatedMultFunc x y = genFunc x y "MULT"
generatedMultFunc

// immutability
let x  = 10;
x = 11;;
x <- 11;;
let mutable x = 10;;