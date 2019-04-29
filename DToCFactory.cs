using DSToChartPng.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DSToChartPng.ChartCreator;

namespace DSToChartPng
{
    public class DToCFactory
    {
        public static DToCResult Convert(DataTable dt, DToCOptions options)
        {
            if (dt == null || options == null) return DToCResult.CreateFailResult("Invalid parameter");
            var optionvalidate = options.IsValid();
            if (!string.IsNullOrWhiteSpace(optionvalidate)) return DToCResult.CreateFailResult(optionvalidate);
            var className = "DSToChartPng.ChartCreator." + options.ChartType.Value.ToString();
            Type classType = Assembly.GetExecutingAssembly().GetType(className);
            if (!string.IsNullOrWhiteSpace(optionvalidate)) return DToCResult.CreateFailResult(optionvalidate);
            if (classType == null) return DToCResult.CreateFailResult($"Cannot find the class {className}");
            var creator = (BaseCreator)Activator.CreateInstance(classType);
            if (creator == null) return DToCResult.CreateFailResult($"Cannot create instance for the class {className}");
            creator.SetDataAndOptions(dt, options);
            File.WriteAllText(options.JSFilePath, creator.GetJS());
            GenerateCmdBatch(options);
            ExecuteCommand(options.BatFilePath);
            if (!File.Exists(options.PngFilePath))
                return DToCResult.CreateFailResult("Error to generate png file");
            
            return new DToCResult() {
                Result= true,
                ChartFormat = ChartFormat.PNG,
                Width = options.Width,
                Height = options.Height,
                data = File.ReadAllBytes(options.PngFilePath)
            };
        }



        private static void GenerateCmdBatch(DToCOptions options)
        {
            var bat = File.ReadAllText(options.BatTemplate);
            bat = bat.Replace("{{ENGINEPATH}}", options.EnginePath.Replace("\\", "\\\\"));
            bat = bat.Replace("{{WIDTH}}", options.Width.ToString());
            bat = bat.Replace("{{HEIGHT}}", options.Height.ToString());
            bat = bat.Replace("{{IMAGENAME}}", options.ImageName);
            File.WriteAllText(options.BatFilePath,bat);
        }

        static void ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.WaitForExit();
            process.Close();
        }
    }


}
