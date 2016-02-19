// Declare 'the fish' monad
// (>=>)::(a' -> b * bool) -> (b -> c * bool) -> a -> (c * bool)
let (>=>) m1 m2 x =
    let (y, result1) = m1 x
    let (z, result2) = m2 y
    (z, result1 && result2)


// safeRoot::float option -> float option * bool
let safeRoot x = 
    match x with
    | Some(x) -> 
        match x > 0.0 with
        | true -> (x |> System.Math.Sqrt |> Some, true)
        | false -> (None, false)
    | None -> (None, false)

// safeReciprocal::float option -> float option * bool
let safeReciprocal x =
    let calcReciprocal num = ((1 |> float) / num)
    match x with
    | Some(x) -> (x |> calcReciprocal |> Some, true)
    | None -> (None, false)

// identity::a' option -> a' option * bool
let identity x =
    match x with
    | Some(x) -> (Some(x), true)
    | None -> (None, true)


// Define new functions utilising 'the fish' monad
let safeRootReciprocal =  safeRoot >=> safeReciprocal
let testIdentity = safeRootReciprocal >=> identity

// Test, valid scenario
let (x, y) = (25.0 |> Some |> safeRootReciprocal)
let (x, y) = (25.0 |> Some |> testIdentity)

// Test, invalid scenario
let (x, y) = (25.0 |> Some |> safeRootReciprocal)
let (x, y) = (25.0 |> Some |> testIdentity)
