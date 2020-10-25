using System;

namespace AlgrothimGeek {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            int idx = SerarchTraverIndex (new int[] { 4, 5, 6, 7, 8, 0, 1, 2 });
            Console.WriteLine ($"{idx}");
            Console.ReadLine ();
        }

        private static int SerarchTraverIndex (int[] nums) {
            /*  描述：使用二分查找，寻找一个半有序数组 [4, 5, 6, 7, 0, 1, 2] 中间无序的地方
             *思路： 
             *1）首先确认无序数组的一些特性：
             *   只考虑 nums 为有序旋转的数组，旋转后的数组，nums[newlow]>= nums[oldlow]
             *   oldlow现在的下标位置，满足如下条件：nums[oldlow-1] > nums[oldlow] && nums[oldlow+1] > nums[oldlow] 
             *   等于是个比较特殊的情况，数组有重复值，如下）
             *   [1,1,1,1,1,2,3,4]---->[1,2,3,4,1,1,1,1]
             *                    ---->[2,3,4,1,1,1,1,1]
             *2）确定无序数组的区域（旋转区域）
             *   因为本来是升序数组，所以nums[low] <= nums[high],所以只要找到 nums[low] > nums[high],旋转区一定在则区域内
             *中心思想，找出旋转区域，并找出此区域内符合如下关系的 数组 nums[idx-1] > nums[idx] && nums[idx+1] > nums[idx] 
             *o(logn)  o(1)
             */
            int len = nums.Length;
            int low = 0, high = len - 1;
            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (nums[mid] < nums[mid - 1] && nums[mid] <= nums[mid + 1]) {
                    return mid;
                }
                if (nums[low] < nums[mid]) { //此区间不存在，low移到下一个区间
                    if (low == mid) //此时low与high要么相等，要么差1，如何时直接赋值=high,则可能死循环，所以+1
                        low++;
                    else {
                        low = mid;
                    }
                } else if (nums[low] >= nums[mid]) { //在此区间,high转移至此区间
                    high = mid;
                }
            }
            return -1;
        }
    }
}