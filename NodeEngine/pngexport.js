var program = require('commander');
var svgexport = require('svgexport');

program
    .version('0.0.1')
    .option('-i, --input [value]', 'svg file', 'temp.svg')
    .option('-o, --output [value]', 'path to output image.', 'image.png');

	program.parse(process.argv);
	
	var p = '[{"input":"'+program.input+'","output":["'+ program.output+' 1%"]}]';
	var jp= eval(p);

svgexport.render(jp, function() { console.log("done");} );