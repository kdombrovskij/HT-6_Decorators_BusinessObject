using System;
using System.Collections.Generic;

namespace HT4_Parallel.DataSource
{
    [Serializable]
    public class Filters
    {
        public List<Filter> FiltersList { get; set; }
        public Filters()
        {
            FiltersList = new List<Filter>();
        }
    }
}
