# 学习笔记

本周课程以字典树为引导，首先回顾了树的概念----->二叉树---->AVL树---->红黑树





## 字典树（Trie 树）

字典树，即 Trie 树，又称单词查找树或键树，是一种树形结构。

典型应用是用于统计和排序大量的字符串（但不仅限于字符串），

所以经常被搜索引擎系统用于文本词频统计。

它的优点是：最大限度地减少无谓的字符串比较，查询效率比哈希表高。

特点：

1. 结点本身不存完整单词；
2. 从根结点到某一结点，路径上经过的字符连接起来，为该结点对应的字符串；
3. 每个结点的所有子结点路径代表的字符都不相同。

核心思想：

Trie 树的核心思想是空间换时间。
利用字符串的公共前缀来降低查询时间的开销以达到提高效率的目的。



## 并查集（Disjoint Set）

适用于 组团、配对问题 （ Group or not ）



• makeSet(s)：建立一个新的并查集，其中包含 s 个单元素集合。
• unionSet(x, y)：把元素 x 和元素 y 所在的集合合并，要求 x 和 y 所在
的集合不相交，如果相交则不合并。
• find(x)：找到元素 x 所在的集合的代表，该操作也可以用于判断两个元
素是否位于同一个集合，只要将它们各自的代表比较一下就可以了。





## 二叉树





## 二叉搜索树



二叉搜索树，也称二叉搜索树、有序二叉树（Ordered Binary Tree ）、排序二叉树（ Sorted Binary Tree ），

是指一棵空树或者具有下列性质的二叉树：

1. 左子树上 所有结点 的值均小于它的根结点的值；
2. 右子树上 所有结点 的值均大于它的根结点的值；
3. 以此类推：左、右子树也分别为二叉查找树。 （这就是 重复性！）
中序遍历：升序排列



## AVL树	

1.平衡二叉搜索树
2.每个结点存 balance factor = { 1, 0, 1}
3.四种旋转操作 ：左旋、右旋、左右旋、右左旋

不足：结点需要存储额外信息、且调整次数频繁

## 红黑树

红黑树是一种
近似平衡 的二叉搜索树（ Binary Search Tree ）

它能够确保任何一个结点的左右子树的 高度差小于两倍 。

具体来说，红黑树是满足如下条件的二叉搜索树
•每个结点要么是红色，要么是黑色
•根 结 点是黑色
•每个叶 结 点（ NIL 结 点，空 结 点）是黑色的 。
•不能有相邻接的两个红色 结 点。
•从任一 结 点到其每个叶子的所有路径都包含相同数目的黑色 结点。



# 代码相关总结

总结双向 BFS 代码模版，请同学们提交在学习总结中

分析单词搜索 2 用 Tire 树方式实现的时间复杂度，请同学们提交在学习总结中。

## 双向 BFS 代码模版(Two-ended BFS)

```c#
public class UnionFind {
    private int count = 0;
    private int[] parent;
    public UnionFind (int n) {
        count = n;
        parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }
    public void Union (int p, int q) {
        int rootP = Find (p);
        int rootQ = Find (q);
        if (rootP == rootQ) return;
        parent[rootP] = rootQ;
        count--;
    }
    public int Find (int p) {
        while (p != parent[p]) {
            parent[p] = parent[parent[p]];
            p = parent[p];
        }
        return p;
    }
}
```



## 单词搜索Trie 时间复杂度

假设单词的最大长度是 L，从一个单元格开始，最初我们最多可以探索 4 个方向。假设每个方向都是有效的（即最坏情况），在接下来的探索中，我们最多有 3 个相邻的单元（不包括我们来的单元）要探索。因此，在回溯探索期间，我们最多遍历 4*3^(L-1)  个单元格。

以此类推，要实现N个单元格的遍历。所以时间复杂为O(n*4*3^(L-1) )  





# Homework

c# .net core 详细实现在代码文件夹里 AlgrothimGeek,作业越来越难跟了，只能勉强保持2道题目~~

- [爬楼梯](https://leetcode-cn.com/problems/climbing-stairs/)（阿里巴巴、腾讯、字节跳动在半年内面试常考）
- [单词接龙](https://leetcode-cn.com/problems/word-ladder/)（亚马逊、Facebook、谷歌在半年内面试中考过）