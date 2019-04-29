using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class Line : BaseCreator
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
                return "line";
            }
        }

    }
}
