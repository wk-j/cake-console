module CakeConsole.Program

open CakeConsole.Library
open System.IO

[<EntryPoint>]
let main argv = 
    getTask() |> ignore
    0
