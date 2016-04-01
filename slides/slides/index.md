- title : Polyglot data science
- description : Polyglot data science with F#, R and D3.js
- author : Evelina Gabasova
- theme : white
- transition : none

***

# Polyglot data science
# <div class="sw"> the force awakens </div>
## with F#, R and D3.js

<br />

- Evelina Gabasova **@evelgab**
- Tomas Petricek **@tomaspetricek**

********

# Part I
## F# with type providers

---------

# [fslab.org](http://www.fslab.org): Doing data science using F#

The data science workflow

 - _Data access_ with type providers
 - _Interactive analysis_ with .NET and R libraries
 - _Visualization_ with HTML/PDF charts and reports

High-quality open-source libraries

<div style="margin-top:30px;margin-left:30px">
<img src="images/logo-fslab.png" style="width:150px;margin-right:20px;" />
<img src="images/logo-fsdata.png" style="width:150px;margin-right:20px;" />
<img src="images/logo-deedle.png" style="width:150px;margin-right:20px;" />
<img src="images/logo-rprovider.png" style="width:150px;margin-right:20px;" />
</div>

---------

# LINQ before it was cool :-)

    [lang=csharp]
    var res = StockData.MSFT
      .Where(stock => stock.Close - stock.Open > 7.0)
      .Select(stock => stock.Date)

<br />

## Looking under the cover

 - _Extension methods_ take `Func<T1, T2>` delegates
 - _Immutable_ because it returns a new `IEnumerable`
 - Functional design allows method chaining

---------

# LINQ before it was cool :-)

    StockData.MSFT
    |> Array.filter (fun stock -> stock.Close - stock.Open > 7.0)
    |> Array.map (fun stock -> stock.Date)

<br />

## Looking under the cover

 - _Pipeline operator_ for composing functions
 - _Lambda functions_ written using `fun`
 - Immutable lists, sequences, arrays, etc.

---------

