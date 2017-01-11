using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
    public class Stock
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public int Revenue { get; set; }

        public int SellPrice { get; set; }
    }

    public abstract class ColumnBase
    {
        public ColumnBase(int value)
        {
            this.Value = value;
        }
        public int Value { get; set; }
    }

    public class ColumnCost : ColumnBase
    {
        public ColumnCost(int value) : base(value)
        {
        }
    }

    public class ColumnRevenue : ColumnBase
    {
        public ColumnRevenue(int value) : base(value)
        {
        }
    }

    public class ColumnSellPrice : ColumnBase
    {
        public ColumnSellPrice(int value) : base(value)
        {
        }
    }
}
