using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BSTCostTests
    {
        private readonly BSTItem[] TestValues1 = new[]
        {
            new BSTItem(1, 4),
            new BSTItem(2, 10),
            new BSTItem(3, 2),
            new BSTItem(4, 7),
        };

        [Test]
        public void Calculate_EmptyTree_ReturnsZero()
        {
            var expectedValue = 0;
            var actualValue = BSTCost.Calculate(null);

            Assert.AreEqual(expectedValue, actualValue);
        }

        //       3
        //      / \
        //     2   4
        //    /
        //   1
        [Test]
        public void Calculate_Test1()
        {
            var root = TestValues1[2];
            var value2 = TestValues1[1];
            var value3 = TestValues1[0];
            var value4 = TestValues1[3];

            var bst = new BST(root);
            bst.Add(value2);
            bst.Add(value3);
            bst.Add(value4);

            var expectedValue = 48;
            var calculatedValue = BSTCost.Calculate(bst);

            Assert.AreEqual(expectedValue, calculatedValue);
        }

        //       2
        //      / \
        //     1   3
        //          \
        //           4
        [Test]
        public void Calculate_Test2()
        {
            var root = TestValues1[1];
            var value2 = TestValues1[0];
            var value3 = TestValues1[2];
            var value4 = TestValues1[3];

            var bst = new BST(root);
            bst.Add(value2);
            bst.Add(value3);
            bst.Add(value4);

            var expectedValue = 43;
            var calculatedValue = BSTCost.Calculate(bst);

            Assert.AreEqual(expectedValue, calculatedValue);
        }

        //       4
        //      /
        //     3
        //    /
        //   1 
        //    \
        //     2
        [Test]
        public void Calculate_Test3()
        {
            var root = TestValues1[3];
            var value2 = TestValues1[2];
            var value3 = TestValues1[0];
            var value4 = TestValues1[1];

            var bst = new BST(root);
            bst.Add(value2);
            bst.Add(value3);
            bst.Add(value4);

            var expectedValue = 63;
            var calculatedValue = BSTCost.Calculate(bst);

            Assert.AreEqual(expectedValue, calculatedValue);
        }

        //  1
        //   \
        //    2
        //     \
        //      3
        //       \
        //        4
        [Test]
        public void Calculate_Test4()
        {
            var root = TestValues1[0];
            var value2 = TestValues1[1];
            var value3 = TestValues1[2];
            var value4 = TestValues1[3];

            var bst = new BST(root);
            bst.Add(value2);
            bst.Add(value3);
            bst.Add(value4);

            var expectedValue = 58;
            var calculatedValue = BSTCost.Calculate(bst);

            Assert.AreEqual(expectedValue, calculatedValue);
        }
    }
}