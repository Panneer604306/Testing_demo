using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class PartPicMapping
    {
        public int Id { get; set; }
        public string MT { get; set; }
        public string MTM { get; set; }
        public string Series { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Stage { get; set; }
        public string Display { get; set; }
        public IFormFile? PartPicFile { get; set; }
        public string PartPic { get; set; }
        public string PartPicPath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
    }
  
}
