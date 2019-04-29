using DSToChartPng.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DSToChartPng
{
    public class DToCOptions
    {
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 600;
        public string XLabel { get; set; }
        public string YLabel { get; set; }
        public string Title { get; set; }
        public bool ShowLegend { get; set; } = false;
        public string ImageName { get; set; } = Guid.NewGuid().ToString();
        public string EnginePath { get; set; }
        public ChartType? ChartType { get; set; }
        public string JSTemplate { get; set; }
        internal string BatTemplate {  get { return Path.Combine(EnginePath, "template", "command.bat"); } }
        internal string BatFilePath { get { return Path.Combine(EnginePath,"input",$"{ImageName}.bat"); } }
        internal string JSFilePath { get { return Path.Combine(EnginePath, "input", $"{ImageName}.js"); } }
        internal string PngFilePath { get { return Path.Combine(EnginePath, "output", $"{ImageName}.png"); } }
        internal string SvgFilePath { get { return Path.Combine(EnginePath, "output", $"{ImageName}.svg"); } }
        internal string JSTemplateFilePath { get { return Path.Combine(EnginePath, "template", $"{JSTemplate}.js"); } }
        public Dictionary<string, string> OtherSettings { get; set; } = new Dictionary<string, string>();

        internal string IsValid()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(EnginePath)) sb.AppendLine("Must specify the Engine path");
            if (!ChartType.HasValue) sb.AppendLine("Must specify the chart type");

            return sb.ToString();
        }

        public string ReplaceWithPropertites(string js)
        {
            var pros = this.GetType().GetProperties();
            foreach (var p in pros.Where(a=>a.Name!= "OtherSettings"))
            {
                string v = "" ;
                if (p.PropertyType == typeof(Int32)) v = p.GetValue(this).ToString();
                else if (p.PropertyType == typeof(string)) v = p.GetValue(this)?.ToString();
                else if (p.PropertyType == typeof(bool)) v = ((bool)p.GetValue(this)) ? "true" : "false";

                js = js.Replace("{{"+$"options.{p.Name}"+"}}", v);
            }
            foreach ( var d in OtherSettings)
            {
                js = js.Replace($"options.OtherSettings.{d.Key}", d.Value);
            }
            return js;
        }

    }
}
