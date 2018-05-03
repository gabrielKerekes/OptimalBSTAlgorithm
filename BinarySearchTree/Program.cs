using System;
using System.IO;

// 7 bis, 14 - 15,

namespace BinarySearchTree
{
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            var algorithm = new Algorithm();

            //int sum = 0;
            //int i = 0;
            //foreach (var line in File.ReadLines("myDictionary.txt"))
            foreach (var line in File.ReadLines("dictionary.txt"))
            {
                var word = Word.FromLine(line);
                algorithm.Add(word);

                //sum += word.Count;
                //i++;
                //Console.WriteLine($"{i} -> {sum} -> {word.Count} -> {word.Probability}");
            }

            foreach (var dummy in algorithm.Dummies)
            {
                algorithm.AddDummyToKey(dummy);
            }

            algorithm.FillEmptyDummiesForKeys();

            //Console.WriteLine(sum);

            //var s = 0;
            //foreach (var key in algorithm.Keys)
            //{
            //    Console.WriteLine($"{key} -> {string.Join(", ", algorithm.KeyDummies[s])}");
            //    s++;
            //}
            //Console.WriteLine($"dn -> {string.Join(", ", algorithm.KeyDummies[algorithm.Keys.Count])}");

            //Console.WriteLine("----------------------");

            //foreach (var dummy in algorithm.Dummies)
            //{
            //    Console.WriteLine(dummy);
            //}

            var result = algorithm.OptimalBst();

            //foreach (var e in result.Item1)
            //{
            //    foreach (var e2 in e)
            //    {
            //        Console.Write($"{e2}, ");
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine("--------------------------------");

            //foreach (var e in result.Item2)
            //{
            //    foreach (var e2 in e)
            //    {
            //        Console.Write($"{e2}, ");
            //    }

            //    Console.WriteLine();
            //}

            // todo: skoncene pri tom, ze musim z tabulky postavit strom...

            for (var i = 0; i < result.Item2.Length; i++)
            {
                for (var j = 0; j < result.Item2[i].Length; j++)
                {
                    result.Item2[i][j]--;
                }
            }

            //var table = result.Item2;
            //var rootIndex = table[0][table[0].Length - 1];
            //var root = algorithm.Keys[rootIndex];
            //Console.WriteLine(root);
            //var leftIndex = table[0][rootIndex - 1];
            //var left = algorithm.Keys[leftIndex];
            //Console.WriteLine(left);
            //var rightIndex = table[rootIndex + 1][table[0].Length - 1];
            //var right = algorithm.Keys[rightIndex];
            //Console.WriteLine(right);

            var bst = BST.FromTable(algorithm.Keys, algorithm.KeyDummies, result.Item2);
            Console.WriteLine(BSTCost.Calculate(bst));
            Console.WriteLine($"after - {bst.Search("after")}");
            Console.WriteLine($"i - {bst.Search("i")}");
            Console.WriteLine($"if - {bst.Search("if")}");
            Console.WriteLine($"mr - {bst.Search("mr")}");
            Console.WriteLine($"own - {bst.Search("own")}");
            Console.WriteLine($"very - {bst.Search("very")}");
            Console.WriteLine($"year - {bst.Search("year")}");
            Console.WriteLine($"yes - {bst.Search("yes")}");
            Console.WriteLine($"our - {bst.Search("our")}");
            Console.WriteLine($"might - {bst.Search("might")}");
        }
    }
}
