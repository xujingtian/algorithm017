using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    public class Solution647 {
        /* 647. 回文子串 中等 https://leetcode-cn.com/problems/palindromic-substrings/
         *给定一个字符串，你的任务是计算这个字符串中有多少个回文子串。
         *具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被视作不同的子串。 
         */
        public int CountSubstrings (string s) {
            /* o(n^2) o(n^2) */
            if (string.IsNullOrEmpty (s)) {
                return 0;
            }
            int n = s.Length;
            bool[, ] dp = new bool[n, n];
            int result = s.Length;
            for (int i = 0; i < n; i++) dp[i, i] = true;
            for (int i = n - 1; i >= 0; i--) {
                for (int j = i + 1; j < n; j++) {
                    if (s[i] == s[j]) {
                        if (j - i == 1) {
                            dp[i, j] = true;
                        } else {
                            dp[i, j] = dp[i + 1, j - 1];
                        }
                    } else {
                        dp[i, j] = false;
                    }
                    if (dp[i, j]) {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}