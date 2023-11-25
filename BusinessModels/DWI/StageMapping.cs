using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class StageMapping
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string Line { get; set; }
        public string Stage { get; set; }
        public string ConfIPAddress { get; set; }
        public string ConfStage { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
    }
}
