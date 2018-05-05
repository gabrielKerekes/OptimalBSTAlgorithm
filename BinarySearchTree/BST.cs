using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTree
{
    public class BST
    {
        public BST Left { get; set; }
        public BST Right { get; set; }
        public BSTItem Item { get; set; }

        public BST(BSTItem rootItem)
        {
            Item = rootItem;
        }

        public static BST FromArray(BSTItem[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            var bst = new BST(array[0]);

            foreach (var i in array.Skip(1))
            {
                bst.Add(i);
            }

            return bst;
        }

        private class Help
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public Help(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }

        public static BST FromTable(List<Word> keys, Dictionary<int, List<Word>> keyDummies, int[][] table)
        {
            var stack = new Queue<Help>();
            var rootHelp = new Help(0, table.Length - 1);
            stack.Enqueue(rootHelp);

            var rootIndex = table[rootHelp.Row][rootHelp.Column];
            var rootItem = new BSTItem(keys[rootIndex]);
            var bst = new BST(rootItem);
            keys[rootIndex].Added = true;

            while (stack.Count != 0)
            {
                var current = stack.Dequeue();
                if (current.Row > current.Column)
                {
                    if (keyDummies[current.Row].Count > 0 && !keyDummies[current.Row][0].Added)
                    {
                        bst.Add(new BSTItem(keyDummies[current.Row]));
                        keyDummies[current.Row][0].Added = true;
                    }

                    //if (current.Row < keyDummies.Count - 1)
                    //{
                    //    if (keyDummies[current.Row + 1].Count > 0 && !keyDummies[current.Row + 1][0].Added)
                    //    {
                    //        bst.Add(new BSTItem(keyDummies[current.Row + 1]));
                    //        keyDummies[current.Row + 1][0].Added = true;
                    //    }
                    //}
                    if (keyDummies[current.Column + 1].Count > 0 && !keyDummies[current.Column + 1][0].Added)
                    {
                        bst.Add(new BSTItem(keyDummies[current.Column + 1]));
                        keyDummies[current.Column + 1][0].Added = true;
                    }
                }
                else
                {
                    var currentItemIndex = table[current.Row][current.Column];

                    stack.Enqueue(new Help(current.Row, currentItemIndex - 1));
                    stack.Enqueue(new Help(currentItemIndex + 1, current.Column));

                    if (keys[currentItemIndex].Added)                           
                        continue;

                    //var subBst = new BST(new BSTItem(keys[currentItemIndex]));

                    bst.Add(new BSTItem(keys[currentItemIndex]));
                    keys[currentItemIndex].Added = true;

                    //if (current.Row == current.Column)
                    //{
                    //    subBst.Add(new BSTItem(keyDummies[currentItemIndex]));
                    //    subBst.Add(new BSTItem(keyDummies[currentItemIndex + 1]));
                    //}   
                }
            }

            return bst;
        }

        //public void Add(BSTItem item)
        //{
        //    if (item.Value == Item.Value)
        //        throw new Exception("Value already in tree");

        //    if (item.Value < Item.Value)
        //    {
        //        AddLeft(item);
        //    }
        //    else if (item.Value > Item.Value)
        //    {
        //        AddRight(item);
        //    }
        //}

        public void Add(BSTItem item)
        {
            var root = this;
            while (true)
            {
                if (item.Word != null && item.Word == root.Item.Word)
                    throw new Exception($"Value {item.Word} already in tree");

                if (item.Word == null)
                {
                    if (item.Dummies[0].CompareTo(root.Item.Word) < 0)
                    {
                        if (root.Left != null)
                        {
                            root = root.Left;
                            continue;
                        }
                        else
                        {
                            root.Left = new BST(item);
                            return;
                        }
                    }
                    else if (item.Dummies[0].CompareTo(root.Item.Word) > 0)
                    {
                        if (root.Right != null)
                        {
                            root = root.Right;
                            continue;
                        }
                        else
                        {
                            root.Right = new BST(item);
                            return;
                        }
                    }
                    return;
                }
                else
                {
                    if (item.Word.CompareTo(root.Item.Word) < 0)
                    {
                        if (root.Left != null)
                        {
                            root = root.Left;
                            continue;
                        }
                        else
                        {
                            root.Left = new BST(item);
                            return;
                        }
                    }
                    else if (item.Word.CompareTo(root.Item.Word) > 0)
                    {
                        if (root.Right != null)
                        {
                            root = root.Right;
                            continue;
                        }
                        else
                        {
                            root.Right = new BST(item);
                            return;
                        }
                    }
                }
            }
        }

        public void AddDummiesLeft(List<Word> dummies)
        {
            Left.Item.Dummies = dummies;
        }

        public void AddDummiesRight(List<Word> dummies)
        {
            Right.Item.Dummies = dummies;
        }

        public int Search(string str)
        {
            var count = 0;

            var current = this;
            while (true)
            {
                int comparisonResult;
                if (current.Item.Word != null)
                    comparisonResult = string.CompareOrdinal(str, current.Item.Word.Value);
                else
                    comparisonResult = 0;//string.CompareOrdinal(str, current.Item.Word.Value);

                count++;

                if (comparisonResult < 0)
                {
                    if (current.Left == null)
                        return count;

                    current = current.Left;
                }
                else if (comparisonResult > 0)
                {
                    if (current.Right == null)
                        return count;

                    current = current.Right;
                }
                else
                {
                    return count;
                }
            }
        }

        //private void AddLeft(BSTItem value)
        //{
        //    if (Left == null)
        //    {
        //        Left = new BST(value);
        //    }
        //    else
        //    {
        //        Left.Add(value);
        //    }
        //}

        //private void AddRight(BSTItem value)
        //{
        //    if (Right == null)
        //    {
        //        Right = new BST(value);
        //    }
        //    else
        //    {
        //        Right.Add(value);
        //    }
        //}
    }
}
