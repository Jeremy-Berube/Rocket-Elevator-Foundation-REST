using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class BuildingDetail
    {
        public long Id { get; set; }
        public string InformationKey { get; set; }
        public string Value { get; set; }
        public long? BuildingId { get; set; }

        public virtual Building Building { get; set; }
    }
}
