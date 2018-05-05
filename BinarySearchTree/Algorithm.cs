using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinarySearchTree
{
    public class Algorithm
    {
#if SKOLA
        public const int SumOfCounts = 82540704;
        public const int KeyThreshold = 50000;
#endif
#if MOJE
        public const int SumOfCounts = 423;
        public const int KeyThreshold = 50;
#endif


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

        public Tuple<double[][], int[][]> OptimalBst()
        {
            var keyProbs = Keys.Select(k => k.Probability).ToArray();
        
            var dummyProbs = new double[KeyDummies.Count];
            foreach (var keyDummy in KeyDummies)
            {
                dummyProbs[keyDummy.Key] = keyDummy.Value.Sum(d => d.Probability);
            }

            return OptimalBst(keyProbs, dummyProbs);
        }

        public static Tuple<double[][], int[][]> OptimalBst(double[] keyProbs, double[] dummyProbs)
        {
            var keyProbsList = keyProbs.ToList();
            keyProbsList.Insert(0, 0);
            keyProbs = keyProbsList.ToArray();

            //var dummyProbsList = keyProbs.ToList();
            //dummyProbsList.Insert(0, 0);
            //dummyProbs = dummyProbsList.ToArray();

            var n = keyProbs.Length - 1;

            var e = new double[n + 2][];
            var w = new double[n + 2][];
            var root = new int[n][];
            for (var i = 1; i <= n + 1; i++)
            {
                e[i] = new double[n + 1];
                w[i] = new double[n + 1];
                if (i <= n)
                    root[i - 1] = new int[n];
            }

            for (var i = 1; i <= n + 1; i++)
            {
                e[i][i - 1] = dummyProbs[i - 1];
                w[i][i - 1] = dummyProbs[i - 1];
            }

            for (var l = 1; l <= n; l++)
            {
                for (var i = 1; i <= n - l + 1; i++)
                {
                    var j = i + l - 1;
                    e[i][j] = double.PositiveInfinity;
                    w[i][j] = w[i][j - 1] + keyProbs[j] + dummyProbs[j];

                    for (var r = i; r <= j; r++)
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
 