using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.Abstracts
{
    /// <summary>
    ///     Simple result object type
    /// </summary>
    public class BaseResult
    {
        #region Properties
        /// <summary>
        ///     Property to set or get the success status
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        ///     Property to get or set the reason for failure
        /// </summary>
        public virtual string Message { get; set; }
        #endregion
    }
}
