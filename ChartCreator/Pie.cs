using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSToChartPng.ChartCreator
{
    internal class Pie : BaseCreator
    {
        public override string ChartObjectType
        {
            get
            {
                return "pie";
            }
        }

        public override string ChartSeriesType
        {
            get
            {
                return "";
            }
        }

        public override string GetJS_SetOtherProperties()
        {
            return "";
        }

        public override bool CreateObjectWithData
        {
            get
            {
                return true;
            }
        }

    }
}
