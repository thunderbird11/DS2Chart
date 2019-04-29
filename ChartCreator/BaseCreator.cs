using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DSToChartPng.ChartCreator
{
    internal abstract class BaseCreator
    {
        protected DToCOptions Options { get; set; } = null;
        protected DataTable DT { get; set; } = null;
        public abstract string ChartSeriesType { get; }
        public abstract string ChartObjectType { get; }
        public virtual bool CreateObjectWithData { get { return false; } }
        public virtual void SetDataAndOptions(DataTable data, DToCOptions options)
        {
            DT = data;
            Options = options;
        }
        public virtual string GetJS_CreateObject()
        {
            var sb = new StringBuilder();
            var data = CreateObjectWithData ? "data1" : "";
            sb.AppendLine($"chart = anychart.{ChartObjectType}({data});");
            return sb.ToString();
        }
        public virtual string GetJS_SetOtherProperties()
        {
            var sb = new StringBuilder();      
            sb.AppendLine($"var xAxis = chart.xAxis();");
            sb.AppendLine($"xAxis.title(\"{Options.XLabel}\");");
            sb.AppendLine($"var yAxis = chart.yAxis();");
            sb.AppendLine($"yAxis.title(\"{Options.YLabel}\");");           
            return sb.ToString();
        }

        public virtual string GetJS_SetChartProperties()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"chart.bounds(0, 0, {Options.Width}, {Options.Height});");
            sb.AppendLine($"chart.legend(" + (Options.ShowLegend ? "true" : "false" )+ ")");
            sb.AppendLine($"chart.title(\"{Options.Title}\")");
            sb.AppendLine($"chart.container(\"container\");");
            return sb.ToString();
        }

        public virtual string GetJS_Draw()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"chart.draw();");
            return sb.ToString();
        }

        public virtual string GetJS_Data()
        {
            var sb = new StringBuilder();
            var colnum = DT.Columns.Count;
            for (int i = 1; i < colnum; i++)
            {
                sb.AppendLine($"var data{i} = [");
                foreach (DataRow r in DT.Rows)
                {
                    sb.AppendLine($"{{x:\"{r[0]}\",value:{r[i]} }},");
                }
                sb.AppendLine($"];");
            }
            return sb.ToString();
        }

        public virtual string GetJS_DataSeries()
        {
            var sb = new StringBuilder();
            var colnum = DT.Columns.Count;
            for (int i = 1; i < colnum; i++)
            {
                sb.AppendLine($"var series{i} = chart.{ChartSeriesType}(data{i});");
                sb.AppendLine($"series{i}.name(\"{DT.Columns[i].ColumnName}\");");
            }
            return sb.ToString();
        }

        public virtual string GetJS_Misc()
        {
            return "";
        }

        public string GetJS()
        {
            var ret = "";
            ret += GetJS_Data();
            if (!string.IsNullOrWhiteSpace(Options.JSTemplate) && File.Exists(Options.JSTemplateFilePath))
            {
                ret = File.ReadAllText(Options.JSTemplateFilePath).Replace("{{DATA}}", ret);
                ret = Options.ReplaceWithPropertites(ret);
            }
            else {
                ret += GetJS_CreateObject();
                if (!CreateObjectWithData)
                    ret += GetJS_DataSeries();
                ret += GetJS_SetChartProperties();
                ret += GetJS_SetOtherProperties();
                ret += GetJS_Misc();
                ret += GetJS_Draw();
            }
            return ret;
        }

        
    }
}
