using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
            var parm = new Parameter()
            {
                Rows = 3,
                ParticularColumn = Columns.Cost
            };

            var expected = new List<int>() { 6, 151, 24, 21 };

            //Act
            List<int> result = target.GetSumResult(parm);
            //Assert
        }
    }
}
