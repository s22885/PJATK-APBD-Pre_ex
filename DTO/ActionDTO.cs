using System.Collections.Generic;

namespace PreKolos2.DTO
{
    public class ActionDTO
    {
        public int IdAction { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }
        public List<FireTruckDTO> fireTruckActionDTOs { get; set; }
    }
}
