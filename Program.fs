// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

[<EntryPoint>]
let main argv =  
    Day7.parseRules 1 Day7.input
    |> Day7.parentCount "shinygold"
    |> printfn "The solution is %i"
    0 // return an integer exit code
