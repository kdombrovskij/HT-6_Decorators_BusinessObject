using System;
using System.Collections.Generic;

namespace HT6_Decorators_BusinessObject.DataSource
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
