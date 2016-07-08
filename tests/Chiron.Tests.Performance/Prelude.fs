[<AutoOpen>]
module internal Prelude

open BenchmarkDotNet.Configs
open BenchmarkDotNet.Analysers
open BenchmarkDotNet.Diagnostics.Windows
open BenchmarkDotNet.Validators

type CoreConfig() =
    inherit ManualConfig()
    do
        base.Add(EnvironmentAnalyser.Default)
        base.Add(MemoryDiagnoser(), InliningDiagnoser())
        base.Add(JitOptimizationsValidator.FailOnError)
