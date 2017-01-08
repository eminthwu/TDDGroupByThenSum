using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPartitionThenSum
{
   public class Parameter
    {
        public Columns ParticularColumn { get; set; }

        public int Rows { get; set; }
    }

    public enum Columns
    {
        ID,Cost,Revenue,SellPrice
    }
}
