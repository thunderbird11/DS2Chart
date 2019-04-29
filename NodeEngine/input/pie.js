 chart = anychart.pie3d([
    ['Northfarthing', 235],
    ['Westfarthing', 552],
    ['Eastfarthing', 491],
    ['Southfarthing', 619],
    ['Buckland', 388],
    ['Westmarch', 405]
  ]);
chart.bounds(0, 0, {{WIDTH}}, {{HEIGHT}});
  // set chart title text settings
  chart.title('Population in The Shire')
    //set chart radius
    .radius('43%');

  // set container id for the chart
  chart.container('container');
  // initiate chart drawing
  chart.draw();