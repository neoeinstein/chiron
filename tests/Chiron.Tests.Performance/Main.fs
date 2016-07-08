module Main

open BenchmarkDotNet.Running

type Dummy = Dummy

[<EntryPoint>]
let main argv =
    let switcher = BenchmarkSwitcher(typeof<Dummy>.Assembly)
    let summaries = switcher.Run argv
    0