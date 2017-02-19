module CakeConsole.Library

open System
open CakeConsole.Executor
open CakeConsole.Parser

type TaskName = TaskName of string

type Message =
    | Info of string
    | Option of string
    | Prompt of string
    | Description of string

let os = Environment.OSVersion.Platform

let write = function 
    | Info message ->
        Console.ForegroundColor <- ConsoleColor.Green
        Console.WriteLine message
    | Prompt message ->
        Console.ForegroundColor <- ConsoleColor.Red
        Console.Write message
        Console.ForegroundColor <- ConsoleColor.Yellow
    | Description message ->
        Console.ForegroundColor <- ConsoleColor.White
        Console.WriteLine message
    | Option message ->
        Console.ForegroundColor <- ConsoleColor.Green
        Console.Write message 

let readInput (message:string) (options:(string) list) =
    let f = sprintf

    write <| Info(message)

    let mutable index = 1

    for v in options do
        write <| Option(f " %-3d" index)
        write <| Description(f "%s" v)
        index <- index + 1

    write <| Prompt("> ")
    let ok, index = Int32.TryParse <| Console.ReadLine()
    match ok with
    | true ->
        if index <= options.Length then
            options.[index - 1] |> Some 
        else None
    | false ->
        None

let rec getTask() =
    let f = sprintf
    let tasks = parseFile(System.IO.FileInfo("build.cake"))
    let options = 
        seq {
            for task in tasks do
                yield (task)
        } |> Seq.toList
        
    let task = readInput "Select task" options
    let execute cmd args =
        write <| Info(f " %s %s" cmd args)
        executeCommand cmd args
        getTask()

    match task with
    | Some name -> 
        match os with
        | PlatformID.MacOSX | PlatformID.Unix ->
            let cmd = "./build.sh"
            let args = sprintf "--target %s" name
            execute cmd args
        | _ -> 
            let cmd = "powershell"
            let args = "-ExecutionPolicy ByPass -File build.ps1 -target " + name
            execute cmd args
    | None -> getTask() 
