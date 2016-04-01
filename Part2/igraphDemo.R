#======================================================
# Polyglot data science: The Force Awakens
# Part II: Social network analysis with R
#======================================================
# Run the code in the console by highlighting it and pressing Ctrl Enter
# or by copying it into the console directly

# Prerequisites:
# Set working directory to the source code directory:
setwd("~/Projects/PolyglotDataScience/Part2")

# Install the necessary packages
install.packages("magrittr")
install.packages("igraph")

#======================================================
# Load the libraries
library(igraph)
library(magrittr)

# Load the csv data
edgeList <- 
  read.csv("../data/edgeList_episode7.csv", header=F, stringsAsFactors=F) %>% 
  as.character

# Creating an undirected graph from the list of edges
g <- graph(edgeList, directed = FALSE)

# Computing degree in the network
d = degree(g)

#---------------
# Using common functions in R
#---------------
# get help on using the functions and their possible parameters by
# a) typing ?function into the console
# b) typing help(function) into the console
# c) searching in the Help viewer in Rstudio

# what is the average degree? Use the function 'mean' to find out
mean(d)

# Use the function 'summary' to get statistical summary of the values
summary(d)

# Plot the degree values with the function 'plot'
plot(d)

# Look into the documentation for the 'plot' function and change the default 
# plot into a histogram-like vertical lines plot
plot(d, type="h")

# Use the function 'sort' to sort the degrees - who is the most central character?
sort(d)

# Look at the documentation for the 'sort' function and sort the degrees in the
# decreasing order
sort(d, decreasing = TRUE) # or
d %>% sort(decreasing = TRUE)

#---------------
# Computing other network measures
#--------------
# Betweenness - search the igraph documentation to find the function to compute
# betweenness in a network
# http://igraph.org/r/doc/
b = betweenness(g) 

# Who has the largest betweenness? 
# How does the order of characters differ?
b %>% sort(decreasing = T)

# Plot the betweenness distribution 
# - how is it different from the degree distribution?
plot(b)

#--------------
# Bonus question
#--------------
# Other measure of centrality is the PageRank. Can we compute it using the igraph 
# package?
page_rank(g)$vector

# Export networks for other episodes into lists of edges 
# and repeat the analysis. Who is the most central character in the original 
# Episode IV? And who is the most central in the prequel Episode I?





