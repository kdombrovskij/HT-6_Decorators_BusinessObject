using HT6_Decorators_BusinessObject.DataSource;
using System.Collections.Generic;

namespace HT6_Decorators_BusinessObject.Utils
{
    public class DataProvider
    {
        public static IEnumerable<Filter> TestData()
        {

            Filters filters = FilterReader.ReadFiltersFromXML(); 
            System.Console.WriteLine("filters:"+filters.ToString());
            for (int i = 0; i < filters.FiltersList.Count; i++)
            {
                yield return filters.FiltersList[i];
            }
        }

    }
}
