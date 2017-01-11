using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
    public partial class PartitionThenSum
    {
        public static List<int> GetSumResultReflection<T>(List<T> sources, int rows, string propertyName)
        {
            var partition = GetPartition<T>(sources, rows);
            var result = GetSum<T>(partition, propertyName);

            return result;
        }

        private static List<int> GetSum<T>(List<List<T>> partitionResult, string propertyName)
        {
            var output = new List<int>();
            foreach (var stocks in partitionResult)
            {
                var f = stocks.Select(stock => (stock.GetType().GetProperties()
                                                     .Where(property => property.Name == propertyName && property.PropertyType == typeof(int))
                                                     .First().GetValue(stock))
                                      ).Sum(s => (int)s);

                output.Add(f);
            }

            return output;
        }

        private static List<List<T>> GetPartition<T>(List<T> sources, int rows)
        {
            var output = new List<List<T>>();
            List<T> partition = null;

            for (int i = 0; i < sources.Count; i++)
            {
                if (i % rows == 0)
                {
                    partition = new List<T>();
                    output.Add(partition);
                }

                partition.Add(sources[i]);
            }

            return output;
        }
    }

    public static class Extension
    {
        //public static 
    }
}
