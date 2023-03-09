using System;
using System.Collections.Generic;

namespace ELMSDAL.Models
{
    public partial class Logs
    {
        public int Id { get; set; }
        public string Logmessage { get; set; }
        public string Execptionmessage { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
