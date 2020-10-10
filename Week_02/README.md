# 学习笔记

## 本周内容

四种数据结构：Hash、Tree、Heap、Graph

Hash使用索引+链表（注：具体实现代码还没看）---->Hash Funcitn------> Hash Collisions

Tree 使用链表------> Pre(根 左 右)、In（左 根 右）、 Post Order（左 右 根）

​                      ---------> Binary Search Tree ----------> 二叉树（根节点、左孩子、右孩子）

​                                                                                       左孩子比根节点小、右孩子比根节点值大

​                                                                                       左、右子树也分别为二叉查找树 

Heap 使用数组 ------------> 可以迅速找到，一堆数中的最大或者最小值的数据结构

​                          二叉堆 -------->完全二叉树

​                                                    ------------> 大顶堆------> 根节点>=子节点

​                                                    ------------> 小顶堆------> 根节点<=子节点

Graph 使用链表、矩阵----------> 有边、有点------------->无向无权图、无向有权图、有向无权图、有向有权图





注：Linked List 是特殊化的 Tree（只有一种child节点），Tree 是特殊化的 Graph（无环）





## Hash 表

哈希表（Hash table） 也叫散列表，是根据关键码值（ Key value）而直接进行访问的数据结构 。
它通过把关键码值映射到表中一个位置来访问记录，以加快查找的速度 。
这个映射函数叫作散列函数（ Hash Function）， 存放记录的数组叫作哈希表（或散列表 ）。

### 工程实践

•电话号码簿
•用户信息表
•缓存（ LRU Cache）
•键值对存储（ Redis）

### Hash Funciton

散列函数：一致性Hash---->Hash环---->手写一个

### Hash Collisions

哈希碰撞：Hash冲突---->链表

![1602167020114](C:\Users\xujin\AppData\Local\Temp\1602167020114.png)

<https://www.bigocheatsheet.com/> 



## 树 Tree 





### 定义

```c#
public Class TreeNode{

    public int val;

    publicTreeNode leftNode;

    publicTreeNode rightNode;

    public TreeNode(int val){

        this.val = val;

        this.leftNode = null;

        this.rightNode = null;

    }

}
```

### 前序 Pre order 

根 ------左---------右

### 中序 In order 

左------根----------右



### 后续 Post order 

左------右----------根



### 三序列标准代码

![1602169942429](C:\Users\xujin\AppData\Local\Temp\1602169942429.png)

### 二叉树 Binary Tree



#### 二叉搜索树 Binary Search Tree

二叉搜索树，
也称二叉 排序 树 、有序二叉树（ Ordered Binary Tree ）、 

##### 定义

排序二叉树（ Sorted Binary Tree 是指一棵空树或者具有下列性质的二叉树

1. 左子树上 所有结点 的值均小于它的根结点的值
2. 右子树上 所有结点 的值均大于它的根结点的值
3. 以此类推：左、右子树也分别为二叉查找树 。 这就是 重复性
  中序遍历：升序排列

##### 操作

1.查询
2.插入新结点（创建）

3.删除

Demo:
https://visualgo.net/zh/bst

## 堆 Heap

### 定义:

可以迅速找到，一堆数中的最大或者最小值的数据结构

将根节点最大的堆叫大顶堆或者大根堆，根节点最小的堆叫小顶堆或者小根堆。

二叉堆、 斐波那契堆Fibonacci

https://en.wikipedia.org/wiki/Heap_(data_structure)

### 二叉堆

基于完全二叉树，以下是大顶堆

- 是一棵完全树
- 树中任意节点的值总是>=其子节点

基于数组实现

二叉堆是堆（priority_queue优先队列）的一种常见且简单的实现，但并不是最优实现



<https://en.wikipedia.org/wiki/Heap_(data_structure)> 

![1602172004646](C:\Users\xujin\AppData\Local\Temp\1602172004646.png)

## 图 Graph

有点（vertex ---vertices），有边（edge） 就是图



### V-vertex 点

度：入度，出度

点与点之间：连通与否



### E-edge 边

有向和无向

权重（边长）



### 分类

无向无权图

有向无权图

无向有权图

有向有权图

### 算法

DFS

![1602172308626](C:\Users\xujin\AppData\Local\Temp\1602172308626.png)

BFS



![1602172317946](C:\Users\xujin\AppData\Local\Temp\1602172317946.png)



# Homework

#### [242. 有效的字母异位词](https://leetcode-cn.com/problems/valid-anagram/)



思路1:排序后比较，注意Array.Equals问题？？？为啥不等，看下源码



## [144. 二叉树的前序遍历](https://leetcode-cn.com/problems/binary-tree-preorder-traversal/)

