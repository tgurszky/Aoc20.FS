// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

[<EntryPoint>]
let main argv =  
    Day7.parseRules Day7.gatherChildren Day7.input
    |> Day7.childrenCount "shinygold"
    |> printfn "The solution is %i"
    0 // return an integer exit code
