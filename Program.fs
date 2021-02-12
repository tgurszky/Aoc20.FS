// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

[<EntryPoint>]
let main argv =  
    Day8.parseInput Day8.testInput
    |> Day8.solve2
    |> printfn "The solution is %A"
    0 // return an integer exit code
