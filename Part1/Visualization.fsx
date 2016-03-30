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
open System
open FSharp.Data
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

[<Literal>]
let starWarsUrl = 
    "https://en.wikipedia.org/w/index.php?title=Star_Wars&oldid=712371304"

// if you don't like Star Wars, try James Bond instead :-) 
// "https://en.wikipedia.org/w/index.php?title=List_of_James_Bond_films&oldid=688916363"

type WikiProvider = HtmlProvider<starWarsUrl>
let wiki = WikiProvider.Load(starWarsUrl)

// We can explore elements of the HTML document
wiki.Tables.``Box office performance``

// helper parsing functions
let parseTitle (title: string) = 
    title.TrimEnd ("[]01234567890".ToCharArray())

let parseCurrency (text: string) =
    let text' = text.Trim (" $".ToCharArray())
    Double.Parse(text', Globalization.CultureInfo.GetCultureInfo("en-us"))

let parseBudget (text: string) = 
    let text' = text.ToLower().Replace("million","")
    text'.Split [|'-'|]
    |> Array.map parseCurrency
    |> Array.map (fun x -> x * 1000000.0)
    |> Array.average

let parseRating (text: string) = 
    text.[0..text.IndexOf('%')-1] |> float

// Extract data from the table
let year = 
    wiki.Tables.``Box office performance``.Rows
    |> Array.map (fun row -> row.``Release date``)
    |> Array.skip 1
    |> Array.map (fun date -> 
        try 
            DateTime.Parse(date).Year |> Some
        with e ->
            None)
            
let titles = 
    wiki.Tables.``Box office performance``.Rows
    |> Array.map (fun r -> r.Film)
    |> Array.skip 1
    |> Array.map parseTitle

let boxOffice = 
    wiki.Tables.``Box office performance``.Rows
    |> Array.map (fun r -> r.``Box office gross 3``)
    |> Array.skip 1
    |> Array.map parseCurrency

let budget = 
    wiki.Tables.``Box office performance``.Rows
    |> Array.map (fun r -> r.Budget)
    |> Array.skip 1
    |> Array.map parseBudget

// get rating
let rating = 
   wiki.Tables.``Critical and public response``.Rows
   |> Array.map (fun r -> r.``Rotten Tomatoes``)
   |> Array.take 8
   |> Array.map parseRating

// putting the data together
let data = 
    [| for i in 0..titles.Length-1 do
        match year.[i] with
        | Some y -> 
            yield titles.[i], y, boxOffice.[i], budget.[i]
        | None -> () |]
    |> Array.mapi (fun i (t, y, bo, bg) -> t, y, bo, rating.[i], bg)

data
|> Chart.Bubble
|> Chart.WithLabels(["Title"; "Year"; "Box office"; "Rating"; "Budget"])

// nicer version 
let options =
    Options(
        title = "Star Wars - rating and box office",
        hAxis = Axis(title = "Year",
            viewWindowMode = "explicit", 
            viewWindow = ViewWindow(min = 1975, max = 2020)),
        vAxis = Axis(title = "Box office"),
        bubble = Bubble(textStyle=TextStyle(color="transparent")),
        colors = [| "red"; "gold" |]
    )

data
|> Chart.Bubble
|> Chart.WithLabels(["Title"; "Year"; "Box office"; "Rating"; "Budget"])
|> Chart.WithOptions(options)
