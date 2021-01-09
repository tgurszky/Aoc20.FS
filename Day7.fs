module Day7

open FParsec

let testInput = "light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags."

let pWord = manySatisfy (System.Char.IsWhiteSpace >> not) .>> skipChar ' '
let pColor = pipe2 pWord pWord (+)
let pEmpty = stringReturn "no other bags." None
let pContain = tuple2 (pint32 .>> spaces) (pColor .>> (pstring "bags" <|> pstring "bag"))
let pEnd = (pchar ',' <|> pchar '.') .>> spaces
let pContains = many (pContain .>> pEnd) |>> Some

let pRule = (pColor .>> pstring "bags contain ") .>>. (pEmpty <|> pContains)

let trim (s: string) =
    s.Trim ()

let updateParents (ruleBook: Map<string, (int32 * string) list>) color colors =
    match Map.tryFind color ruleBook with
    | Some parents -> Map.remove color ruleBook
                      |> Map.add color (colors@parents)
    | None -> Map.add color colors ruleBook
    
let parseRule (ruleBook: Map<string, (int32 * string) list>) (rule: string) =
    match (run pRule rule) with
    | Success((color, Some colors), _, _) -> updateParents ruleBook color colors
    | Success ((color, None), _, _) -> ruleBook
    | Failure (e, _, _) -> ruleBook

let parseRules (input: string) =
    input.Split '\n'
    |> Array.map trim
    |> Array.fold parseRule Map.empty

// TODO: be kell jarni a teljes parent fat vagy itt, vagy amikor a ruleBook-ot epitjuk
let parentCount (color: string) (ruleBook: Map<string, (int32 * string) list>) =
    match Map.tryFind color ruleBook with
    | None -> 0
    | Some parents -> List.length parents