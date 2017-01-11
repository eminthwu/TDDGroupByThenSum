using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
    public partial class PartitionThenSum
    {
        /*映射取得property*/

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

    public partial class PartitionThenSum
    {
        /*練習使用Func，但依舊不能傳入匿名型別*/
        public static List<int> GetSumResultGeneric<T>(IEnumerable<T> sources, Func<IEnumerable<T>, List<int>> executor, int rows)
        {
            var index = 0;
            var result = new List<int>();

            while (index < sources.Count())
            {
                result.Add(executor(sources).Skip(index).Take(rows).Sum(s => s));
                index += rows;
            }

            return result;
        }
    }

    public static class Extension
    {
        /*使用extension method*/
        public static List<int> GetSumResultExtensionGeneric<T>(this IEnumerable<T> instance, Func<T,int> executor, int rows)
        {
            var index = 0;
            var result = new List<int>();

            while (index <= instance.Count())
            {
                result.Add(instance.Skip(index).Take(rows).Sum(executor));
                index += rows;
            }

            return result;
        }


        /*91的Sample*/
        public static IEnumerable<int> GetSumResultExtensionGeneric1<T>(this IEnumerable<T> instance, Func<T, int> executor, int rows)
        {
            var index = 0;
            var result = new List<int>();

            while (index <= instance.Count())
            {
                yield return instance.Skip(index).Take(rows).Sum(executor);
                index += rows;
            }
            
        }
    }
}
