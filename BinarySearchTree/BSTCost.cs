namespace BinarySearchTree
{
    public static class BSTCost
    {
        public static int Calculate(BST bst, int level = 0)
        {
            if (bst == null)
                return 0;

            var left = Calculate(bst.Left, level + 1);
            var right = Calculate(bst.Right, level + 1);

            return (bst.Item.Weight * (level + 1)) + left + right;
        }
    }
}
