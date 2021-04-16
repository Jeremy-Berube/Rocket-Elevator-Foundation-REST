using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class BlazerCheck
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public long? QueryId { get; set; }
        public string State { get; set; }
        public string Schedule { get; set; }
        public string Emails { get; set; }
        public string SlackChannels { get; set; }
        public string CheckType { get; set; }
        public string Message { get; set; }
    }
}
