using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  42. 接雨水 困难 https://leetcode-cn.com/problems/trapping-rain-water/
     *给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
     */
    public class Solution42 {
        public int Trap (int[] height) {
            //o(n^2) o(1)
            int ans = 0;
            int size = height.Length;
            for (int i = 1; i < size - 1; i++) {
                int max_left = 0, max_right = 0;
                for (int j = i; j >= 0; j--) { //Search the left part for max bar size
                    max_left = Math.Max (max_left, height[j]);
                }
                for (int j = i; j < size; j++) { //Search the right part for max bar size
                    max_right = Math.Max (max_right, height[j]);
                }
                ans += Math.Min (max_left, max_right) - height[i];
            }
            return ans;
        }
    }
}