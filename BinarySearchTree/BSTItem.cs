using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BSTItem
    {
        //public int Value { get; set; }
        //public int Weight { get; set; }
        public Word Word { get; set; }
        public List<Word> Dummies { get; set; }

        public BSTItem(Word word/*int value, int weight = 0*/)
        {
            //Value = value;
            //Weight = weight;
            Word = word;
        }

        public BSTItem(List<Word> dummies)
        {
            Dummies = dummies;
        }

        public override string ToString()
        {
            if (Word == null)
                return $"-- {string.Join(",", Dummies)}";
            if (Dummies == null)
                return $"{Word}";

            return $"{Word} -- {string.Join(",", Dummies)}";
        }
    }

}
