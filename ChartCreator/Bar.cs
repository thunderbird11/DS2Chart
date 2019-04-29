using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class Bar :  BaseCreator
    {
        public override string ChartObjectType
        {
            get
            {
                return "bar";
            }
        }
        public override string ChartSeriesType
        {
            get
            {
                return "bar";
            }
        }
    }
}