# Charting libraries for F#

 - [XPlot](http://tahahachana.github.io/XPlot/) - cross platform, HTML-based (recommended)
 - [F# Charting](http://fslab.org/FSharp.Charting/) - flexible but Windows-only library
 - Other options: [FnuPlot](http://fsprojects.github.io/FnuPlot/) and
     [R provider](http://bluemountaincapital.github.io/FSharpRProvider)

<br />
<br />

## For latest information

 - See [FsLab.org](http://fslab.org/) - the F# data science homepage

---------

# Charting with XPlot

Draw `sin` for values from $0$ to $2\pi$:

    [| 0.0 .. 0.1 .. 6.3 |]
    |> Array.map (fun x -> x, sin x)
    |> Chart.Line

Uses _Google Charts_ behind the scenes:

<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">
google.load("visualization", "1", {packages:["corechart"]})
google.setOnLoadCallback(drawChart);
function drawChart() {
    var data = new google.visualization.DataTable({"cols": [{"type": "number" ,"id": "Column 1" ,"label": "Column 1" }, {"type": "number" ,"id": "Column 2" ,"label": "Column 2" }], "rows" : [{"c" : [{"v": 0}, {"v": 0}]}, {"c" : [{"v": 0.1}, {"v": 0.0998334166468282}]}, {"c" : [{"v": 0.2}, {"v": 0.198669330795061}]}, {"c" : [{"v": 0.3}, {"v": 0.29552020666134}]}, {"c" : [{"v": 0.4}, {"v": 0.389418342308651}]}, {"c" : [{"v": 0.5}, {"v": 0.479425538604203}]}, {"c" : [{"v": 0.6}, {"v": 0.564642473395035}]}, {"c" : [{"v": 0.7}, {"v": 0.644217687237691}]}, {"c" : [{"v": 0.8}, {"v": 0.717356090899523}]}, {"c" : [{"v": 0.9}, {"v": 0.783326909627483}]}, {"c" : [{"v": 1}, {"v": 0.841470984807896}]}, {"c" : [{"v": 1.1}, {"v": 0.891207360061435}]}, {"c" : [{"v": 1.2}, {"v": 0.932039085967226}]}, {"c" : [{"v": 1.3}, {"v": 0.963558185417193}]}, {"c" : [{"v": 1.4}, {"v": 0.98544972998846}]}, {"c" : [{"v": 1.5}, {"v": 0.997494986604054}]}, {"c" : [{"v": 1.6}, {"v": 0.999573603041505}]}, {"c" : [{"v": 1.7}, {"v": 0.991664810452469}]}, {"c" : [{"v": 1.8}, {"v": 0.973847630878195}]}, {"c" : [{"v": 1.9}, {"v": 0.946300087687414}]}, {"c" : [{"v": 2}, {"v": 0.909297426825681}]}, {"c" : [{"v": 2.1}, {"v": 0.863209366648873}]}, {"c" : [{"v": 2.2}, {"v": 0.80849640381959}]}, {"c" : [{"v": 2.3}, {"v": 0.74570521217672}]}, {"c" : [{"v": 2.4}, {"v": 0.67546318055115}]}, {"c" : [{"v": 2.5}, {"v": 0.598472144103956}]}, {"c" : [{"v": 2.6}, {"v": 0.515501371821463}]}, {"c" : [{"v": 2.7}, {"v": 0.427379880233829}]}, {"c" : [{"v": 2.8}, {"v": 0.334988150155904}]}, {"c" : [{"v": 2.9}, {"v": 0.239249329213981}]}, {"c" : [{"v": 3}, {"v": 0.141120008059866}]}, {"c" : [{"v": 3.1}, {"v": 0.0415806624332892}]}, {"c" : [{"v": 3.2}, {"v": -0.0583741434275814}]}, {"c" : [{"v": 3.3}, {"v": -0.15774569414325}]}, {"c" : [{"v": 3.4}, {"v": -0.255541102026833}]}, {"c" : [{"v": 3.5}, {"v": -0.350783227689622}]}, {"c" : [{"v": 3.6}, {"v": -0.442520443294854}]}, {"c" : [{"v": 3.7}, {"v": -0.529836140908495}]}, {"c" : [{"v": 3.8}, {"v": -0.611857890942721}]}, {"c" : [{"v": 3.9}, {"v": -0.687766159183975}]}, {"c" : [{"v": 4}, {"v": -0.756802495307929}]}, {"c" : [{"v": 4.1}, {"v": -0.818277111064411}]}, {"c" : [{"v": 4.2}, {"v": -0.871575772413589}]}, {"c" : [{"v": 4.3}, {"v": -0.916165936749455}]}, {"c" : [{"v": 4.4}, {"v": -0.951602073889516}]}, {"c" : [{"v": 4.5}, {"v": -0.977530117665097}]}, {"c" : [{"v": 4.6}, {"v": -0.993691003633464}]}, {"c" : [{"v": 4.7}, {"v": -0.999923257564101}]}, {"c" : [{"v": 4.8}, {"v": -0.996164608835841}]}, {"c" : [{"v": 4.9}, {"v": -0.982452612624333}]}, {"c" : [{"v": 5}, {"v": -0.958924274663139}]}, {"c" : [{"v": 5.1}, {"v": -0.925814682327733}]}, {"c" : [{"v": 5.2}, {"v": -0.883454655720154}]}, {"c" : [{"v": 5.3}, {"v": -0.832267442223903}]}, {"c" : [{"v": 5.4}, {"v": -0.772764487555989}]}, {"c" : [{"v": 5.5}, {"v": -0.705540325570394}]}, {"c" : [{"v": 5.6}, {"v": -0.631266637872324}]}, {"c" : [{"v": 5.7}, {"v": -0.550685542597641}]}, {"c" : [{"v": 5.8}, {"v": -0.464602179413761}]}, {"c" : [{"v": 5.9}, {"v": -0.373876664830241}]}, {"c" : [{"v": 5.99999999999999}, {"v": -0.279415498198931}]}, {"c" : [{"v": 6.09999999999999}, {"v": -0.182162504272101}]}, {"c" : [{"v": 6.19999999999999}, {"v": -0.0830894028175026}]}, {"c" : [{"v": 6.29999999999999}, {"v": 0.0168139004843435}]}]});
    var options = {"legend":{"position":"none"},"width":800,"height":300}
    var chart = new google.visualization.LineChart(document.getElementById('43e71316-d11d-46c1-9e79-f5de65eaed90'));
    chart.draw(data, options);
}
</script>
<div id="43e71316-d11d-46c1-9e79-f5de65eaed90" style="width: 800px; margin-left:100px; height: 300px;"></div>

---------

# What are type providers?

<img src="images/babel.jpg" style="margin-top:30px;width:700px;margin-left:120px" class="fragment" />

---------

# Type provider patterns

Providers for a _specific data source_

    let wb = WorldBankData.GetDataContext()
    wb.Countries.India.Indicators.``Population, total``

Parameterized provider for a _data format_

    type Rss = XmlProvider<"data/bbc.xml">
    Rss.Load(url).Channel.Description

---------

# TASK: Star Wars movie profits


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
<div id="b46bd5ac-5b6c-4725-a5b8-6d2114a04922" style="width: 1100px; height: 600px" class="fragment"></div>

--------

# [github.com/evelinag/polyglot-data-science](https://github.com/evelinag/polyglot-data-science)

*********

# Part II
## Visualization with D3.js

--------

# The Star Wars social network

<a href="images/episode7-interactions.html"><img src="images/episode7_network.png" style="height:600px"/> </a>

--------

![script structure](images/script-example.png)

--------

![](images/d3js.png)

--------
# D3.js visualizations
## made easier

[Gallery of examples](https://github.com/mbostock/d3/wiki/Gallery)

--------

# D3.js social network visualization

[Force-directed network layout](http://bl.ocks.org/mbostock/4062045)


*********

# Part III
## Analyzing social networks with R

--------

# Social network analysis

* Who is the most central character?
* How to the movies compare between themselves?


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

- *edges* = list of nodes

n1, n2, n3, n4, n5, ... <br/>
*represents*
(n1, n2), (n3, n4), ...


-----

# Calculating degree

    [lang=R]

    d <- degree(graph)

-----
- data-background : #212d30

# F#

    open RProvider.igraph

    let degree = R.degree(network)

-----

- data-background : #212d30

# F#
export JSON into list of edges

# R
perform the network analysis

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


--------

- data-background : images/kyloapproves-loop3.gif

********

# CONCLUSIONS

--------

<style type="text/css">
.wordcloud p, .wordcloud h2 {text-align:center;}
.wordcloud p { color:#404040; font-size:80%; }
.wordcloud p em { color:#202020; font-size:115%; margin:0px 10px 0px 10px; }
.wordcloud p strong { color:#000000; font-weight:normal; font-size:130%; margin:0px 10px 0px 10px; }
</style>
<div class="wordcloud">

non-profit _books and tutorials_

_cross-platform_ **community** data science

## F# Software Foundation

commercial support **open-source** _contributions_

machine learning **[www.fsharp.org](http://www.fsharp.org)** web and cloud

consulting  _user groups_ research

</div>

--------

# The Learning Pyramid

<img src="images/pyramid.png" style="width:650px;margin:50px 0px 0px 80px" />

----------------------------------------------------------------------------------------------------

## Community chat and Q&A

 - **#fsharp** on Twitter
 - **StackOverflow** F# tag

## Open source on GitHub

 - **Visual F#** repo
   [github.com/Microsoft/visualfsharp](http://github.com/Microsoft/visualfsharp)
 - **F# Compiler** and core libraries
   [github.com/fsharp](http://github.com/fsharp/)
 - **F# Incubation** project space
   [github.com/fsprojects](http://github.com/fsprojects/)
 - **FsLab** Organization repository
   [github.com/fslaborg](http://github.com/fslaborg/)

## More resources

 - Scott Wlaschin's [fsharpforfunandprofit.com](http://fsharpforfunandprofit.com/)

----------------------------------------------------------------------------------------------------

# F# Books and Resources

## [fsharp.org/about/learning.html](http://fsharp.org/about/learning.html)

<img src="images/books.png" style="width:700px;margin:20px 0px 0px 80px" />

----------------------------------------------------------------------------------------------------

# <div class="sw">The Force Awakens </div>

<br />

**Evelina Gabasova**

  - [@evelgab](http://twitter.com/evelgab)
  - [evelina@evelinag.com](mailto:evelina@evelinag.com)
  - [www.evelinag.com](http://evelinag.com)

**Tomas Petricek**

 - [@tomaspetricek](http://twitter.com/tomaspetricek)
 - [tomas@tomasp.net](mailto:tomas@tomasp.net)
 - [www.tomasp.net](http://tomasp.net)
