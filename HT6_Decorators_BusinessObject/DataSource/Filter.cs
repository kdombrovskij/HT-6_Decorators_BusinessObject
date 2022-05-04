using System;

namespace HT6_Decorators_BusinessObject.DataSource
{
    [Serializable]
    public class Filter
    {
        public string item { get; set; }
        public string producer { get; set; }
        public int sort { get; set; }
        public int price { get; set; }
    }
}
