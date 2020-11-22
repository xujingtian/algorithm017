using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace AlgrothimGeek {
    public class Solution191 {
        /* 191. 位1的个数 简单 https://leetcode-cn.com/problems/number-of-1-bits/
         *编写一个函数，输入是一个无符号整数（以二进制串的形式），
         *返回其二进制表达式中数字位数为 '1' 的个数（也被称为汉明重量）。
         */
        public int HammingWeight (uint n) {
            int count = 0;
            while (n > 0) {
                if ((n & 1) == 1) count++;
                n = n >> 1;
            }
            return count;
        }

    }
}