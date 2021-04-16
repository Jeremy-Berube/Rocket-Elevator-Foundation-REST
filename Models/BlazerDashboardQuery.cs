using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class BlazerDashboardQuery
    {
        public long Id { get; set; }
        public long? DashboardId { get; set; }
        public long? QueryId { get; set; }
        public int? Position { get; set; }
    }
}
