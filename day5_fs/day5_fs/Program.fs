// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO


let readFile (filePath:String) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
} 

let toId (s:String) : int =
    let to_digit c = if c = 'R' or c = 'B' then 1 else 0 
    s |> Seq.map to_digit |> Seq.fold (fun num digit -> (num*2)+digit) 0

let findFreeSeat (takenSeats:Set<int>) =
    { takenSeats |> Seq.min .. takenSeats |> Seq.max }
        |> Seq.filter (fun x -> takenSeats.Contains x |> not) |> Seq.head 

[<EntryPoint>]
let main argv =
    let pws =  "/Users/xeno/projects/aoc2020/day5_fs/input.txt"
    let input = readFile pws |> Seq.toArray
    let takenSeats = input |> Seq.map toId |> Set.ofSeq
    let freeSeat = takenSeats |> findFreeSeat 
    printfn "Answer 1 %d" (takenSeats |> Seq.max) 
    printfn "Answer 2 %d" freeSeat  
    0 // return an integer exit code