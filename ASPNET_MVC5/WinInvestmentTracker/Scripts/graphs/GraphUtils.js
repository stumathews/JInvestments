function forceTick() {
    d3.selectAll("line.link")
        .attr("x1", function (d) { return d.source.x; })
        .attr("x2", function (d) { return d.target.x; })
        .attr("y1", function (d) { return d.source.y; })
        .attr("y2", function (d) { return d.target.y; });

    d3.selectAll("g.node")
        .attr("transform",
            function (d) {
                return "translate(" + d.x + "," + d.y + ")";
            });

}

function drawGraph(GenerateGraphUrl, model) {
    d3.json(GenerateGraphUrl, function handleGraphData(error, graph) {
        var svg_width = 960;
        var svg_height = 300;

        var data = graph;

        /*    {
                "nodes":[
                    { "name": "index", "value": 5},
                    { "name": "about", "value": 5},
                    { "name": "contact", "value": 5},
                    { "name": "store", "value": 8},
                    { "name": "cheese", "value": 8},
                    { "name": "yoghurt", "value": 10},
                    { "name": "milk", "value": 2}
                ],
                "links":[
                    {"source":0,"target":1,"value":25},
                    {"source":0,"target":2,"value":10},
                    {"source":0,"target":3,"value":40},
                    {"source":1,"target":2,"value":10},
                    {"source":3,"target":4,"value":25},
                    {"source":3,"target":5,"value":10},
                    {"source":3,"target":6,"value":5},
                    {"source":4,"target":6,"value":5},
                    {"source":4,"target":5,"value":15}
                ]
            }
            */

        var aspectInvestmentsCount = d3.scale.linear().interpolate(d3.interpolateHcl)
            .domain(d3.extent(data.nodes, function (d) { return d.value; })).range(["green", "red"]);

        var svg = d3.select(model.element).attr("height", svg_height).attr("width", svg_width);
        var createdLinks = svg.selectAll("line.link").data(data.links).enter().append("line")
            .attr("class", "link");
        var createdNodes = svg.selectAll("g.node").data(data.nodes).enter().append("g").attr("class", "node");
        var createdCircles = createdNodes.append("circle").attr("r", function (d) { return d.value; })
            .style("fill", function (d) { return aspectInvestmentsCount(d.value) });
        var firstCircle = createdCircles.filter(function (d, i) { return i === 0 });
        firstCircle.attr("r", 20).style("fill", "blue").style("stroke", "blue");
        var createdLabels = createdNodes.append("text").style("class", "label").style("text-anchor", "right").attr("y", 15).attr("x", 20)
            .text(function (d) { return d.name; });
        var investmentLable = createdLabels.filter(function (d, i) { return i === 0 });
        investmentLable.style("stroke", "blue").attr("y", 20).attr("x", 20);


        var force = d3.layout.force()
            .charge(-1500)
            .size([svg_width, svg_height])
            .nodes(data.nodes)
            .links(data.links)
            .gravity(0.1)
            .linkDistance(50)
            .on("tick", forceTick);

        // Make it dragable
        d3.selectAll("g.node").call(force.drag());
        force.start();


    });
}

