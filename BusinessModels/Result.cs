using BusinessModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
        /// <summary>
        /// Simple result object type
        /// </summary>
        /// <typeparam name="T">The return data type</typeparam>
        public class Result<T> : BaseResult
        {
            #region Properties

            /// <summary>
            ///     Property to get or set the return data
            /// </summary>
            public T Data { get; set; }


            #endregion
        }
   
}
