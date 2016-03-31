#I "packages/FSharp.Data/lib/net40"
#r "FSharp.Data.dll"

open System
open System.IO
open FSharp.Data

// Load JSON data & export it into a format that igraph accepts

type Network = JsonProvider<"../data/network.json">
let network = Network.Load("../data/network.json")

// node dictionary
let names = [| for n in network.Nodes -> n.Name |]

let edges = 
    network.Links
    |> Array.collect (fun link -> 
        let idx1 = link.Source
        let idx2 = link.Target
        [| names.[idx1]; names.[idx2] |])
    |> String.concat ","

File.WriteAllLines(__SOURCE_DIRECTORY__ + "/../data/edgelist.csv", [| edges; "" |])
