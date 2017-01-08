using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPartitionThenSum;
using System.Collections.Generic;


namespace TDDGroupByThenSumTest
{
    [TestClass]
    public class TDDPartitionThenSumTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var target = new PartitionThenSum();
            var rows = 3;
            var expected = new List<int>() { 6, 15, 24, 21 };

            //Act
            List<int> result = target.GetSumResult<ColumnCost>(rows);

            //Assert            
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
