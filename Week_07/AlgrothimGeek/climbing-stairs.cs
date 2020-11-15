using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int ClimbStairs (int n) {
        /*o(n) o(n)*/
        if (n < 2) {
            return n;
        }
        int[] dp = new int[n + 1];
        //return Memoization(dp,n);
        dp[0] = 1;
        dp[1] = 2;
        for (int i = 2; i < n; i++) {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n - 1];
    }

    private int Memoization (int[] dp, int n) {
        if (n < 2) {
            return n;
        }
        dp[1] = 1;
        dp[2] = 2;
        if (dp[n] != 0) {
            return dp[n];
        }
        dp[n] = Memoization (dp, n - 1) + Memoization (dp, n - 2);
        return dp[n];

    }
}