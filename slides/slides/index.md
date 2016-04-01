- title : Polyglot data science
- description : Polyglot data science with F#, R and D3.js
- author : Evelina Gabasova
- theme : white
- transition : none

***

# Polyglot data science
# <div class="sw"> the force awakens </div>
## with F#, R and D3.js

- Evelina Gabasova **@evelgab**
- Tomas Petricek **@tomaspetricek**

********

# Part I
## F# with type providers

--------

...

---------

# Visualization with Google Charts


<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">
                google.load("visualization", "1", {packages:["corechart"]})
                google.setOnLoadCallback(drawChart);
            function drawChart() {
                var data = new google.visualization.DataTable({"cols": [{"type": "string" ,"id": "Title" ,"label": "Title" }, {"type": "number" ,"id": "Year" ,"label": "Year" }, {"type": "number" ,"id": "Box office" ,"label": "Box office" }, {"type": "number" ,"id": "Rating" ,"label": "Rating" }, {"type": "number" ,"id": "Budget" ,"label": "Budget" }], "rows" : [{"c" : [{"v": "Star Wars"}, {"v": 1977}, {"v": 775398007}, {"v": 94}, {"v": 11000000}]}, {"c" : [{"v": "The Empire Strikes Back"}, {"v": 1980}, {"v": 538375067}, {"v": 94}, {"v": 22000000}]}, {"c" : [{"v": "Return of the Jedi"}, {"v": 1983}, {"v": 475106177}, {"v": 80}, {"v": 37600000}]}, {"c" : [{"v": "Episode I - The Phantom Menace"}, {"v": 1999}, {"v": 1027044677}, {"v": 56}, {"v": 115000000}]}, {"c" : [{"v": "Episode II - Attack of the Clones"}, {"v": 2002}, {"v": 649398328}, {"v": 66}, {"v": 115000000}]}, {"c" : [{"v": "Episode III - Revenge of the Sith"}, {"v": 2005}, {"v": 848754768}, {"v": 79}, {"v": 113000000}]}, {"c" : [{"v": "Star Wars: The Clone Wars"}, {"v": 2008}, {"v": 68282844}, {"v": 18}, {"v": 8500000}]}, {"c" : [{"v": "Star Wars: The Force Awakens"}, {"v": 2015}, {"v": 2058323187}, {"v": 92}, {"v": 200000000}]}]});
                var options = {"colors":["red","gold"],"hAxis":{"title":"Year","viewWindowMode":"explicit","viewWindow":{"max":2020,"min":1975}},"legend":{"position":"none"},"title":"Star Wars - rating and box office","vAxis":{"title":"Box office"},"bubble":{"textStyle":{"color":"transparent"}},"width":1000,"height":600} 
                var chart = new google.visualization.BubbleChart(document.getElementById('b46bd5ac-5b6c-4725-a5b8-6d2114a04922'));
                chart.draw(data, options);
            }
            </script>
<div id="b46bd5ac-5b6c-4725-a5b8-6d2114a04922" style="width: 1100px; height: 600px"></div>

*********

# Part II
## Analyzing social networks with R

--------

# Social network analysis

* Who is the most central character?
* How to the movies compare between themselves?

-----
# Degree
![Network](images/network-basic.png)

-----
# Degree
![Degree](images/degree1.png)

-----
# Degree
![Degree](images/degree2.png)

------
# Degree

<br />

$$$
\text{Degree}(v) = \text{Number of links }v \leftrightarrow v' \\
v \neq v'

-----
# Betweenness
![Betweenness](images/network-basic.png)

-----
# Betweenness
![Betweenness](images/betweenness1.png)

-----
# Betweenness
![Betweenness](images/betweenness2.png)

-----
# Betweenness
![Betweenness](images/betweenness3.png)

-----
# Betweenness
![Betweenness](images/betweenness4.png)

-----
# Betweenness

<br />

