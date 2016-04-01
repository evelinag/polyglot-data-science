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
# Size of the network
#---------------
# TODO: How many nodes and edges are in the network?
# You can use the 'summary' function, or look into the igraph documentation
# at http://igraph.org/r/doc/
# Note: nodes are also called vertices


#---------------
# Network density
#---------------
# TODO: Look into the igraph documentation and compute the network density


#--------------
# Clustering coefficient
#--------------
# TODO: Look into the igraph documentation and compute the clustering coefficient
# of the network. How interconnected is the structure of the graph?
# Note: Clustering coefficient is also called transitivity



#--------------
# Comparing the networks
#--------------

# You can write a for loop in R as follows:
results <- c()
for (i in 1:10) {
  results <- c(results, i)
}



# Compare networks for individual episodes
# - which network is the largest?
# - which network is the most dense?
# - which network has the largest clustering coefficient?




#--------------
# Bonus question
#--------------
# Visualize some of the statistics in a plot

