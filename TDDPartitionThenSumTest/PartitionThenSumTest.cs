using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPartitionThenSum;
using System.Collections.Generic;


namespace TDDGroupByThenSumTest
{
    [TestClass]
    public class TDDPartitionThenSumTest
    {
        private static List<Stock> Sources
        {
            get
            {
                return new List<TDDPartitionThenSum.Stock>()
                {
                     new Stock() { Id = 1, Cost = new ColumnCost(1),  Revenue = new ColumnRevenue(11),  SellPrice = new ColumnSellPrice(21)},
                    new Stock() { Id = 2,  Cost = new ColumnCost(2), Revenue = new ColumnRevenue(12),  SellPrice = new ColumnSellPrice(22)},
                    new Stock() { Id = 3,  Cost = new ColumnCost(3), Revenue = new ColumnRevenue(13),  SellPrice = new ColumnSellPrice(23)},
                    new Stock() { Id = 4,  Cost = new ColumnCost(4), Revenue = new ColumnRevenue(14),  SellPrice =new ColumnSellPrice(24)},
                    new Stock() { Id = 5,  Cost = new ColumnCost(5), Revenue = new ColumnRevenue(15),  SellPrice = new ColumnSellPrice(25)},
                    new Stock() { Id = 6,  Cost = new ColumnCost(6), Revenue = new ColumnRevenue(16),  SellPrice = new ColumnSellPrice(26)},
                    new Stock() { Id = 7,  Cost = new ColumnCost(7), Revenue = new ColumnRevenue(17),  SellPrice = new ColumnSellPrice(27)},
                    new Stock() { Id = 8,  Cost = new ColumnCost(8), Revenue = new ColumnRevenue(18),  SellPrice = new ColumnSellPrice(28)},
                    new Stock() { Id = 9,  Cost = new ColumnCost(9), Revenue =new ColumnRevenue(19),  SellPrice = new ColumnSellPrice(29)},
                    new Stock() { Id = 10,  Cost = new ColumnCost(10), Revenue = new ColumnRevenue(20),  SellPrice = new ColumnSellPrice(30)},
                    new Stock() { Id = 11,  Cost = new ColumnCost(11), Revenue = new ColumnRevenue(21),  SellPrice = new ColumnSellPrice(31)},
                };
            }
        }


        [TestMethod]
        public void 驗證GetSumResult_Cost欄位_3個一組()
        {
            //Arrange
            var target = new PartitionThenSum(Sources);
            var rows = 3;
            var expected = new List<int>() { 6, 15, 24, 21 };

            //Act
            List<int> result = target.GetSumResult<ColumnCost>(rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 驗證GetSumResult_Revenue欄位_4個一組()
        {
            //Arrange
            var target = new PartitionThenSum(Sources);
            var rows = 4;
            var expected = new List<int>() { 50, 66, 60 };

            //Act
            List<int> result = target.GetSumResult<ColumnRevenue>(rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
