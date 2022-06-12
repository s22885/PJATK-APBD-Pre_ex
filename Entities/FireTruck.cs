using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Entities
{
    public class FireTruck
    {
        [Key]
        public int IdFiretruck { get; set; }
        [MaxLength(10)]
        public string OperationNumber { get; set; }
        public bool SpecialEquipment { get; set; }
        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }

        public FireTruck()
        {
            FireTruckActions = new HashSet<FireTruckAction>();
        }

    }
}
