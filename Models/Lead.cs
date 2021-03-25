using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class Lead
    {
        public long Id { get; set; }
        public string FullNameOfContact { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DepartmentInChargeOfElevators { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
    }
}