$$$
S_v = \text{Number of shortest paths between $a$ and $b$ through $v$} \\
S = \text{Number of shortest paths between $a$ and $b$} \\ \\
\text{Betweenness}(v)_{ab} = \frac{S_v}{S}

-----
# Betweenness

<br />

$$$
S_v = \text{Number of shortest paths between $a$ and $b$ through $v$} \\
S = \text{Number of shortest paths between $a$ and $b$} \\ \\
\text{Betweenness}(v) = \sum_{ab} \frac{S_v}{S}

-----
# Network structure

How do the the movies differ?

- Size
- Density
- Clustering coefficient


-----
- data-background : images/senate.jpeg

-----
# Density
![Network](images/network-basic.png)

-----
# Density
![Network](images/full.png)

-----
# Density

<br />

$$$
\begin{align}
\text{Density} &= \frac{\text{Existing connections}}{\text{Potential connections}} \\
& \\
&= \frac{\text{Existing connections}}{\frac{1}{2}N(N-1)}
\end{align}

-----
# Clustering coefficient
![Network](images/network-basic.png)

-----
# Clustering coefficient
![Clustering](images/clustering1.png)

-----
# Clustering coefficient
![Clustering](images/clustering2.png)

-----
# Clustering coefficient
![Clustering](images/clustering3.png)

-----
# Clustering coefficient
![Clustering](images/clustering4.png)

-----
# Clustering coefficient
![Clustering](images/clustering5.png)

-----
# Clustering coefficient

<br />

$$$
K_v = \text{Number of neighbours of $v$} \\
E_v = \text{Number of links between neighbours of $v$} \\ \\
\text{Clustering}(v) = \frac{E_v}{\frac{1}{2} K_v (K_v - 1)}

-----
# Clustering coefficient

<br />

$$$
K_v = \text{Number of neighbours of $v$} \\
E_v = \text{Number of links between neighbours of $v$} \\ \\
\text{Clustering}(\text{network}) = \frac{1}{N} \sum_v \frac{E_v}{\frac{1}{2}  K_v (K_v - 1)}


-------

# The R language

![](images/Rlogo.png)

- "domain-specific" language for statistical analysis

-----

# Very quick R intro

    [lang=R]
    # assignment
    x <- 1
    x = 1

    # variable and function names
    x
    x.y
    read.csv

-----

# Very quick R intro: pipeline
## |> turns into %>%

    [lang=R]
    install.packages("magrittr")
    library(magrittr)

    xs <- c(1,2,3,4,5,6,7,8,9,10)
    xs %>% mean

-----

# Network analysis with igraph

