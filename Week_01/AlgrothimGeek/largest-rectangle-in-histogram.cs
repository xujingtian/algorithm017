using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /* 84. 柱状图中最大的矩形 困难  https://leetcode-cn.com/problems/largest-rectangle-in-histogram/
     *给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
     *求在该柱状图中，能够勾勒出来的矩形的最大面积。 
     */
    public class Solution84 {
        public int LargestRectangleArea (int[] heights) {
            //o(n^2) o(1)
            int len = heights.Length;
            int minHeight = -1;
            int maxArea = 0;
            for (int i = 0; i < len; i++) {
                minHeight = heights[i];
                for (int j = i; j < len; j++) {
                    minHeight = Math.Min (minHeight, heights[j]);
                    maxArea = Math.Max ((j - i) * minHeight, maxArea);
                }
            }
            return maxArea;
        }
        public int LargestRectangleArea2 (int[] heights) {
            //o(n) o(n)
            int len = heights.Length;
            if (len == 0)
                return 0;
            if (len == 1)
                return heights[0];
            int maxArea = 0;
            int width = 0;
            Stack<int> stack = new Stack<int> ();
            for (int i = 0; i < len; i++) {
                while (stack.Count != 0 && heights[stack.Peek ()] > heights[i]) {
                    int height = heights[stack.Pop ()];
                    while (stack.Count != 0 && heights[stack.Peek ()] == height) {
                        stack.Pop ();
                    }
                    if (stack.Count == 0) {
                        width = i;
                    } else {
                        width = i - stack.Peek () - 1;
                    }
                    maxArea = Math.Max (height * width, maxArea);
                }
                stack.Push (i);
            }
            while (stack.Count != 0) {
                int height = heights[stack.Pop ()];
                while (stack.Count != 0 && heights[stack.Peek ()] == height) {
                    stack.Pop ();
                }
                if (stack.Count == 0) {
                    width = len;
                } else {
                    width = len - stack.Peek () - 1;
                }
                maxArea = Math.Max (height * width, maxArea);
            }
            return maxArea;
        }

        public int LargestRectangleArea3 (int[] heights) {
            //o(n) o(n)
            int len = heights.Length;
            if (len == 0)
                return 0;
            if (len == 1)
                return heights[0];
            int maxArea = 0;
            int width = 0;
            int[] newHeights = new int[len + 2];
            for (int i = 0; i < len; i++) {
                newHeights[i + 1] = heights[i];
            }
            len = len + 2;
            heights = newHeights;
            Stack<int> stack = new Stack<int> ();
            stack.Push (0);
            for (int i = 1; i < len; i++) {
                while (heights[stack.Peek ()] > heights[i]) {
                    int height = heights[stack.Pop ()];
                    width = i - stack.Peek () - 1;
                    maxArea = Math.Max (height * width, maxArea);
                }
                stack.Push (i);
            }
            return maxArea;
        }
    }
}