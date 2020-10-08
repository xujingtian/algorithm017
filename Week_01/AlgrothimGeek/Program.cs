using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            Solution20 tt = new Solution20 ();
            tt.IsValid ("()[]{}");
        }

        #region move-zeroes
        /*移动零
        * 给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。说明:

        *必须在原数组上操作，不能拷贝额外的数组。
        *尽量减少操作次数。
        *思路：
        *1.顺序遍历数组，遇到非0的就前移 
        *2.顺序遍历数组，遇到为0的就记录下标，并继续查找后一个不为0的下标，交换值，并继续 --MoveZeroesSLoop 
        */
        private void MoveZeroesDLoop (int[] nums) {
            {
                //时间复杂度O(n^2) 空间复杂度 无额外
                for (int i = 0; i < nums.Length - 1; i++) {
                    if (nums[i].Equals (0)) {
                        for (int j = i + 1; j < nums.Length; j++) {
                            if (!nums[j].Equals (0)) {
                                nums[i] = nums[j];
                                nums[j] = 0;
                                break;
                            }
                        }
                    }
                }
            } {
                //时间复杂度O(n) 空间复杂度 O(1)
                int idx = 0;
                for (int i = 0; i < nums.Length; i++) {
                    if (!nums[i].Equals (0)) {
                        nums[idx++] = nums[i];
                    }
                }
                /*for (int i = idx; i < nums.Length; i++) {
                    nums[i] = 0;
                }*/
                while (idx < nums.Length) {
                    nums[idx++] = 0;
                }
            } { //时间复杂度O(n) 空间复杂度 O(1)，目前此方法效率最高
                int temp = 0;
                for (int idx = 0, i = 0; i < nums.Length; i++) {
                    if (nums[i] != 0) {
                        temp = nums[idx];
                        nums[idx++] = nums[i];
                        nums[i] = temp;
                    }
                }
            } {
                //时间复杂度O(n) 空间复杂度 O(1)，尝试下交换，其实
                int idx = 0;
                for (int i = 0; i < nums.Length; i++) {
                    if (!nums[i].Equals (0)) {
                        Swap (ref nums[idx++], ref nums[i]);
                    }
                }
            }

        }
        private void MoveZeroesSLoop (int[] nums) {
            {
                //时间复杂度O(n) 空间复杂度 O(1)
                //第一次的思路，找到第一个为0的元素，并记录下索引,继续查找，遇到第一个不为0的元素，判断索引位置
                //若不小于iLow,则交换元素，并重置索引
                int iLow = -1, iHigh = 0;
                for (int i = 0; i < nums.Length; i++) {
                    if (nums[i].Equals (0) && iLow.Equals (-1)) {
                        iLow = i;
                    } else if (!nums[i].Equals (0)) {
                        iHigh = i;
                    }
                    if (iLow > -1 && iLow < iHigh) {
                        nums[iLow] = nums[iHigh];
                        nums[iHigh] = 0;
                        i = iLow;
                        iLow = -1;
                        iHigh = 0;;
                    }
                }
            }
        }
        private void Swap (ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
        #region container-with-most-water
        /*盛水最多的容器
               *给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
               在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，
               使得它们与 x 轴共同构成的容器可以容纳最多的水。

               *说明：你不能倾斜容器，且 n 的值至少为 2。
                *思路：
                *1.双循环计算两两坐标的面积，取最大
                *2.双指针
        */
        public int MaxAreaDLoop (int[] height) {
            //时间复杂度O(n^2) 空间复杂度O(1)
            int area = 0;
            for (int i = 0; i < height.Length - 1; i++) {
                for (int j = i + 1; j < height.Length; j++) {
                    area = Math.Max ((j - i) * Math.Min (height[i], height[j]), area);
                }
            }
            return area;

        }
        public int MaxAreaSLoop (int[] height) {
            //时间复杂度O(n) 空间复杂度O(1)
            int area = 0, lindex = 0, hindex = height.Length - 1;
            while (lindex < hindex) {
                area = Math.Max ((hindex - lindex) * Math.Min (height[hindex], height[lindex]), area);
                if (height[lindex] < height[hindex])
                    lindex++;
                else
                    hindex--;
            }
            return area;

        }
        #endregion

        #region climbing-stairs
        /*
        假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
        每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢
         *思路：
                *1.Fibonacci,递归
                *2.
        */
        private int ClimbStairs (int n) {
            //Fibonacci，递归 o(2^n)
            if (n <= 2) return n;
            return ClimbStairs (n - 1) + ClimbStairs (n - 2);
        }
        private int ClimbStairs1 (int n) {
            //o(n) o(n)
            if (n <= 2) return n;
            int[] dps = new int[n + 1];
            dps[0] = 0; //用不到
            dps[1] = 1;
            dps[2] = 2;
            for (int i = 3; i < dps.Length; ++i) {
                dps[i] = dps[i - 1] + dps[i - 2];
            }
            return dps[n];
        }

        private int ClimbStairs2 (int n) { //
            // 这个解法其实挺烧脑的，我一点不觉得是简单级别
            // 其实整个楼梯，从n=3 才能正常套用 f(n)=f(n-1)+f(n-2)
            // 爬1级台阶和2级台阶的爬法确定，分别是1 和 2
            // 以n=3为起点进行数组滚动，设定索引从0开始~~
            // 引入2个变量，一步跨上来的爬法，初始值应该对应爬2级台阶的方法，可知为2
            //，二步爬上来的爬法，初始值应该对应爬1级台阶的方法，可知为1
            //每次向上收敛，则n对应的节点变为（n+1节点）一步跨上来的爬法，
            //原对应n的一步爬上来的节点，变为（n+1节点）二步爬上来的爬法，
            //o(n) o(1)
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            int one_step_before = 2;
            int two_steps_before = 1;
            int all_ways = 0;

            for (int i = 2; i < n; i++) {
                all_ways = one_step_before + two_steps_before;
                two_steps_before = one_step_before;
                one_step_before = all_ways;
            }
            return all_ways;
        }
        private int ClimbStairs3 (int n) {
            //o(n) o(1)
            if (n <= 2) return n;
            int f1 = 1, f2 = 2, f3 = 3;
            for (int i = 3; i <= n; ++i) {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
            }
            return f3;
        }
        #endregion
        #region 3sum 三数之和
        public static IList<IList<int>> ThreeSum (int[] nums) {
            //o(n^3) o(1)
            Array.Sort (nums);
            int sizes = nums.Length;
            IList<IList<int>> listAll = new List<IList<int>> (sizes / 3);
            List<string> listCompare = new List<string> (sizes / 3);
            string joins = string.Empty;
            for (int i = 0; i < sizes - 2; i++) {
                for (int j = i + 1; j < sizes - 1; j++) {
                    for (int k = j + 1; k < sizes; k++) {
                        if (nums[i] + nums[j] + nums[k] == 0) {
                            List<int> listData = new List<int> (3);
                            listData.Add (nums[i]);
                            listData.Add (nums[j]);
                            listData.Add (nums[k]);
                            joins = string.Join (",", listData);
                            if (!listCompare.Contains (joins)) {
                                listCompare.Add (joins);
                                listAll.Add (listData);
                            }
                        }
                    }
                }

            }
            return listAll;
        }

        public IList<IList<int>> ThreeSum2 (int[] nums) {
            //o(n^3) o(1)
            Array.Sort (nums);
            int sizes = nums.Length;
            IList<IList<int>> listAll = new List<IList<int>> (sizes / 3);
            List<string> listCompare = new List<string> (sizes / 3);

            string joins = string.Empty;
            for (int i = 0; i < sizes - 2; i++) {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < sizes - 1; j++) {
                    if (j != i + 1 && nums[j] == nums[j - 1]) continue;
                    for (int k = j + 1; k < sizes; k++) {
                        if (k != j + 1 && nums[k] == nums[k - 1]) continue;
                        if (nums[i] + nums[j] + nums[k] == 0) {
                            List<int> listData = new List<int> (3);
                            listData.Add (nums[i]);
                            listData.Add (nums[j]);
                            listData.Add (nums[k]);
                            listAll.Add (listData);
                        }
                    }
                }

            }
            return listAll;
        }

        public IList<IList<int>> ThreeSum3 (int[] nums) {
            //o(n^3) o(n)
            Array.Sort (nums);
            int sizes = nums.Length;
            IList<IList<int>> listAll = new List<IList<int>> (sizes / 3);
            int need = -1;
            int lo = -1;
            int hi = -1;
            int mid = -1;
            for (int i = 0; i < sizes - 2; i++) {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < sizes - 1; j++) {
                    if (j != i + 1 && nums[j] == nums[j - 1]) continue;
                    need = 0 - nums[i] - nums[j];
                    lo = j + 1;
                    hi = nums.Length - 1;
                    while (lo <= hi) {
                        mid = (lo + hi) / 2; // ((hi - lo) >> 1) + lo;
                        if (nums[mid] == need) {
                            listAll.Add (new List<int> { nums[i], nums[j], nums[mid] });
                            break;
                        } else if (nums[mid] < need) {
                            lo = mid + 1;
                        } else if (nums[mid] > need) {
                            hi = mid - 1;
                        }
                    }
                }

            }
            return listAll;
        }

        public static IList<IList<int>> ThreeSum4 (int[] nums) {
            //o(n^2) o(n)
            int sizes = nums.Length;
            Array.Sort (nums);
            IList<IList<int>> listAll = new List<IList<int>> (sizes / 3);
            for (int i = 0; i < sizes - 2; i++) {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int k = sizes - 1;
                for (int j = i + 1; j < sizes - 1; j++) {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    while (j < k && nums[j] + nums[k] + nums[i] > 0) {
                        --k;
                    }
                    if (j == k)
                        break;
                    if (nums[j] + nums[k] + nums[i] == 0) {
                        List<int> listData = new List<int> (3);
                        listData.Add (nums[i]);
                        listData.Add (nums[j]);
                        listData.Add (nums[k]);
                        listAll.Add (listData);
                    }
                }
            }
            return listAll;

        }
        public class ListContains<T> : List<int> {
            public ListContains (int capcity) : base (capcity) {

            }
            public override bool Equals (object obj) {
                if (obj.GetType () == typeof (List<int>)) {
                    int counts = this.Count;
                    for (int i = 0; i < counts; i++) {
                        if ((int) this [i] != ((List<int>) obj) [i]) {
                            return false;
                        }
                    }
                    return true;
                }
                return base.Equals (obj);
            }

            public override int GetHashCode () {
                return base.GetHashCode ();
            }
        }
        #endregion
    }
}