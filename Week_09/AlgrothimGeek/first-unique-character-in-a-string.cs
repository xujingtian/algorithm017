using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace AlgrothimGeek {
    /* 387. 字符串中的第一个唯一字符 简单 https://leetcode-cn.com/problems/first-unique-character-in-a-string/
     *给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。 
     */
    public class Solution387 {

        public int FirstUniqChar (string s) {
            /*  o(n) o(n) */
            Dictionary<int, int> dicCount = new Dictionary<int, int> ();
            int idx = -1;
            for (int i = 0; i < s.Length; i++) {
                if (!dicCount.ContainsKey (s[i]))
                    dicCount.Add (s[i], 0);
                dicCount[s[i]] += 1;
            }
            for (int i = 0; i < s.Length; i++) {
                if (dicCount[s[i]] == 1) {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
    }
}