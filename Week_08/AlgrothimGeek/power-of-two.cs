using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace AlgrothimGeek {
    public class Solution231 {
        /* 231. 2的幂 简单 https://leetcode-cn.com/problems/power-of-two/
         * 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
         */
        public bool IsPowerOfTwo (int n) {
            /*能2^N整除（N >= 1），则a的二进制表示中，低N位全为0*/
            if (n == 0) return false;
            long x = (long) n;
            return (x & (x - 1)) == 0;
        }
    }
}