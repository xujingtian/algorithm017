using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 105. 从前序与中序遍历序列构造二叉树 中等  https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
     *根据一棵树的前序遍历与中序遍历构造二叉树。
     */
    public class Solution105 {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode (int x) { val = x; }
        }
        private Dictionary<int, int> indexMap;
        public TreeNode BuildTree (int[] preorder, int[] inorder) {
            /* pre-order:前 左 右
             * in-order: 左 前 右
             * 没想出来，直接用题解思路走了
             * o(n) o(n)
             */
            int n = preorder.Length;
            // 构造哈希映射，快速定位根节点
            indexMap = new Dictionary<int, int> ();
            for (int i = 0; i < n; i++) {
                indexMap.Add (inorder[i], i);
            }
            return MyBuildTree (preorder, inorder, 0, n - 1, 0, n - 1);

        }

        public TreeNode MyBuildTree (int[] preorder, int[] inorder, int preorder_left, int preorder_right, int inorder_left, int inorder_right) {
            if (preorder_left > preorder_right) {
                return null;
            }
            // 前序遍历中的第一个节点就是根节点
            int preorder_root = preorder_left;
            // 在中序遍历中定位根节点
            int inorder_root = indexMap[preorder[preorder_root]];

            // 先把根节点建立出来
            TreeNode root = new TreeNode (preorder[preorder_root]);
            // 得到左子树中的节点数目
            int size_left_subtree = inorder_root - inorder_left;
            // 递归地构造左子树，并连接到根节点
            // 先序遍历中「从 左边界+1 开始的 size_left_subtree」个元素就对应了中序遍历中「从 左边界 开始到 根节点定位-1」的元素
            root.left = MyBuildTree (preorder, inorder, preorder_left + 1, preorder_left + size_left_subtree, inorder_left, inorder_root - 1);
            // 递归地构造右子树，并连接到根节点
            // 先序遍历中「从 左边界+1+左子树节点数目 开始到 右边界」的元素就对应了中序遍历中「从 根节点定位+1 到 右边界」的元素
            root.right = MyBuildTree (preorder, inorder, preorder_left + size_left_subtree + 1, preorder_right, inorder_root + 1, inorder_right);
            return root;
        }

    }
}