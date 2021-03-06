﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class StackArea : BaseCreator
    {
        public override string ChartObjectType
        {
            get
            {
                return "area";
            }
        }
        public override string ChartSeriesType
        {
            get
            {
                return "area";
            }
        }

        public override string GetJS_Misc()
        {
            return "chart.yScale().stackMode(\"value\");";
        }
    }
}
