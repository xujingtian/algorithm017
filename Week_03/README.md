# 学习笔记

## 递归 recursion

### 定义

程序调用自身的编程技巧称为递归（ recursion） ------> 递归就是通过函数体来进行的循环

对递归的理解，其实是个挺烧脑的过程，就像覃超老师说的那样，直到现在，我还是会不由自主的想人肉递归得到结果，很难，但是有时候如果不人肉一下，感觉自己又想不明白。

结合老师的代码模板，及网上的一些资料，来理解一下自己的对递归的理解。

### 代码模板

从代码的书写上，包含了4大块：

----> recursion terminator (终结条件)

----->  process logic in current level(处理当前层逻辑)

----->  drill down (下探到下一层)

----->reverse the current level status if needed(清理当前层)

```c#
`public void Recur(int level, int param) {` 

  **// recursion terminator** 

  if (level > MAX_LEVEL) { 

    /* process result */

    return; 

  }

 **//process logic in current level**

  Process(level, data); 

  **// drill down** 

  Recur( level: level + 1, newParam); 

  **// reverse the current level status if needed** 

`}`
```



### 理解思路

以阶乘计算为例

n!=1×2×3×4×....×n

```c#
public int Factorial(int n){
    if(n==1) return 1;
    int result = Factorial(n-1)*n;
    return result;
}
```

对于此函数的讲解，都离不开一个抛物线图，前段为递进，后端为回归。

F(6)

6×F(5)

6×(5×F(4))

6×(5×(4×F(3)))

6×(5×(4×(3×F(2))))

6×(5×(4×(3×(2×(F(1))))) ------> 至此 为逻辑上的递进，从此看出，回归是是要先计算F(1)--->WHY?

6×(5×(4×(3×(2×1)))) 

6×(5×(4×(3×2))) 

6×(5×(4×6)) 

6×(5×24) 

6×120

720 

**理解递归，个人感觉要理解为什么程序会从满足recursion terminator的函数执行**，

而这就要从函数的执行来说起，简单的说，函数存在与程序代码里，而程序代码想要运行，必须由运行时将代码

加载至内存，交给CPU执行，CPU执行函数，基于线程 栈进行（还可以再详细描述一下）

也就是说对于函数的执行，首先要将函数入栈，按照栈的特性----->FILO----->要以得到一个如下的过程(N为6)

| Factorial(1)的栈帧 局部变量result |      |
| :-------------------------------: | ---- |
| Factorial(2)的栈帧 局部变量result |      |
| Factorial(3)的栈帧 局部变量result |      |
| Factorial(4)的栈帧 局部变量result |      |
| Factorial(5)的栈帧 局部变量result |      |
| Factorial(6)的栈帧 局部变量result |      |

以上图的线程栈的事例可以得到函数执行的过程，先执行F(1)，再执行F(2)......最后执行F(6)。

再简单理解一下，递归函数，在没有达到recursion terminator时，会一直进行进栈的操作（递进），当达到recursion terminator后，刚开始执行函数，此时，后进先出（回归）~~~~

函数进栈（递进）---->recursion terminator------>开始执行------->出栈（回归）----------->结束

分治

### 总结

递归，从运行过程来看，递进和回归，体现了程序进程线程栈的特性；

从逻辑思维上来说，就是**找重复性以及分解问题**<------怎样找重复性并分解问题，经验很重要。



## 分治 Divide & Conquer

### 定义

<http://en.wikipedia.org/wiki/Divide_and_conquer_algorithm>

Divide and conquer (D&C) is an important algorithm design paradigm based on multi-branched recursion. A divide and conquer algorithm works by recursively breaking down a problem into two or more sub-problems of the same (or related) type, until these become simple enough to be solved directly. The solutions to the sub-problems are then combined to give a solution to the original problem.

分治算法是基于多分枝递归的一种算法设计模式。分治算法递归地把一个大问题分解为多个类型相同的子问题，直到这些子问题足够的简单能被直接解决。最后把这些子问题的解结合起来就能得到原始问题的解。

根据这个定义，我们可以很明显的知道，对于D&C问题，我们解决它需要两步，一是要找到递归式；二是要根据递归式能找到最后的答案。

### 代码模板

从代码的书写上，包含了4大块：

----->  recursion terminator (终结条件)

----->  prepare data(准备数据 ---> 处理当前层逻辑)

----->  conquer subproblems（治理子问题---->下探到下一层）

----->  process and generate the final resutl (返回结果)

-----> revert the current level status(清理当前层)

```c#
public void Divide_Conquer(T problem, object[] params) {
  // recursion terminator 
  if (problem == null) { 
  /* print result */
    return; 
  }
 //prepare data
 object data = Prepare_Data(problem);
 T[] subProblems = Split_Problem(problem,data);   
 //conquer subproblems
 object subResult1 = Divide_conquer(subProblems[0],p1);
 object subResult2 = Divide_conquer(subProblems[1],p1);
 object subResult3 = Divide_conquer(subProblems[2],p1);
 ...
  // process and generate the final resutl
  reusult = Process_Result(subResult1,subResult2,subResult3,...); 
  // revert the current level status
}

```

### 理解思路

见递归

### 总结

特殊的递归，比较复杂的递归

如何拆分子问题，很重要<-----经验

有点像归并排序

## 回溯 Backtracking

定义



# Homework

- [二叉树的最近公共祖先](https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/)（Facebook 在半年内面试常考）

- [从前序与中序遍历序列构造二叉树](https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/)（字节跳动、亚马逊、微软在半年内面试中考过）

  总得来说，做的不是特别顺利，还是拆分子问题会比较慢，以及一直想人肉递归~~~~