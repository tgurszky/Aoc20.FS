// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

[<EntryPoint>]
let main argv =  
    Day7.parseRules Day7.gatherParents Day7.input
    |> Day7.parentCount "shinygold"
    |> printfn "The solution is %i"
    0 // return an integer exit code
