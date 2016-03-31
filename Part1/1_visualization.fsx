#load "setup.fsx"
open Setup
open System
open FSharp.Data
open XPlot.GoogleCharts

// ----------------------------------------------------------------------------
// PART 1: DEMO - Using HTML type provider for parsing tables 
// ----------------------------------------------------------------------------

type Brazil = HtmlProvider<"https://en.wikipedia.org/wiki/States_of_Brazil">
let brazil = Brazil.GetSample()

// Print the names and capitals of all states
for state in brazil.Tables.``List of Brazilian states``.Rows do
  printfn "%s (%s)" state.State state.Capital

// Data is never nice - look at the numeric format!
for state in brazil.Tables.``List of Brazilian states``.Rows do
  printfn "%s (%s)" state.State state.``Population (2014)``

// Helper to parse the US numerical format after the '♠' symbol
let parseNumber (td:string) = 
  let num = td.Split('♠').[1]
  Double.Parse(num, Globalization.CultureInfo.GetCultureInfo("en-US"))

// Take state and population, sort states by the second
let bigStates = 
  brazil.Tables.``List of Brazilian states``.Rows 
  |> Array.map (fun row -> row.State, parseNumber row.``Population (2014)``)
  |> Array.sortBy (fun (state, population) -> -population)

// Draw a column chart with top 5 states by size
bigStates
|> Array.take 5
|> Chart.Column

// TODO: Modify the code to show the richest states (by GDP per capita)
// TODO: Modify the code to show the largest states (by Area in km2)


// ----------------------------------------------------------------------------
// PART 2: DEMO - Helper functions to do the parsing for you!
// ----------------------------------------------------------------------------

/// Drops useless hidden characters from the end of a movie title
let parseTitle (title: string) = 
    title.TrimEnd("[]01234567890".ToCharArray())

/// Drops the $ sign and parses the string as a number
let parseGross (text: string) =
    let text' = text.Trim (" $".ToCharArray())
    Double.Parse(text', Globalization.CultureInfo.GetCultureInfo("en-us"))

/// Gets the middle of a range, e.g. "$10 million - $15 million" becomes 12500000.0
let parseBudget (text: string) = 
    let text' = text.ToLower().Replace("million","")
    text'.Split [|'-'|]
    |> Array.map parseGross
    |> Array.map (fun x -> x * 1000000.0)
    |> Array.average

/// Converts rating such as "95% (100 reviews)" into the percentage number
let parseRating (text: string) = 
    text.[0..text.IndexOf('%')-1] |> float

/// Extract the year from a date in a format "December 18, 2016"
let parseYear (date: string) = 
    DateTime.Parse(date).Year

// ----------------------------------------------------------------------------
// PART 3: TASK - Visualize information about Star Wars films!
// ----------------------------------------------------------------------------

// Use HtmlProvider with "https://en.wikipedia.org/w/index.php?title=Star_Wars&oldid=712371304"
// URL as a sample to define a type "WikiProvider" and get the tables!
//
// First, we will need the "Box office performance" table with budget data
// Later, you will need the "Critical and public response" table too
//
// Print the names of all the movies from "Box office performance"

for row in __ do
  printfn "Movie name: %s" __


// The table contains 'totals' too - we do not want this! Filter 
// the rows using 'Array.filter' and drop all the rows where
// the film name contains the word "total". You can check this using:

let demo = "Some total"
demo.EndsWith("total")
not (demo.EndsWith("total"))


// The first row from the table is the row with headers, so we want
// to drop it too. You can use 'Array.skip n' to skip the first n items.
// Store the 'good' rows in a new value named 'movieRows' like this:

let movieRows = 
  __


// Draw a column chart with budget for each movie and box office 
// ('Box office gross 3' is the data for the whole world)

[ ("Yes", 100.0); ("No", 4.0) ]
|> Chart.Column


// Draw a bubble chart! For this you will need to use 'Array.map'
// to produce 4 element tuple with film name, release date, box office gross 3
// and budget. Use the helpers (parseTitle, parseYear, parseGross and parseBudget)
// We can also add labels using Chart.WithLabels

[ ("Star Wars", 1977, 775398007, 11000000) ]
|> Chart.Bubble
|> Chart.WithLabels(["Title"; "Year"; "Box office"; "Budget"])

// ----------------------------------------------------------------------------
// PART 4: TASK - Add ranking to the bubble chart
// ----------------------------------------------------------------------------

// Use the "Critical and public response" table to get Rotten Tomatoes
// ratings for all movies. We only need the first 8 rows, so use
// 'Array.take 8' to get only the relevant data.

let ratingRows =
  __


// Now we need to combine 8 movieRows with 8 ratingRows. The way to do this
// is to use 'Array.zip'. This takes two arrays and creates a new one that
// contains tuples with 1st elements of the two arrays, 2nd elements, 3rd 
// elements and so on. For example:

let one = [| 1; 2; 3 |]
let two = [| "one"; "two"; "three" |]

// Combine the two arrays
Array.zip one two

// Transform combined array using map
Array.zip one two
|> Array.map (fun (num, str) ->
    sprintf "(%d) %s" num str)

// Now, combine movieRows with ratingRows and pass a 5-element tuple to the
// bubble chart containing the following data: Film name, Release date, 
// Box office gross 3, Rotten Tomatoes rating, Budget. 
// (Use the 'parseRating' function to get the rating!)
Array.zip one two
|> Array.map __

// Add the following labels to make the chart nicer:
// ["Title"; "Year"; "Box office"; "Rating"; "Budget"])

// ----------------------------------------------------------------------------
// PART 5: DEMO - Tweaking the chart options
// ----------------------------------------------------------------------------

// You can configure the chart to make it much nicer by creating
// 'Options' and specifying it using 'WithOptions'. Here, we set the
// min and max ranges for horizontal axis, labels, and colours for rating 
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

// Just put the data from the last part here :-)

[ ("Star Wars", 1977, 775398007, 11000000) ]
|> Chart.Bubble
|> Chart.WithLabels(["Title"; "Year"; "Box office"; "Rating"; "Budget"])
|> Chart.WithOptions(options)

// ----------------------------------------------------------------------------
// PART 6: BONUS - A couple of bonus problems for those who finish early!
// ----------------------------------------------------------------------------

// TASK 1: Compare the budget and box office (income) by creating a 
// column chart with two different data sets. A simple example is:

let data1 = [| ("Yes", 43.0); ("No", 27.0) |]
let data2 = [| ("Yes", 38.0); ("No", 32.0) |]

[ data1; data2 ]
|> Chart.Column


// TASK 2: Create a bubble chart with information about the states of Brazil!
// Experiment with different visualization - you can for example try using
// state name, population and area for the X and Y axes and GDP per capita
// (how rich is the state) for the bubble size.
// Use the HtmlProvider with "https://en.wikipedia.org/wiki/States_of_Brazil".


// TASK #3: If you don't like Star Wars, try James Bond instead :-) 
// "https://en.wikipedia.org/w/index.php?title=List_of_James_Bond_films&oldid=688916363"
// This is more work, because you'll need to modify the parsing functions too,
// but it is a fun project if you want to continue playing with F# at home!