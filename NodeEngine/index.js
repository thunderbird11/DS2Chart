var fs = require('fs');
var jsdom = require('jsdom').jsdom;
var program = require('commander');
var svgexport = require('svgexport');

var d = jsdom('<body><div id="container"></div></body>');
var w = d.defaultView;

var anychart = require('anychart')(w);
var anychart_nodejs = require('anychart-nodejs')(anychart);
program
    .version('0.0.1')
    .option('-i, --input [value]', 'path to input data file with chart, stage or svg', 'chart.js')
    .option('-o, --output [value]', 'path to output image or svg file.', 'image')
    .option('-t, --type [value]', 'type of output data.', 'svg')
	.option('-w, --width [value]', 'svg width.', '600')
	.option('-h, --height [value]', 'svg heigth.', '600');

program.parse(process.argv);

if (!program.input) {
  console.log('Input data not found.');
} else {
  fs.readFile(program.input, 'utf8', function(err, data) {
    if (err) {
      console.log(err.message);
    } else {
      var chart;
	  data=data.replace(/{{WIDTH}}/,program.width).replace(/{{HEIGHT}}/,program.height);
      try {
        eval(data);
      } catch (e) {
        console.log(e.message);
        chart = null;
      }

      if (chart) {
        anychart_nodejs.exportTo(chart, program.type).then(function(image) {
		  image=image.replace(/width="100%"/,"width=\""+program.width+"px\"").replace(/height="100%"/,"height=\""+program.height+"px\"");		  
		  fs.writeFile(program.output + '.' + program.type, image, function(err) {
            if (err) {
              console.log(err.message);
            } else {
              console.log('Written to file');
            }
            process.exit(0);
          });
        }, function(err) {
          console.log(err.message);
        });
		/*var ss = anychart_nodejs.exportToSync(chart,program.type);
		var svgfilename=program.output + '.' + program.type;
		fs.writeFile(svgfilename, ss, function(err) {
            if (err) {
              console.log(err.message);
            } else {
              console.log('Written to file');
            }
            process.exit(0);
          });*/
      } else {
        console.log('Cannot find target chart');
      }
    }
  });
}
