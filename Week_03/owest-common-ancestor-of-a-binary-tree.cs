using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 236. 二叉树的最近公共祖先 中等  https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/
     *给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
     *
     *百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，
     *满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”
     */
    public class Solution236 {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode (int x) { val = x; }
        }
        private TreeNode ans;
        public TreeNode LowestCommonAncestor (TreeNode root, TreeNode p, TreeNode q) {
            /* 判断 子树中是否包含 p,q,包含2
            种情况 
             *  1) 树中，左节点包含p/q,右节点包含q/p 
             *  2) 根节点为p/q,左子树/右子树中 包含 q/p
            *N 是二叉树的节点数。二叉树的所有节点有且只会被访问一次，因此时间复杂度为 O(N)。
            *递归调用的栈深度取决于二叉树的高度，二叉树最坏情况下为一条链，此时高度为 N，因此空间复杂度为 O(N)。
             */
            Dfs (root, p, q);
            return this.ans;
        }

        private bool Dfs (TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) return false;
            bool lson = Dfs (root.left, p, q);
            bool rson = Dfs (root.right, p, q);
            if ((lson && rson) ||
                ((root.val == p.val || root.val == q.val) && (lson || rson))
            ) {
                ans = root;
            }
            //此处是第一步判断，左树中有，或者树中有
            return lson || rson || (root.val == p.val || root.val == q.val);
        }

    }
}