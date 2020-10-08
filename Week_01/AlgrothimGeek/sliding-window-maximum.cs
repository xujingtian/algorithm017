using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  239. 滑动窗口最大值 困难  https://leetcode-cn.com/problems/sliding-window-maximum/
     *给定一个数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k 个数字。
     *滑动窗口每次只向右移动一位。
     *返回滑动窗口中的最大值。
     *进阶：
     *你能在线性时间复杂度内解决此题吗？
     *
     */
    public class Solution239 {
        public int[] MaxSlidingWindow (int[] nums, int k) {
            //O(N^K) O(N) 超时了
            int n = nums.Length;
            if (n * k == 0) return new int[0];
            int totalmove = n - k + 1;
            int[] result = new int[totalmove];
            for (int i = 0; i < totalmove; i++) {
                int maxval = int.MinValue;
                for (int j = i; j < i + k; j++) {
                    maxval = Math.Max (maxval, nums[j]);
                }
                result[i] = maxval;
            }
            return result;
        }
        public int[] MaxSlidingWindow2 (int[] nums, int k) {
            //O(N) O(N)  输出数组使用了 O(N−k+1) 空间，双向队列使用了 O(k)。
            int n = nums.Length;
            if (n * k == 0) return new int[0];
            if (k == 1) return nums;
            int totalmove = n - k + 1;
            int[] res = new int[totalmove];
            LinkedList<int> dq = new LinkedList<int> (); //只保存当前滑动窗口内的索引，最大值
            for (int i = 0; i < n; i++) {
                if (dq.Count != 0 && (i - k + 1) > dq.First.Value) { //i-k+1的选择很**
                    dq.RemoveFirst (); //超出窗口长度时删除队首
                }
                while (dq.Count != 0 && nums[i] >= nums[dq.Last.Value]) {
                    dq.RemoveLast (); //如果遍历的元素大于队尾元素就删除队尾
                }
                dq.AddLast (i); //添加
                if (i - k + 1 >= 0) {
                    res[i - k + 1] = nums[dq.First.Value]; //结果
                }
            }
            return res;
        }
    }
}