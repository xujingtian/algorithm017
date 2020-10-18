using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 169. 多数元素 简单 https://leetcode-cn.com/problems/majority-element/description/
     *给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。
     *
     *你可以假设数组是非空的，并且给定的数组总是存在多数元素。
     */
    public class Solution169 {
        public int MajorityElement (int[] nums) {
            /*Dictionary 基于hash table 实现,遍历数组时间复杂度为o(n),查找因为要全遍历，所以也是o(n),
             *空间复杂充因为用了 Dictinoary,不会大于n/2,空间复杂度为o(n)
             */
            int len = nums.Length;
            Dictionary<int, int> dicTotals = new Dictionary<int, int> (len / 2);
            int counts = 0;
            for (int i = 0; i < len; i++) {
                if (!dicTotals.Keys.Contains (nums[i])) {
                    dicTotals.Add (nums[i], 1);
                } else {
                    counts = dicTotals[nums[i]];
                    dicTotals[nums[i]] = ++counts;
                }
            }
            var result = dicTotals.Where ((K, v) => K.Value > len / 2);
            if (result.Count () > 0)
                return result.First ().Key;
            return null;

        }
        public int MajorityElement2 (int[] nums) {
            /*分治 MajorityElementDC 使用了二分查找o(logn),线性遍历o(n),理论上时间复杂度应该为o(logn),
             *题银里说根据主定理得出 o(nlogn)，还没看懂
             *空间复杂度为o(logn)
             */
            return MajorityElementDC (nums, 0, nums.Length - 1);

        }

        private int MajorityElementDC (int[] nums, int lo, int hi) {
            // recurison terminator
            if (lo == hi) {
                return nums[lo];
            }
            // prepare data
            int mid = (hi - lo) / 2 + lo;

            //conquer subproblems
            int left = MajorityElementDC (nums, lo, mid);
            int right = MajorityElementDC (nums, mid + 1, hi);

            // process and generate the final resutl
            int leftCount = CountInRange (nums, left, lo, hi);
            int rightCount = CountInRange (nums, right, lo, hi);

            return leftCount >= rightCount ? left : right;
        }
        private int CountInRange (int[] nums, int num, int lo, int hi) {
            int count = 0;
            for (int i = lo; i <= hi; i++) {
                if (nums[i] == num) {
                    count++;
                }
            }
            return count;
        }
    }
}