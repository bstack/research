// partial application
let add x y = x + y;;
let incrementBy10 = add 10

// type inference
let i  = 1
let s = "hello"
let tuple  = s,i      // pack into tuple  
let s2,i2  = tuple    // unpack
let list = [s2]




type Student = { Id:int;Username:string;Password:string };;

type LoginResult = 
  | Success of Student
  | DoesNotExist of string
  | TechnicalFailure


let processLogin username password getStudentFromDb =
    try
        match getStudentFromDb username password with
        | Some(student) -> student |> LoginResult.Success
        | None -> "No sign of this student record in db" |> LoginResult.DoesNotExist
    with
        | _ -> LoginResult.TechnicalFailure

let getStudentFromDbExists _ _ = {Id=1;Username="bstack";Password="pass"} |> Some
let getStudentFromDbNotExists _ _ = None
let getStudentFromDbThrowsEx _ _ = failwith "Db unreachable"

let res1 = processLogin "bstack" "pass" getStudentFromDbExists;;
let res2 = processLogin "bstack" "pass" getStudentFromDbNotExists;;
let res3 = processLogin "bstack" "pass" getStudentFromDbThrowsEx;;