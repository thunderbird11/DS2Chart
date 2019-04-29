// create a data set
    {{DATA}}


// create a chart

    chart = anychart.bar();

// create a bar series and set the data

    var series = chart.bar(data1);

    series.labels(true);

	series.labels().fontColor("green");

	series.labels().fontWeight(900);

	series.labels().format("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp{%x}({%Value})").useHtml(true);

	series.labels().position("right-center");
	//series.labels().anchor("left-center");

	//series.labels().offsetY(10);

	chart.title("{{options.Title}}");
	chart.bounds(0, 0, {{options.Width}}, {{options.Height}});

// set the container id

	chart.container("container");
	chart.xAxis().title("Client");
	chart.xAxis().labels().enabled(false);

// initiate drawing the chart

	chart.draw();
