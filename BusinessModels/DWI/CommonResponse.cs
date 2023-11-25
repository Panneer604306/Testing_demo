using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class CommonResponse
    {
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
