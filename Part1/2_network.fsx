#I "packages/FSharp.Data/lib/net40"
#r "FSharp.Data.dll"

open System
open System.IO
open FSharp.Data

// ----------------------------------------------------------------------------
// PART 7: DEMO - Transform network data from JSON to CSV
// ----------------------------------------------------------------------------

// We have the social network data in a JSON file that is used by D3 for
// visualization, but we need to turn it into a CSV like format with individual
// links. To do this, we can read the data using JSON type provider.

type Network = JsonProvider<"../data/networkAll.json">
let network = Network.Load("../data/networkAll.json")

// Look at the file "networkAll.json" in the "data" folder to see what
// it looks like and type 'network.' to see the type inferred by the 
// JSON type provider!
network

// Get an array with all node names, so that we can find name based on index
let names = 
  network.Nodes 
  |> Array.map (fun n -> n.Name)

// Build an array with links - if we have A, B, C with links between A--B and B--C,
// we want to produce a single-line string "A,B,B,C" (yes, this is a bit odd!)
let edges = 
    network.Links
    |> Array.map (fun link -> 
        // Generate A,B for one link
        let idx1 = link.Source
        let idx2 = link.Target
        names.[idx1] + "," + names.[idx2])
        // Concatenate all links into one string
    |> String.concat ","

// Add new line at the end of the file and write it to the data folder
File.WriteAllLines(__SOURCE_DIRECTORY__ + "/../data/edgelist.csv", [| edges; "" |])

// TODO: Modify the code to do this separately for Episode 7
// (use the "data/network7.json" file and save it as "edgelist7.csv")
