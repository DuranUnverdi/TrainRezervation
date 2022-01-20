using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainRes.Model
{
    public class ResModel
    {
        public int TrainId { get; set; }
        public int NumberofPersonstoReservation { get; set; }
        public bool PersonsDifferentWagons { get; set; }
    }
}
