using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class ItemProbability
    {
        public static double Sum = 0;

        public double CalculateSum(BSTItem[] items)
        {
            Sum = 0;

            foreach (var item in items)
            {
                Sum += item.Word.Count;
            }

            return Sum;
        }

        public double CalculateItemProbability(int itemWeight)
        {
            return ((double) itemWeight) / Sum;
        }
    }
}
