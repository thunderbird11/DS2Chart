cd "{{ENGINEPATH}}"
node index.js -i "{{ENGINEPATH}}\\input\\{{IMAGENAME}}.js" -o "{{ENGINEPATH}}\\output\\{{IMAGENAME}}" -t svg -w {{WIDTH}} -h {{HEIGHT}}
node pngexport.js -i "{{ENGINEPATH}}\\output\\{{IMAGENAME}}.svg" -o "{{ENGINEPATH}}\\output\\{{IMAGENAME}}.png"