using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
    public class PartitionThenSum
    {
        public PartitionThenSum(List<Stock> sources)
        {
            this.Sources = sources;
        }

        public List<Stock> Sources { get; set; }
      

        public List<int> GetSumResult<T>(int rows) where T : ColumnBase
        {
            List<List<Stock>> partitionResult = this.GetPartition(Sources, rows);
            List<int> sumResult = this.GetSum<T>(partitionResult);

            return sumResult;
        }

        private List<int> GetSum<T>(List<List<Stock>> partitionResult) where T : ColumnBase
        {
            var output = new List<int>();
            foreach (var stocks in partitionResult)
            {
                var f = stocks.Select(stock => (stock.GetType().GetProperties()
                                                     .Where(property => typeof(T).IsAssignableFrom(property.PropertyType))
                                                     .First().GetValue(stock) as T).Value
                                      ).Sum(s => s);               

                output.Add(f);
            }

            return output;
        }

        private List<List<Stock>> GetPartition(List<Stock> sources, int rows)
        {
            var output = new List<List<Stock>>();
            List<Stock> partition = null;

            for (int i = 0; i < sources.Count; i++)
            {
                if (i % rows == 0)
                {
                    partition = new List<Stock>();
                    output.Add(partition);
                }

                partition.Add(sources[i]);
            }

            return output;
        }
    }
}
