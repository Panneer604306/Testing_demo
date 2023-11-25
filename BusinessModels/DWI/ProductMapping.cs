using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
   public class ProductMapping
    {
        public int Id { get; set; }
        public string MT { get; set; }
        public string Product { get; set; }
        public string ProductType { get; set; }
        public string Series { get; set; }
        public string FormFactor { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int RowNumber { get; set; }
        public string Mode { get; set; }
    }
}
