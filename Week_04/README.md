# 学习笔记

本周的内容比较具体，都是具体的算法，需要刻意练习。课程跟进下来，目前只能保证2道homework的进度，还是有点吃力的。

尽量把每个做的题目都清楚~~

## 深度优先遍历&广度优先遍历

记住代码模板

DFS https://shimo.im/docs/UdY2UUKtliYXmk8t/read

BFS https://shimo.im/docs/ZBghMEZWix0Lc2jQ/read



## 贪心算法 Greedy

### 定义

贪心算法是一种在每一步选择中都采取在当前状态下最好或最优（即最有
利）的选择，从而希望导致结果是全局最好或最优的算法。

### 特点

贪心算法与动态规划的不同在于它对每个子问题的解决方案都做出选择，不
能回退。动态规划则会保存以前的运算结果，并根据以前的结果对当前进行
选择，有回退功能。

简单地说，问题能够分解成子问题来解决，子问题的最优解能递推到最终
问题的最优解。这种子问题最优解称为最优子结构。




## 二分查找

核心思想，分块，并选取基中一块继续进行查找

代码模板：https://shimo.im/docs/xvIIfeEzWYEUdBPD/read

### 前提

目标函数单调性（单调递增或者递减）

存在上下界（bounded）

能够通过索引访问（index accessible)



# Homework

c# .net core

## 寻找旋转数组无序的idx

```
描述：使用二分查找，寻找一个半有序数组 [4, 5, 6, 7, 0, 1, 2] 中间无序的地方
思路： 
1）首先确认无序数组的一些特性：
   只考虑 nums 为有序旋转的数组，旋转后的数组，nums[newlow]>= nums[oldlow]
   oldlow现在的下标位置，满足如下条件：nums[oldlow-1] > nums[oldlow] && nums[oldlow+1] > nums[oldlow] 
   等于是个比较特殊的情况，数组有重复值，如下）
   [1,1,1,1,1,2,3,4]---->[1,2,3,4,1,1,1,1]
                    ---->[2,3,4,1,1,1,1,1]
2）确定无序数组的区域（旋转区域）
   因为本来是升序数组，所以nums[low] <= nums[high],所以只要找到 nums[low] > nums[high],旋转区一定在则区域内
```

    中心思想，找出旋转区域，并找出此区域内符合如下关系的 数组 nums[idx-1] > nums[idx] && nums[idx+1] > nums[idx] 

```c#
private static int SerarchTraverIndex (int[] nums) {
    /* 
    o(logn)  o(1)
     */
    int len = nums.Length;
    int low = 0, high = len - 1;
    while (low <= high) {
        int mid = low + (high - low) / 2;
        if (nums[mid] < nums[mid - 1] && nums[mid] <= nums[mid + 1]) {
            return mid;
        }
        if (nums[0] == nums[mid]) {
            return mid;
        } else if (nums[low] < nums[mid]) { //此区间不存在，low移到下一个区间
            if (low == mid) //此时low与high要么相等，要么差1，如何时直接赋值=high,则可能死循环，所以+1
                low++;
            else {
                low = mid;
            }
        } else if (nums[low] >= nums[mid]) { //在此区间,high转移至此区间
            high = mid;
        }
        else{
            return -1;//些逻辑跑不到才对
        }
    }
    return -1;
}
```

​	

## [33. 搜索旋转排序数组](https://leetcode-cn.com/problems/search-in-rotated-sorted-array/)



# 问题

时间复杂度的问题，一带上while就有点算不准

如下2个带while的代码，一个是二叉树的层序遍历，一个是删除排序数组中的重复项

麻烦助教老师看下，这么算对不对，或者是有没有更好的办法来计算

![avatar] (https://github.com/xujingtian/algorithm017/blob/master/Week_04/pics/image-20201025220945493.png)

![image-2020102522094549](https://github.com/xujingtian/algorithm017/blob/master/Week_04/pics/image-20201025220945493.png)

![本地备份](D:\99.dean_pc\08.geektime\03.算法训练营_正式\algrothimcode\algorithm017\Week_04\pics\image-20201025220945493.png)