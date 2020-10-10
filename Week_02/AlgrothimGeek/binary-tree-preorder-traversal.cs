using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 144. 二叉树的前序遍历 中等 https://leetcode-cn.com/problems/binary-tree-preorder-traversal/
     *给定一个二叉树，返回它的 前序 遍历。
     */
    public class Solution144 {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode (int x) { val = x; }
        }
        public IList<int> PreorderTraversal (TreeNode root) {
            /* recursive solution o(n) o(n)*/
            Func<TreeNode, IList<int>, IList<int>> trave = (node, traversePath) => {
                if (node != null) {
                    traversePath.Add (node.val);
                    trave (node.left, traversePath);
                    trave (node.right, traversePath);
                }
                return traversePath;
            };
            return trave (root, new List<int> ());
        }

        public IList<int> PreorderTraversal2 (TreeNode root) {
            /* iterative solution  o(n) o(n)*/
            var traversePath = new List<int> ();
            var stack = new Stack<TreeNode> ();
            while (stack.Any () || root != null) {
                //if ---> 先把left压入stack，直至为null,此时 缓存中全是根-左的重复，stack中全是左-根的重复
                //else ---> 出栈，并将root变为右
                //
                if (root != null) {
                    traversePath.Add (root.val);
                    stack.Push (root);
                    root = root.left;
                } else {
                    root = stack.Pop ();
                    root = root.right;
                }

            }
            return traversePath;
        }
    }
}