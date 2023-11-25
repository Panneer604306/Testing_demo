using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
    public abstract class BaseResult
    {
        #region Properties 
        public virtual bool Status { get; set; }
        public virtual string Message { get; set; }
        public virtual int TotalCount { get; set; }
        #endregion
    }
}
