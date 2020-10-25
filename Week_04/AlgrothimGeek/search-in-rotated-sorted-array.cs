using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 33. 搜索旋转排序数组 中等 https://leetcode-cn.com/problems/search-in-rotated-sorted-array/
     *给你一个升序排列的整数数组 nums ，和一个整数 target 。
     *假设按照升序排序的数组在预先未知的某个点上进行了旋转。（例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] ）。
     *请你在数组中搜索 target ，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
     *示例 1：
     *输入：nums = [4,5,6,7,0,1,2], target = 0
     *输出：4
     *示例 2：
     *输入：nums = [4,5,6,7,0,1,2], target = 3
     *输出：-1
     *示例 3：
     *输入：nums = [1], target = 0
     *输出：-1
     */
    public class Solution33 {
        public int Search (int[] nums, int target) {
            /* 
            只考虑 nums 为有序旋转的数组，旋转后的数组，只可能有一种情况，
               oldlow转移到了非low位置，此时数组的形态，newlow 对应的值，一定是>= prelow的值
             （等于是个比较特殊的情况，数组有重复值，如下）与prelow相接的prelow-1的值，一定大于prelow
            [1,1,1,1,1,2,3,4]---->[1,2,3,4,1,1,1,1]
                             ---->[2,3,4,1,1,1,1,1]
            mid落在的区间有三种，落在prelow之前，或者之后，或者就是prelow,
            
            if nums[low]<=nums[mid] (low - mid不包含旋转,或者是mid为旋转起点，但此时 mid 与 low相等。先比较比区域）
               -----> nums[low]<=target && nums[mid]>traget-------> high=mid-1 // target，在此区域内
               ---------------------------------------------------> low=mid+1 // target，在此区域内，然后循环，找非旋转区域 
            else if nums[low]>nums[mid] (low - mid包含旋转,那此时 mid+1 至 high 为非旋转区域，先比此区域)
               -----> nums[mid]<=target && nums[high]>target-----> low = mid+1 // target，在此区域内
               ---------------------------------------------------> high =mid-1 // target，在此区域内，然后循环，找非旋转区域 
            
            中心思想，找出非旋转区域，并判断target与此区域的关系

            o(logn) o(1)
            
            */
            int len = nums.Length;
            if (len == 0) {
                return -1;
            } else if (len == 1) {
                return nums[0] == target? 0: -1;
            }
            int low = 0, high = len - 1;
            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target) {
                    return mid;
                }
                if (nums[low] <= nums[mid]) {
                    if (nums[low] <= target && nums[mid] > target) {
                        high = mid - 1;
                    } else {
                        low = mid + 1;
                    }
                } else {
                    if (nums[mid] < target && nums[high] >= target) {
                        low = mid + 1;
                    } else {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}