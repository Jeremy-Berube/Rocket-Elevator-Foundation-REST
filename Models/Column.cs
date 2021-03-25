using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string BuildingType { get; set; }
        public int? NumberOfFloorsServed { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? BatteryId { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
