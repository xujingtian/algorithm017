using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    public class Solution127 {
        /* 127. 单词接龙 中等 https://leetcode-cn.com/problems/word-ladder/
         *给定两个单词（beginWord 和 endWord）和一个字典，找到从 beginWord 到 endWord 的最短转换序列的长度。转换需遵循如下规则： 
         *1、每次转换只能改变一个字母。
         *2、转换过程中的中间单词必须是字典中的单词。
         */
        public int LadderLength (string beginWord, string endWord, IList<string> wordList) {
            /* o(n) o(n) */
            HashSet<string> wordSet = new HashSet<string> (wordList);
            HashSet<string> beginSet = new HashSet<string> ();
            HashSet<string> endSet = new HashSet<string> ();

            int len = 1;
            int strLen = beginWord.Length;
            HashSet<string> vistited = new HashSet<string> ();

            beginSet.Add (beginWord);
            endSet.Add (endWord);
            while (beginSet.Any () && endSet.Any ()) {
                if (beginSet.Count () > endSet.Count ()) {
                    HashSet<string> set = beginSet;
                    beginSet = endSet;
                    endSet = set;
                }
                HashSet<string> temp = new HashSet<string> ();
                foreach (var word in beginSet) {
                    char[] chs = word.ToCharArray ();
                    //Console.WriteLine ("oldword:" + word);
                    for (int i = 0; i < chs.Length; i++) {
                        for (char c = 'a'; c <= 'z'; c++) {
                            char old = chs[i];
                            chs[i] = c;
                            string target = new string (chs);
                            //Console.WriteLine ("newword:" + target);
                            if (endSet.Contains (target)) {
                                return len + 1;
                            }
                            if (!vistited.Contains (target) && wordSet.Contains (target)) {
                                temp.Add (target);
                                vistited.Add (target);
                            }
                            chs[i] = old;
                        }
                    }
                }
                beginSet = temp;
                len++;
            }
            return 0;
        }

        public class UnionFind {
            private int count = 0;
            private int[] parent;
            public UnionFind (int n) {
                count = n;
                parent = new int[n];
                for (int i = 0; i < n; i++) {
                    parent[i] = i;
                }
            }
            public void Union (int p, int q) {
                int rootP = Find (p);
                int rootQ = Find (q);
                if (rootP == rootQ) return;
                parent[rootP] = rootQ;
                count--;
            }
            public int Find (int p) {
                while (p != parent[p]) {
                    parent[p] = parent[parent[p]];
                    p = parent[p];
                }
                return p;
            }
        }
    }
}