using System;
using System.Linq;

namespace BinarySearchTree
{
    public class BSTItem
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public BSTItem(int value, int weight = 0)
        {
            Value = value;
            Weight = weight;
        }
    }

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
                if (item.Value == root.Item.Value)
                    throw new Exception($"Value {item.Value} already in tree");

                if (item.Value < root.Item.Value)
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
                else if (item.Value > root.Item.Value)
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
