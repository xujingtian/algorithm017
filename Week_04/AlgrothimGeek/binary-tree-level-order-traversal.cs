using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 102. 二叉树的层序遍历 中等  https://leetcode-cn.com/problems/binary-tree-level-order-traversal/
     *给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）。
     */
    public class Solution236 {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode (int x) { val = x; }
        }
        public IList<IList<int>> LevelOrder (TreeNode root) {
            /*
            使用队列，利用队列先进先出的特性进行遍历，要注意的时，为了有层级的输出，
            人为的限定了同一层的数据要出队完成后，再进行循环~~

            loop solution
            o(n) o(n)
            */
            IList<IList<int>> list = new List<IList<int>> ();
            if (root == null)
                return list;
            Queue<TreeNode> queue = new Queue<TreeNode> ();
            queue.Enqueue (root);
            while (queue.Any ()) {
                int size = queue.Count ();
                IList<int> listnode = new List<int> (size);
                for (int i = 0; i < size; i++) {
                    var node = queue.Dequeue ();
                    listnode.Add (node.val);
                    if (node.left != null) {
                        queue.Enqueue (node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue (node.right);
                    }
                }
                list.Add (listnode);
            }
            return list;
        }
        public IList<IList<int>> Bfs (TreeNode root) {
            /*
            只是试了下普通的BFS遍历
            recursion solution 
            o(n) o(n)
            */
            IList<IList<int>> list = new List<IList<int>> ();
            if (root == null)
                return list;
            Queue<TreeNode> queue = new Queue<TreeNode> ();
            queue.Enqueue (root);
            while (queue.Any ()) {
                int size = queue.Count ();
                IList<int> listnode = new List<int> (size);

                var node = queue.Dequeue ();
                listnode.Add (node.val);
                if (node.left != null) {
                    queue.Enqueue (node.left);
                }
                if (node.right != null) {
                    queue.Enqueue (node.right);
                }
                list.Add (listnode);
            }
            return list;
        }
    }
}