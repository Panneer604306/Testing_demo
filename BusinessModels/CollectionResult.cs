using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessModels
{
    public class CollectionResult<T>: BaseResult
    {
        #region Private Variable

        private Collection<T> _data = new Collection<T>();

        #endregion

        #region Properties 
        public Collection<T> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion
    }
}
