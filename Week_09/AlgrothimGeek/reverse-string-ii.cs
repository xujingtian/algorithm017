using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace AlgrothimGeek {
    /* 541. 反转字符串 II 简单 https://leetcode-cn.com/problems/reverse-string-ii/
     *给定一个字符串 s 和一个整数 k，你需要对从字符串开头算起的每隔 2k 个字符的前 k 个字符进行反转。
     *如果剩余字符少于 k 个，则将剩余字符全部反转。
     *如果剩余字符小于 2k 但大于或等于 k 个，则反转前 k 个字符，其余字符保持原样。
     */
    public class Solution541 {
        public string ReverseStr (string s, int k) {
            char[] a = s.ToCharArray ();
            for (int start = 0; start < a.Length; start += 2 * k) {
                int i = start;
                int j = Math.Min (start + k - 1, a.Length - 1);
                while (i < j) {
                    char tmp = a[i];
                    a[i++] = a[j];
                    a[j--] = tmp;
                }
            }
            return new String (a);
        }
    }
}