# 学习笔记

紧张的课程就要结束了，回顾了一下学习过程，没有很坚持，但也没有放弃，没有很坚持，主要是对题目的练习上，只保证了每周2题目的节奏；没有放弃，毕竟坚持了下来。以前有疑问的地方，在课程中得到了方向性的指导。

还是用自己的节奏，来完成最后一周的学习，简单总结+2道刷题~~







本周主要是动态规划的延伸+字符串算法，

动态规划

1、有意识的培养以下习惯

- 拒绝人肉递归，很累
- 找最近最简方法，将其拆解成可重复解决的问题
- 数据归纳思想

2、问题的本质

本质：寻找重复性-->计算行指令 if else for loop

3、动态规划

自底向上、分治+最优子结构、状态转移方程、最优子结构



对于本身工作，字符串匹配可能用到几率可能更高，高级语言封装了很多方法，自己实际写的机会反而少了，

基本的套路就是暴力+hash+KMP思路优化。





# Homework

c# .netcore 详见代码文件

#### [387. 字符串中的第一个唯一字符](https://leetcode-cn.com/problems/first-unique-character-in-a-string/)

思路1：双层循环，碰到第一个只出现一次的立即返回。o(n^2)   o(1)

思路2：字符串去重，然后返回第一个字符，本次使用 此方法优先实现  o(n) o(n)---->实现的时候发现没理解题意，行不通

思路3：使用Hash表，统计出现频率，c#中 HasMap的实现为Dictionary  o(n) o(n)









