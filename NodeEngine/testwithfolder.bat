cd c:\tmp\image
node index.js -i "c:\\tmp\\image\\input\\pie.js" -o "c:\\tmp\\image\\output\\SS" -t svg -w 600 -h 600
node pngexport.js -i "c:\\tmp\\image\\output\\SS.svg" -o "c:\\tmp\\image\\output\\SS.png"