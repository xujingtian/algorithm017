using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    public class Solution64 {
        /* 64. 最小路径和 中等 https://leetcode-cn.com/problems/minimum-path-sum/
         *给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。 
         *说明：每次只能向下或者向右移动一步。
         */
        public int MinPathSum (int[][] grid) {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
                return 0;
            }
            int rows = grid.Length;
            int cols = grid[0].Length;
            //此处使用多维数组，没有使用交错数组的原因是还要初始化一下：（
            int[, ] dp = new int[rows, cols];
            dp[0, 0] = grid[0][0];
            for (int i = 1; i < rows; i++) {
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            }
            for (int j = 1; j < cols; j++) {
                dp[0, j] = dp[0, j - 1] + grid[0][j];
            }
            for (int i = 1; i < rows; i++) {
                for (int j = 1; j < cols; j++) {
                    dp[i, j] = Math.Min (dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[rows - 1, cols - 1];
        }
        public int MinPathSum2 (int[][] grid) { //自顶向下进计算
            /*O(mn) O(mn)*/
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
                return 0;
            }
            int rows = grid.Length;
            int cols = grid[0].Length;
            int[][] dp = new int[rows][];
            //此处是因为 C#中，交错数组语法问题，可以使用多维度数组代替，但是写法上看着有点不太和谐
            //多维数组 int[, ] dp = new int[rows, cols];没有影响总体时间复杂度
            for (int i = 0; i < rows; i++) {
                dp[i] = new int[cols];
            }
            dp[0][0] = grid[0][0];
            //row = 0,col = 0 的情况也可以双循环中进行判断，但是这么写感觉比较清楚，没有影响总体时间复杂度
            //这算不算一种剪枝？
            for (int i = 1; i < rows; i++) {
                dp[i][0] = dp[i - 1][0] + grid[i][0];
            }
            for (int j = 1; j < cols; j++) {
                dp[0][j] = dp[0][j - 1] + grid[0][j];
            }
            for (int i = 1; i < rows; i++) {
                for (int j = 1; j < cols; j++) {
                    dp[i][j] = Math.Min (dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
                }
            }
            return dp[rows - 1][cols - 1];
        }
        public int MinPathSum3 (int[][] grid) {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
                return 0;
            }
            int rows = grid.Length;
            int columns = grid[0].Length;
            //遍历grid数组，动态规划计算每个格子的最小值
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (i == 0 && j == 0) { continue; }
                    int curMin = -1;
                    //从当前格子的上边和左边的格子里选出最小值并与当前格相加
                    if (i - 1 >= 0 && j - 1 >= 0) {
                        curMin = Math.Min (grid[i - 1][j], grid[i][j - 1]);
                    } else {
                        curMin = i - 1 >= 0 ? grid[i - 1][j] : grid[i][j - 1];
                    }
                    grid[i][j] = curMin + grid[i][j];
                }
            }
            //输出终点计算出的值即为路径最小值
            return grid[rows - 1][columns - 1];
        }

        public int MinPathSumCursion (int row, int col, int[][] grid, Dictionary<string, int> result) {
            /* o(m+n) o(m+n) */
            if (row == 0 && col == 0) {
                return grid[row][col];
            }
            string key = $"{row}^{col}"; //此处注意，防止 1 10 和 10 1 这种组合，中间补插其他符号
            Console.WriteLine (key);
            if (result.ContainsKey (key)) {
                return result[key];
            }
            int res = 0;
            if (row == 0) {
                res = grid[row][col] + MinPathSumCursion (row, col - 1, grid, result);
            } else if (col == 0) {
                res = grid[row][col] + MinPathSumCursion (row - 1, col, grid, result);
            } else {
                res = grid[row][col] + Math.Min (MinPathSumCursion (row, col - 1, grid, result), MinPathSumCursion (row - 1, col, grid, result));
            }
            result.Add (key, res);
            return res;
        }
    }
}