using System;
using System.Collections.Generic;

namespace DynamicQueries
{
    public class CriteriaParameters
    {
        public Dictionary<string, object> SingleProperty
        {
            get;
            set;
        }

        public Dictionary<string, IEnumerable<object>> MultiProperty
        {
            get;
            set;
        }

    }
}
