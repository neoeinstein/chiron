module ParsingAndFormatting

open Chiron
open BenchmarkDotNet.Attributes

[<Config(typeof<CoreConfig>)>]
type ParseBenchmark () =
    let mutable simpleStr = ""
    let mutable escapedStr = ""

    [<Params(10, 100, 1000, 10000, 100000)>]
    member val public strlen = 1 with get, set

    [<Setup>]
    member x.Setup () =
        let simple = String.replicate x.strlen "a"
        simpleStr <- "\"" + simple + "\""
        let escaped = String.replicate (x.strlen / 10) "\\u0004\\n\\\""
        escapedStr <- "\"" + escaped + "\""

    [<Benchmark>]
    member __.ParseSimple () =
        Json.parse simpleStr

    [<Benchmark>]
    member __.ParseEscaped () =
        Json.parse escapedStr

[<Config(typeof<CoreConfig>)>]
type FormatBenchmark () =
    let mutable simpleJson = Json.Null ()
    let mutable escapedJson = Json.Null ()

    [<Params(10, 100, 1000, 10000, 100000)>]
    member val public strlen = 1 with get, set

    [<Setup>]
    member x.Setup () =
        let simple = String.replicate x.strlen "a"
        simpleJson <- Json.String simple
        let escaped = String.replicate (x.strlen / 10) "\\u0004\\n\\\""
        escapedJson <- Json.String escaped

    [<Benchmark>]
    member __.FormatSimple () =
        Json.format simpleJson

    [<Benchmark>]
    member __.FormatEscaped () =
        Json.format escapedJson
