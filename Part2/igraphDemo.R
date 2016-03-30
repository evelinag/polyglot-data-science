
setwd("~/Projects/PolyglotDataScience/Part2")
# install.packages("igraph")
library(igraph)
library(magrittr)

edgeList <- read.csv("../data/edgeList_episode7.csv", header=F, stringsAsFactors=F)  %>% as.character
g <- graph(edgeList, dir="undirected")
g <- graph(edgeList, directed = F)

# Computing degree
d = degree(g)
d %>% sort(decreasing = T)

# Computing betweenness
b = betweenness(g) 
b %>% sort(decreasing = T)

# Computing page rank
page_rank(g)$vector %>% sort(decreasing = T)

# Very simple community detection with a greedy algorithm
fc <- cluster_fast_greedy(g)
memb <- membership(fc)
memb[memb == 8]