- [igraph website](http://igraph.org/r/)
- [igraph documentation](http://igraph.org/r/doc/)


    [lang=R]
    install.packages("igraph")
    library(igraph)

-----

# Creating igraph network

    [lang=R]
    library(igraph)

    g <- graph(edges)

- edges    


-----

# Calculating degree

    [lang=R]

    d <- degree(graph)


-----
- data-background : #212d30

# F#

    open RProvider.igraph

    let centrality = R.betweenness(network)


-----
# <div class="sw"> Size </div>

<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">
    google.load("visualization", "1", {packages:["corechart"]})
    google.setOnLoadCallback(drawChart);
function drawChart() {
    var data = new google.visualization.DataTable({"cols": [{"type": "string" ,"id": "Column 1" ,"label": "Column 1" }, {"type": "number" ,"id": "Column 2" ,"label": "Column 2" }], "rows" : [{"c" : [{"v": "Episode 1"}, {"v": 38}]}, {"c" : [{"v": "Episode 2"}, {"v": 33}]}, {"c" : [{"v": "Episode 3"}, {"v": 25}]}, {"c" : [{"v": "Episode 4"}, {"v": 22}]}, {"c" : [{"v": "Episode 5"}, {"v": 21}]}, {"c" : [{"v": "Episode 6"}, {"v": 20}]}, {"c" : [{"v": "Episode 7"}, {"v": 27}]}]});
    var options = {"colors":["#c43b80"],"hAxis":{"title":"Number of characters","viewWindowMode":"explicit","viewWindow":{"max":40,"min":0}},"legend":{"position":"none"},"title":"Number of characters","width":1000,"height":600} 
    var chart = new google.visualization.BarChart(document.getElementById('55ec49cf-f2ee-4e40-ad93-2fb5e6943f7b'));
    chart.draw(data, options);
}
</script>
<div id="55ec49cf-f2ee-4e40-ad93-2fb5e6943f7b" style="width: 1200px; height: 600px"></div>

-----
# <div class="sw"> Density </div>

<script type="text/javascript">
    google.load("visualization", "1", {packages:["corechart"]})
    google.setOnLoadCallback(drawChart);
function drawChart() {
    var data = new google.visualization.DataTable({"cols": [{"type": "string" ,"id": "Column 1" ,"label": "Column 1" }, {"type": "number" ,"id": "Column 2" ,"label": "Column 2" }], "rows" : [{"c" : [{"v": "Episode 1"}, {"v": 19.203413940256}]}, {"c" : [{"v": "Episode 2"}, {"v": 19.1287878787879}]}, {"c" : [{"v": "Episode 3"}, {"v": 25.6916996047431}]}, {"c" : [{"v": "Episode 4"}, {"v": 28.5714285714286}]}, {"c" : [{"v": "Episode 5"}, {"v": 26.1904761904762}]}, {"c" : [{"v": "Episode 6"}, {"v": 32.1637426900585}]}, {"c" : [{"v": "Episode 7"}, {"v": 26.2108262108262}]}]});
    var options = {"colors":["#3bc4c4"],"hAxis":{"title":"Density (%)","viewWindowMode":"explicit","viewWindow":{"max":35,"min":15}},"legend":{"position":"none"},"title":"Network density","width":1000,"height":600} 
    var chart = new google.visualization.BarChart(document.getElementById('b1a450b2-9caf-44f9-9db5-323fcf91f58c'));
    chart.draw(data, options);
}
</script>
<div id="b1a450b2-9caf-44f9-9db5-323fcf91f58c" style="width: 1200px; height: 600px"></div>

--------

# <div class="sw"> Clustering coefficient </div>

<script type="text/javascript">
    google.setOnLoadCallback(drawChart);
function drawChart() {
    var data = new google.visualization.DataTable({"cols": [{"type": "string" ,"id": "Column 1" ,"label": "Column 1" }, {"type": "number" ,"id": "Column 2" ,"label": "Column 2" }], "rows" : [{"c" : [{"v": "Episode 1"}, {"v": 0.447572132301196}]}, {"c" : [{"v": "Episode 2"}, {"v": 0.486666666666667}]}, {"c" : [{"v": "Episode 3"}, {"v": 0.498947368421053}]}, {"c" : [{"v": "Episode 4"}, {"v": 0.559808612440191}]}, {"c" : [{"v": "Episode 5"}, {"v": 0.604651162790698}]}, {"c" : [{"v": "Episode 6"}, {"v": 0.656992084432718}]}, {"c" : [{"v": "Episode 7"}, {"v": 0.588387096774194}]}]});
    var options = {"hAxis":{"title":"Clustering coefficient"},"legend":{"position":"none"},"title":"Clustering coefficient (transitivity)","width":1000,"height":600} 
    var chart = new google.visualization.BarChart(document.getElementById('a84d0fe6-8cc8-4351-a397-114a1bc9ff0c'));
    chart.draw(data, options);
}
</script>
<div id="a84d0fe6-8cc8-4351-a397-114a1bc9ff0c" style="width: 1200px; height: 600px"></div>

********

# Part III
## Visualization with D3.js

--------

![](images/d3js.png)

--------
# D3.js visualizations
## made easier

[Gallery of examples](https://github.com/mbostock/d3/wiki/Gallery)

--------

# D3.js social network visualization

[Force-directed network layout](http://bl.ocks.org/mbostock/4062045)

--------

- data-background : images/kyloapproves-loop3.gif
