using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class Spline : BaseCreator
    {
        public override string ChartObjectType
        {
            get
            {
                return "line";
            }
        }

        public override string ChartSeriesType
        {
            get
            {
                return "spline";
            }
        }
    }
}
