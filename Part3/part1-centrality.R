#======================================================
# Polyglot data science: The Force Awakens
# Part II: Social network analysis with R
#======================================================
# Run the code in the console by highlighting it and pressing Ctrl Enter
# or by copying it into the console directly

# Prerequisites:
# Set working directory to the source code directory:

# TODO: Update the location
setwd("~/Projects/PolyglotDataScience/Part3")

# Install the necessary packages
install.packages("magrittr")
install.packages("igraph")

#======================================================
# Load the libraries
library(igraph)
library(magrittr)

# Load the csv data
edgeList <- 
  read.csv("../data/edgelist7.csv", header=F, stringsAsFactors=F) %>% 
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

# TODO: what is the average degree? Use the function 'mean' to find out


# TODO: Use the function 'summary' to get statistical summary of the values


# TODO: Plot the degree values with the function 'plot'


# TODO: Look into the documentation for the 'plot' function and change the default 
# plot into a histogram-like vertical lines plot


# TODO: Use the function 'sort' to sort the degrees - who is the most central character?


# TODO: Look at the documentation for the 'sort' function and sort the degrees in the
# decreasing order


#---------------
# Computing other network measures
#--------------

# Betweenness 
# TODO: search the igraph documentation to find the function to compute
# betweenness in a network
# http://igraph.org/r/doc/


# TODO: Who has the largest betweenness? 
# How does the order of characters differ?


# TODO: Plot the betweenness distribution 
# - how is it different from the degree distribution?


#--------------
# Bonus questions
#--------------
# Other measure of centrality is the PageRank. How can we compute it using the igraph 
# package? 

# Who has the largest PageRank? You can access individual elements of the 
# results using the $ operator


# Export networks for other episodes into lists of edges 
# and repeat the analysis. Who is the most central character in the original 
# Episode IV? And who is the most central in the prequel Episode I?





