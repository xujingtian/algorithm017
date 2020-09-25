# 学习笔记

## 1、数据结构：

**逻辑结构+存储结构+操作**

### 1.1、逻辑结构：

**集合、线性（一对一）、树（一对多）、图（多对多）**

### 1.2、存储结构（物理结构）：

**顺序存储（内存连续）、链式存储、索引、散列**

### 1.3、操作：

**定义（这个其实就是存储结构）、查找、新增、删除**

如何实现操作？---->算法，不同的实现，就是不同的算法

## 2、本周内容

**Array、LinkedList、SkipLis**t
首先：三者都是线性结构，Array属于顺序存储，LinkedList、SkipList 属于链式存储。

### 2.1 Array---------> 线性结构，顺序存储

​                定义，int [] n = new int[]{0,8,9,7};
​                查找,按照下标进行，O(1)
​                新增,移动n-index+1,o(n)
​                删除，移动n-index,o(n)
​                prepend O(n)
​                append  O(n)
​                lookup  O(1)
​                insert  O(n)
​                delete  O(n)

### 2.2 LinkedList----> 线性结构，链式存储

​                定义，定义一个struct/class ,object value, T Next,T Pre... <br/>
​                查找,head.next.next，O(n) <br/>
​                新增,在已知相关节点信息前提下,o(1)，应该先将新增节点的next指向前驱节点的next,然后再将前驱节点next指向新节点，也就是先连，后断 <br/>
​                注意，此时其实会伴随着一个o(n)的查找，所以应该需要与其他数据结构组合起来使用，<br/>
​                e.g. hash+linedlist,感觉就像hash冲突时的存储 <br/>
​                删除，在已知相关节点信息前提下,o(1)，先将被删除节点的前驱节点next指向被删除节点的后继节点，然后将被删除节点next指向null<br/>
​              

| operation | 时间复杂度 | 空间复杂度 |
| --------- | ---------- | ---------- |
| prepend   | O(1)       | O(1)       |
| append    | O(1)       | O(1)       |
| lookup    | O(n)       |            |
| insert    | O(1)       | O(1)       |
| delete    | O(1)       |            |

### 2.3 SkipList----> 线性结构，链式存储

​                定义，有序链表，在链表的基础上进行扩充，但是实际咋整，没写，后期要跟进;<br/>

​                查找, 通过索引，达到o(logn),索引占用空间，O(n) <br/>
​                新增,同链表新增，但是还有索引的重建<br/>
​                删除，同链表新增，但是还有索引的重建<br/>

  

| operation | 时间复杂度 | 空间复杂度 |
| --------- | ---------- | ---------- |
| prepend   | O(1)       | O(n)       |
| append    | O(1)       | O(n)       |
| lookup    | O(logn)    | O(n)       |
| insert    | O(1)       | O(n)       |
| delete    | O(1)       | O(n)       |

​                 
​                

### 2.4 解题思路

​          1）能不能暴力解决<br/>
​         2）最基本情况，数学归纳法，递推思想---->找最近重复子问题<br/>

### 2.5  练习题目

/*move zeros 移动零 https://leetcode-cn.com/problems/move-zeroes/ <br/>
     最优解：双指针，找到非0元素，与最近为0的元素交换位置 O(n) O(1) <br/>
     双循环：外层循环判断0值，与内层循环非0值交换值 O(n^2) <br/>
*/

/*container-with-most-water 盛水最多的容器 https://leetcode-cn.com/problems/container-with-most-water/ <br/>
     最优解：双指针，定义初始、结束索引，计算area,并比较对应元素值，将元素值较小的索引前移/后移 O(n) O(1) <br/>
     双循环：循环计算，O(n^2) <br/>

*/
/*climbing-stairs 爬楼梯 https://leetcode.com/problems/climbing-stairs <br/>
        Fibonacci <br/>
         这个解法其实挺烧脑的，我一点不觉得是简单级别 <br/>
         其实整个楼梯，从n=3 才能正常套用 f(n)=f(n-1)+f(n-2) <br/>
          爬1级台阶和2级台阶的爬法确定，分别是1 和 2 <br/>
          以n=3为起点进行数组滚动，设定索引从0开始~~ <br/>
          引入2个变量，一步跨上来的爬法，初始值应该对应爬2级台阶的方法，可知为2 <br/>
          ，二步爬上来的爬法，初始值应该对应爬1级台阶的方法，可知为1 <br/>
          每次向上收敛，则n对应的节点变为（n+1节点）一步跨上来的爬法，<br/>
          原对应n的一步爬上来的节点，变为（n+1节点）二步爬上来的爬法 <br/>
*/