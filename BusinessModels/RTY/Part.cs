using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
    public class Part
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string PartName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Mode { get; set; }
        public int RowNumber { get; set; }
    }
}
