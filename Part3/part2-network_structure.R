#============================
# Exploring the network structure
#============================
# We load the social network again

library(igraph)
library(magrittr)

# TODO: Update the location
setwd("~/Projects/PolyglotDataScience/Part3")


# Load the csv data
edgeList <- 
  read.csv("../data/edgelist7.csv", header=F, stringsAsFactors=F) %>% 
  as.character

# Creating an undirected graph from the list of edges
g <- graph(edgeList, directed = FALSE)

#---------------
# Network density
#---------------



graph.density(g)
