#I @"packages/FAKE/tools/"
#I @"packages/Suave/lib/net40"
#r "FakeLib.dll"
#r "Suave.dll"

open Fake
open System.IO
open Suave
open Suave.Web
open Suave.Http
open Suave.Files
open Suave.Filters
open Suave.Operators
open System.Diagnostics

Target "Start" (fun _ ->
  let root = __SOURCE_DIRECTORY__ </> "web"
  
  let listing = request (fun _ ->
    let html =
      [ for f in Directory.GetFiles(root, "*.html") ->
          let fn = Path.GetFileName(f)
          sprintf "<li><a href='%s'>%s</a></li>" fn fn ]
      |> String.concat "\n"
    Successful.OK("<ul>" + html + "</ul>"))

  let app =
    choose
      [ path "/" >=> listing
        browseHome ]

  let port = 8045
  let serverConfig =
      { defaultConfig with
         homeFolder = Some (__SOURCE_DIRECTORY__ </> "web")
         bindings = [ HttpBinding.mkSimple HTTP "127.0.0.1" port ] }
  startWebServerAsync serverConfig app |> snd |> Async.Start
  Process.Start (sprintf "http://localhost:%d/" port) |> ignore
  System.Console.ReadLine() |> ignore
)

RunTargetOrDefault "Start"
