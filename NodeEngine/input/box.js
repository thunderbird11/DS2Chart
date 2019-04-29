chart = anychart.area();
chart.bounds(0, 0, 600, 600);
    var series = chart.splineArea([
        {x: "January", value: 5},
        {x: "February", value: 6},
        {x: "March", value: 9},
        {x: "April", value: 6},
        {x: "May", value: 8},
        {x: "June", value: 4}
    ]);
    series.stroke("#F44336");

    // Get select series stroke.
    var stroke = series.stroke();

    chart.title({text: "Get and use select series stroke",fontColor: stroke});
    chart.container("container");
    chart.draw();