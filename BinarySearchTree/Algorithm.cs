using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinarySearchTree
{
    public class Algorithm
    {
        public const int SumOfCounts = 82540704;
        public const int KeyThreshold = 50000;
        //public const int SumOfCounts = 423;
        //public const int KeyThreshold = 50;


        public List<Word> Keys { get; set; } = new List<Word>();
        public Dictionary<int, List<Word>> KeyDummies { get; set; } = new Dictionary<int, List<Word>>();
        public List<Word> Dummies { get; set; } = new List<Word>();

        public void Add(Word word)
        {
            if (word.Count > KeyThreshold)
                AddKey(word);
            else
                AddDummy(word);
        }

        private void AddKey(Word key)
        {
            SortedAdd(Keys, key);
        }

        private void AddDummy(Word dummy)
        {
            SortedAdd(Dummies, dummy);
            //AddDummyToKey(dummy);
        }

        private void SortedAdd(List<Word> list, Word word)
        {
            var index = list.BinarySearch(word);
            if (index < 0)
                index = ~index;

            list.Insert(index, word);
        }

        public void AddDummyToKey(Word dummy)
        {
            var index = Keys.BinarySearch(dummy);
            if (index < 0)
                index = ~index;

            if (!KeyDummies.ContainsKey(index))
                KeyDummies[index] = new List<Word>();

            KeyDummies[index].Add(dummy);
        }

        public void FillEmptyDummiesForKeys()
        {
            for (var i = 0; i < Keys.Count; i++)
            {
                if (!KeyDummies.ContainsKey(i))
                    KeyDummies[i] = new List<Word>();
            }
        }

        public Tuple<float[][], int[][]> OptimalBst(/*List<double> keyProbs, List<double> dummyProbs*/)
        {
            var sw = Stopwatch.StartNew();

            var keyProbs = Keys.Select(k => k.Probability).ToArray();
            var dummyProbs = KeyDummies.Select(kvp => kvp.Value.Sum(d => d.Probability)).ToArray();
            //dummyProbs.Insert(0, 0);

            var n = keyProbs.Length /*+ dummyProbs.Count*/;

            var e = new float[n + 2][];
            var w = new float[n + 2][];
            var root = new int[n][];
            for (var i = 0; i < n + 2; i++)
            {
                e[i] = new float[n + 1];
                w[i] = new float[n + 1];
                if (i < n)
                    root[i] = new int[n];
            }

            for (var i = 1; i < n + 1; i++)
            {
                e[i][i - 1] = dummyProbs[i - 1];
                w[i][i - 1] = dummyProbs[i - 1];
            }

            for (var l = 1; l < n + 1; l++)
            {
                //if (l % 300 == 0)
                //{
                //    Console.WriteLine($"{l}/{n} -- {sw.Elapsed.TotalMilliseconds}");
                //}

                for (var i = 1; i < n - l + 2; i++)
                {
                    var j = i + l - 1;
                    e[i][j] = float.PositiveInfinity;
                    w[i][j] = w[i][j - 1] + keyProbs[j - 1] + dummyProbs[j - 1];
                    for (var r = i; r < j + 1; r++)
                    {
                        var t = e[i][r - 1] + e[r + 1][j] + w[i][j];
                        if (t < e[i][j])
                        {
                            e[i][j] = t;
                            root[i - 1][j - 1] = r;
                        }
                    }
                }
            }

            return Tuple.Create(e, root);
        }
    }
}
