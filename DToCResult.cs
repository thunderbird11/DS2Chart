using DSToChartPng.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng
{
    public class DToCResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ChartFormat ChartFormat { get; set; }
        public byte[] data { get; set; }

        internal static DToCResult CreateFailResult(string msg)
        {
            return new DToCResult()
            {
                Result = false,
                ErrorMessage = msg
            };
        }
    }
}
