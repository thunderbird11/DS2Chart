using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class Column : BaseCreator
    {
        public override string ChartObjectType
        {
            get
            {
                return "column";
            }
        }

        public override string ChartSeriesType
        {
            get
            {
                return "column";
            }
        }
    }
}
