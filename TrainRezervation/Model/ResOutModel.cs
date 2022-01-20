using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainRes.Model
{
    public class ResOutModel
    {
        public bool Available { get; set; }
        public virtual List<Detail> Details { get; set; }
    }

    public class Detail
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
