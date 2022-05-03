using System;

namespace HT4_Parallel.DataSource
{
    [Serializable]
    public class Filter
    {
        public int categoryProducts { get; set; }
        public string item { get; set; }
        public string producer { get; set; }
        public int sort { get; set; }
        public int numberProduct { get; set; }
        public int price { get; set; }
    }
}
