#============================
# Exploring the network structure
#============================
# We load the social network again

library(igraph)
library(magrittr)

# Load the csv data
edgeList <- 
  read.csv("../data/edgeList_episode7.csv", header=F, stringsAsFactors=F) %>% 
  as.character

# Creating an undirected graph from the list of edges
g <- graph(edgeList, directed = FALSE)

#---------------
# 