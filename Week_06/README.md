# 学习笔记

## 动态规划

定义：https://en.wikipedia.org/wiki/Dynamic_programming

不太好总结，按照理解，其实也是递归，只不过普通递归是从最终结果反算，DP是以最小子问题入手找最优解（最优解，也就是min / max，也可能不用这一步）

 基本套路：分治+最优子结构，也就是找子问题---->状态数组----->DP方程



## HomeWork

### [最小路径和](https://leetcode-cn.com/problems/minimum-path-sum/)

#### 思路一：递归

因为只能从 左/下 行进，所以，最后一个格子的值只能是由 左&上 格子的步数累计得到，

```c#
grid[row][col] = grid[row][col-1] + grid[row-1][col];
```

注意，row=0/col=0 时，是2种特殊情况，row = 0时，只能从左到达，

```
grid[0][col] = grid[0][col-1] ;
```

col=0时，只能从上到达

```
grid[row][0] = grid[row-1][0];
```

同时，需要注意保存中间结果，

最终方案如下：

```c#
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
        res = grid[row][col] + Math.Min (MinPathSumCursion (row, col - 1, grid, result), MinPathSumCursion (row- 1, col, grid, result));
    }
    result.Add (key, res);
    return res;
}
```

调用

```c#
MinPathSumCursion (grid.Length - 1, grid[0].Length - 1, grid, new Dictionary<string, int> ());
```

#### 思路二：DP

分治(子问题)：求解每一个格子可到过的最小步数

状态方程组： m(row,col)

DP方程：min_sum(row,col)=min(min_sum(row,col-1),min_sum(row-1,col))+grid(row,col);

```c#
public int MinPathSum (int[][] grid) {//自顶向下进计算
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
```



## [解码方法](https://leetcode-cn.com/problems/decode-ways)

#### DP

分治(子问题)：寻找相对位置一致的子串，是否为回文串

状态方程组： `dp[i][j]`

DP方程：`dp[i][j]=dp[i+1][j-1]`

```c#
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
```

