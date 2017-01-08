using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
    public class PartitionThenSum
    {
        public static List<Stock> Sources
        {
            get
            {
                return new List<Stock>()
                {
                    new Stock() { Id = 1, Cost = new ColumnCost(1),  Revenue = new ColumnRevenue( 11),  SellPrice = new ColumnSellPrice(21)},
                    new Stock() { Id = 2,  Cost = new ColumnCost(2), Revenue = new ColumnRevenue(12),  SellPrice = new ColumnSellPrice(22) },
                    new Stock() { Id = 3,  Cost = new ColumnCost(3), Revenue = new ColumnRevenue(13),  SellPrice = new ColumnSellPrice(23) },
                    new Stock() { Id = 4,  Cost = new ColumnCost(4), Revenue = new ColumnRevenue(14),  SellPrice =new ColumnSellPrice(24) },
                    new Stock() { Id = 5,  Cost = new ColumnCost(5), Revenue = new ColumnRevenue(15),  SellPrice = new ColumnSellPrice(25) },
                    new Stock() { Id = 6,  Cost = new ColumnCost(6), Revenue = new ColumnRevenue(16),  SellPrice = new ColumnSellPrice(26) },
                    new Stock() { Id = 7,  Cost = new ColumnCost(7), Revenue = new ColumnRevenue(17),  SellPrice = new ColumnSellPrice(27) },
                    new Stock() { Id = 8,  Cost = new ColumnCost(8), Revenue = new ColumnRevenue(18),  SellPrice = new ColumnSellPrice(28) },
                    new Stock() { Id = 9,  Cost = new ColumnCost(9), Revenue =new ColumnRevenue(19),  SellPrice = new ColumnSellPrice(29)},
                    new Stock() { Id = 10,  Cost = new ColumnCost(10), Revenue = new ColumnRevenue(20),  SellPrice = new ColumnSellPrice(30) },
                    new Stock() { Id = 11,  Cost = new ColumnCost(11), Revenue = new ColumnRevenue(21),  SellPrice = new ColumnSellPrice(31)},
                };
            }
        }

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
