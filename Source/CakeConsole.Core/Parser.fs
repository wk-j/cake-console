module CakeConsole.Parser

open System.IO
open System.Linq
open System.Linq
open System


type Task =
    { Name: string
      Description: string }

let getContent (file: FileInfo) =
    match file.Exists with
    | true -> File.ReadAllLines file.FullName
    | false -> [||]

let rec parseFile (file:FileInfo) =
    let lines = getContent(file)
    let tasks =
        query {
            for line in lines do
            where (line.StartsWith("Task(\""))
            select (line.Trim())
        }

    let loads =
        query {
            for line in lines do
            where (line.StartsWith("#l"))
            let load =
              line.Replace("#load", String.Empty)
                .Replace("#l", String.Empty)
                .Replace("\"", String.Empty).Trim()
            select (load)
        }

    seq {
        for task in tasks do
            let name = task.Split('\"').[1]
            yield name

        for load in loads do
            let dir = file.Directory.FullName
            let path = Path.Combine(dir, load)
            let info = FileInfo(path)
            for task in parseFile(info) do
                yield task
    }
