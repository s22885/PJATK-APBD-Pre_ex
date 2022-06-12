using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Entities
{
    public class FireTruckAction
    {
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }
        public DateTime AssignmentDate { get; set; }
        public virtual FireTruck IdFireTruckNavigation { get; set; }
        public virtual Action IdActionNavigation { get; set; }

    }
}
