#I "packages/FSharp.Data/lib/net40"
#I "packages/XPlot.GoogleCharts/lib/net45"
#I "packages/Google.DataTable.Net.Wrapper/lib"
#I "packages/Newtonsoft.Json/lib/net40"
#I "packages/Suave/lib/net40"

#r "FSharp.Data.dll"
#r "XPlot.GoogleCharts.dll"
#r "Google.DataTable.Net.Wrapper.dll"
#r "Newtonsoft.Json.dll"
#r "Suave.dll"

open XPlot.GoogleCharts

open Suave
let charts = ResizeArray<string>()
let app = Filters.pathScan "/%d" (fun n -> Successful.OK charts.[n])
let cfg = { defaultConfig with bindings = [ HttpBinding.mkSimple Suave.Http.HTTP "127.0.0.1" 8042 ] }
let _, start = startWebServerAsync cfg app
Async.Start(start)

fsi.AddPrinter(fun (ch:XPlot.GoogleCharts.GoogleChart) ->
    charts.Add(ch.Html)
    let url = sprintf "http://localhost:8042/%d" (charts.Count - 1)
    System.Diagnostics.Process.Start(url) |> ignore
    "(GoogleChart)")

module Array = 
  let take n (arr:'T[]) = arr.[0 .. n-1] 
  let skip n (arr:'T[]) = arr.[n ..]

let __<'T> : 'T = failwith "Fill the placeholder!"