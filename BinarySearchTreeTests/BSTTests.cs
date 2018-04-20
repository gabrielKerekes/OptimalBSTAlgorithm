using System;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BSTTests
    {
        [Test]
        public void Constructor_SetsRoot()
        {
            var testValue = new BSTItem(123);
            var bst = new BST(testValue);

            Assert.AreEqual(testValue, bst.Item);
        }

        [Test]
        public void Constructor_LeftAndRightAreNull()
        {
            var bst = new BST(new BSTItem(0));

            Assert.IsNull(bst.Left);
            Assert.IsNull(bst.Right);
        }

        [Test]
        public void Add_SmallerValueGoesLeft()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            var testValue = new BSTItem(-1);
            bst.Add(testValue);

            var left = bst.Left;
            Assert.AreEqual(testValue.Value, left.Item.Value);
        }

        [Test]
        public void Add_LargerValueGoesRight()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            var testValue = new BSTItem(1);
            bst.Add(testValue);

            var right = bst.Right;
            Assert.AreEqual(testValue.Value, right.Item.Value);
        }

        [Test]
        public void Add_EqualValueThrows()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            Assert.Throws<Exception>(() => bst.Add(rootValue));
        }

        [Test]
        public void Add_SmallerValueGoesLeft_MultipleLevels()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            var testValue1 = new BSTItem(-1);
            bst.Add(testValue1);

            var testValue2 = new BSTItem(-2);
            bst.Add(testValue2);

            var testValue3 = new BSTItem(-3);
            bst.Add(testValue3);

            var left1 = bst.Left;
            Assert.AreEqual(testValue1.Value, left1.Item.Value);
            var left2 = left1.Left;
            Assert.AreEqual(testValue2.Value, left2.Item.Value);
            var left3 = left2.Left;
            Assert.AreEqual(testValue3.Value, left3.Item.Value);
        }

        [Test]
        public void Add_LargerValueGoesRight_MultipleLevels()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            var testValue1 = new BSTItem(1);
            bst.Add(testValue1);

            var testValue2 = new BSTItem(2);
            bst.Add(testValue2);

            var testValue3 = new BSTItem(3);
            bst.Add(testValue3);

            var right1 = bst.Right;
            Assert.AreEqual(testValue1.Value, right1.Item.Value);
            var right2 = right1.Right;
            Assert.AreEqual(testValue2.Value, right2.Item.Value);
            var right3 = right2.Right;
            Assert.AreEqual(testValue3.Value, right3.Item.Value);
        }

        [Test]
        public void Add_ZigZag()
        {
            var rootValue = new BSTItem(0);
            var bst = new BST(rootValue);

            var testValue1 = new BSTItem(3);
            bst.Add(testValue1);

            var testValue2 = new BSTItem(1);
            bst.Add(testValue2);

            var testValue3 = new BSTItem(2);
            bst.Add(testValue3);

            var right1 = bst.Right;
            Assert.AreEqual(testValue1.Value, right1.Item.Value);
            var left2 = right1.Left;
            Assert.AreEqual(testValue2.Value, left2.Item.Value);
            var right3 = left2.Right;
            Assert.AreEqual(testValue3.Value, right3.Item.Value);
        }

        // 1
        //  \
        //   2
        //    \
        //     3
        //      \
        //       4
        [Test]
        public void FromArray_Test1()
        {
            var testArray = new[] { new BSTItem(1), new BSTItem(2), new BSTItem(3), new BSTItem(4) };
            var bst = BST.FromArray(testArray);

            Assert.AreEqual(testArray[0].Value, bst.Item.Value);
            Assert.AreEqual(testArray[1].Value, bst.Right.Item.Value);
            Assert.AreEqual(testArray[2].Value, bst.Right.Right.Item.Value);
            Assert.AreEqual(testArray[3].Value, bst.Right.Right.Right.Item.Value);
        }

        //       3
        //      / \
        //     2   4
        //    /
        //   1
        [Test]
        public void FromArray_Test2()
        {
            var testArray = new[] { new BSTItem(3), new BSTItem(2), new BSTItem(1), new BSTItem(4) };
            var bst = BST.FromArray(testArray);

            Assert.AreEqual(testArray[0].Value, bst.Item.Value);
            Assert.AreEqual(testArray[1].Value, bst.Left.Item.Value);
            Assert.AreEqual(testArray[2].Value, bst.Left.Left.Item.Value);
            Assert.AreEqual(testArray[3].Value, bst.Right.Item.Value);
        }
    }
}