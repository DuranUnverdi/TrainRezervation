using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainRes.Model
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Vagon> Vagons { get; set; }
    }
}
