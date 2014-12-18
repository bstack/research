#nowarn "40"
let printerAgent = MailboxProcessor.Start(fun inbox-> 

    // the message processing function
    let rec messageLoop = async{
        
        // read a message
        let! msg = inbox.Receive()
        
        // process a message
        printfn "message is: %s" msg

        // loop to top
        return! messageLoop  
        }

    // start the loop 
    messageLoop 
    )

printerAgent.Post "hello" 
printerAgent.Post "hello again" 
printerAgent.Post "hello a third time" 


let agents =
    [ for i in 0 .. 100000 ->
       MailboxProcessor.Start(fun inbox ->
         async { while true do
                   let! msg = inbox.Receive()
                   if i % 10000 = 0 then
                       printfn "agent %d got message '%s'" i msg } ) ]
 
//You can send a message to each agent as follows:
for agent in agents do
    agent.Post "ping!"