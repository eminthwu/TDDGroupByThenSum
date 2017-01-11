using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPartitionThenSum;
using System.Collections.Generic;
using System.Linq;


namespace TDDGroupByThenSumTest
{
    [TestClass]
    public class TDDPartitionThenSumTest
    {
        private static List<Stock> _Sources
        {
            get
            {
                return new List<TDDPartitionThenSum.Stock>()
                {
                    new Stock() { Id = 1, Cost =1,  Revenue = 11,  SellPrice = 21},
                    new Stock() { Id = 2,  Cost = 2, Revenue = 12,  SellPrice = 22},
                    new Stock() { Id = 3,  Cost = 3, Revenue = 13,  SellPrice = 23},
                    new Stock() { Id = 4,  Cost = 4, Revenue = 14,  SellPrice =24},
                    new Stock() { Id = 5,  Cost = 5, Revenue = 15,  SellPrice = 25},
                    new Stock() { Id = 6,  Cost = 6, Revenue = 16,  SellPrice = 26},
                    new Stock() { Id = 7,  Cost = 7, Revenue = 17,  SellPrice = 27},
                    new Stock() { Id = 8,  Cost = 8, Revenue = 18,  SellPrice = 28},
                    new Stock() { Id = 9,  Cost = 9, Revenue = 19,  SellPrice = 29},
                    new Stock() { Id = 10,  Cost = 10, Revenue = 20,  SellPrice = 30},
                    new Stock() { Id = 11,  Cost = 11, Revenue = 21,  SellPrice = 31},
                };
            }
        }


        [TestMethod]
        public void 驗證GetSumResultReflection_Cost欄位_3個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 3;
            var property = "Cost";
            var expected = new List<int>() { 6, 15, 24, 21 };

            //Act
            List<int> result = PartitionThenSum.GetSumResultReflection<Stock>(_Sources, rows, property);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResultReflection_Revenue欄位_4個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 4;
            var property = "Revenue";
            var expected = new List<int>() { 50, 66, 60 };

            //Act
            List<int> result = PartitionThenSum.GetSumResultReflection(_Sources, rows, property);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResultGeneric_Cost欄位_3個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 3;
            var expected = new List<int>() { 6, 15, 24, 21 };

            Func<IEnumerable<Stock>, List<int>> func = (IEnumerable<Stock> sources) => sources.Select(s => s.Cost).ToList();

            //Act
            List<int> result = PartitionThenSum.GetSumResultGeneric(_Sources, func, rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResultExtensionGeneric_Revenue欄位_4個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 4;
            var expected = new List<int>() { 50, 66, 60 };
            Func<IEnumerable<Stock>, List<int>> func = (IEnumerable<Stock> sources) => sources.Select(s => s.Revenue).ToList();

            //Act
            List<int> result = PartitionThenSum.GetSumResultGeneric(_Sources, func, rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResultExtensionGeneric_Cost欄位_3個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 3;
            var expected = new List<int>() { 6, 15, 24, 21 };
            var anonymous = _Sources.Select(s => new { Id = s.Id, Cost = s.Cost, Revenue = s.Revenue, SellPrice = s.SellPrice }).ToList();

            //Act            
            var result = anonymous.GetSumResultExtensionGeneric(s => s.Cost, rows);


            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResultReGeneric_Revenue欄位_4個一組()
        {
            //var target = new PartitionThenSum(Sources);
            var rows = 4;
            var expected = new List<int>() { 50, 66, 60 };

            Func<IEnumerable<Stock>, List<int>> func = (IEnumerable<Stock> sources) => sources.Select(s => s.Revenue).ToList();

            //Act
            List<int> result = PartitionThenSum.GetSumResultGeneric(_Sources, func, rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
