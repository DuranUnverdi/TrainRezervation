using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainRes.Model
{
    public class Vagon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int FullSeat { get; set; }
        public int TrainId { get; set; }
    }
}
