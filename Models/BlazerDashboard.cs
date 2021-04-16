using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class BlazerDashboard
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string Name { get; set; }
    }
}
