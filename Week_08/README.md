# 学习笔记

## 位运算

### 基本运算符

| 左移     | <<   | 0001<<3  ---->1000                                     |                                |
| -------- | ---- | ------------------------------------------------------ | ------------------------------ |
| 右移     | >>   | 1000>>3 ----->0001                                     |                                |
| 按位与   | &    | 0001 & 1000  -----> 0000    0011 & 1001 ----> 0001     | 2位全是1 才为1                 |
| 按位或   | \|   | 0001 \| 1000 ------> 1001    0011 \| 1001 ------> 1011 | 2位 有1 参与就为1              |
| 按位取反 | ~    | ~1000 --> 0111                                         |                                |
| 按位异或 | ^    | 0001 ^ 1000 -----> 1001    0011 ^ 1001 ----> 1010      | 相同为0 ，不同为1-->不进位加法 |

x^0 =x (x 的二进制，要么为0 ，要么为1，而0 全为 0，相同为0，不同为1。假设 X 为 1001 ^ 0000 ----> 1001）

x^1s=~x

x^(~x)=1s

x^x=0

c=a^b---> c^a=b---->c^b=a 

a^b^c=(a^b)^c=a^(b^c) //associative



### 指定位置的位运算

1.将 x 最右边的 n 位清零：x & (~0<<n)
2.获取 x 的第 n 位值（ 0 或者 1 ）：x>>n & 1
3.获取 x 的第 n 位的幂值：x&(1<<n)
4.仅将第 n 位置为 1: x|(1<<n)
5.仅将第 n 位置为 0：x&(~(1<<n) )
6.将 x 最高位至第 n 位（含）清零：x&(1<<n -1) 

### 实战位运算要点

判断奇偶：x%2==0 ---> 偶   <------ x&1==0

​                    x%2==1 ---> 奇   <------ x&1==1

​                 



x>>1 ---> x/2



清零最低位的 1: x &(x-1)



得到最低位的 1: x&1



## 排序算法

```c#
/*快速排序*/ 
public static List<int> SelectSort (List<int> data) {
    int minIndex, temp;
    for (var i = 0; i < data.Count - 1; i++) {
        minIndex = i;
        for (var j = i + 1; j < data.Count; j++) {
            if (data[j] < data[minIndex]) {
                minIndex = j;
            }
        }
        temp = data[i];
        data[i] = data[minIndex];
        data[minIndex] = temp;
    }
    return data;
}
```



```c#
/*归并排序*/ 
public static List<int> MergeSort (List<int> data) {
        var arr = data.ToArray ();
        if (data.Count < 2) {
            return data;
        }
        int middle = (int) Math.Floor (((decimal) (data.Count / 2)));
        var left = arr.AsSpan ().Slice (0, middle).ToArray ();
        var right = arr.AsSpan ().Slice (middle).ToArray ();
        return Merge (MergeSort (left.ToList ()), MergeSort (right.ToList ()));
    }

private static List<int> Merge (List<int> left, List<int> right) {
    var result = new List<int> ();

    while (left.Count > 0 && right.Count > 0) {
        if (left[0] <= right[0]) {
            result.Add (left[0]);
            left.RemoveAt (0);
        } else {
            result.Add (right[0]);
            right.RemoveAt (0);
        }
    }

    while (left.Count != 0) {
        result.Add (left[0]);
        left.RemoveAt (0);
    }

    while (right.Count != 0) {

        result.Add (right[0]);
        right.RemoveAt (0);
    }

    return result;
}
```

​        

```c#
/*堆排序*/ 
private static int _count;

public static List<int> HeapSort (List<int> data) {
    Build (data);

    for (var i = data.Count - 1; i > 0; i--) {
        Swap (data, 0, i);
        _count--;
        Heapify (data, 0);
    }
    return data;
}
private static void Build (List<int> data) { // 建立大顶堆
    _count = data.Count;
    for (var i = (int) Math.Floor (((decimal) (_count / 2))); i >= 0; i--) {
        Heapify (data, i);
    }
}

private static void Heapify (List<int> data, int i) {
    int left = 2 * i + 1,
        right = 2 * i + 2,
        largest = i;

    if (left < _count && data[left] > data[largest]) {
        largest = left;
    }

    if (right < _count && data[right] > data[largest]) {
        largest = right;
    }

    if (largest != i) {
        Swap (data, i, largest);
        Heapify (data, largest);
    }
}

private static void Swap (List<int> data, int i, int j) {
    var temp = data[i];
    data[i] = data[j];
    data[j] = temp;
}
```



# Homework

#### c#  .netcore 详情见代码

#### [191. 位1的个数](https://leetcode-cn.com/problems/number-of-1-bits/)

#### [231. 2的幂](https://leetcode-cn.com/problems/power-of-two/)



