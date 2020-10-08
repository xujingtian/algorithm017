using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /* 641 design-circular-deque 中等  https://leetcode-cn.com/problems/design-circular-deque/
     *设计实现双端队列。
     *你的实现需要支持以下操作：
     *
     *MyCircularDeque(k)：构造函数,双端队列的大小为k。
     *insertFront()：将一个元素添加到双端队列头部。 如果操作成功返回 true。
     *insertLast()：将一个元素添加到双端队列尾部。如果操作成功返回 true。
     *deleteFront()：从双端队列头部删除一个元素。 如果操作成功返回 true。
     *deleteLast()：从双端队列尾部删除一个元素。如果操作成功返回 true。
     *getFront()：从双端队列头部获得一个元素。如果双端队列为空，返回 -1。
     *getRear()：获得双端队列的最后一个元素。 如果双端队列为空，返回 -1。
     *isEmpty()：检查双端队列是否为空。
     *isFull()：检查双端队列是否满了。
     */
    public class MyCircularDeque {

        // 1、不用设计成动态数组，使用静态数组即可
        // 2、设计 head 和 tail 指针变量
        // 3、head == tail 成立的时候表示队列为空
        // 4、tail + 1 == head

        private int capacity;
        private int[] arr;
        private int front;
        private int rear;

        /**
         * Initialize your data structure here. Set the size of the deque to be k.
         */
        public MyCircularDeque (int k) {
            capacity = k + 1;
            arr = new int[capacity];
            // 头部指向第 1 个存放元素的位置
            // 插入时，先减，再赋值
            // 删除时，索引 +1（注意取模）
            front = 0;
            // 尾部指向下一个插入元素的位置
            // 插入时，先赋值，再加
            // 删除时，索引 -1（注意取模）
            rear = 0;
        }

        /**
         * Adds an item at the front of Deque. Return true if the operation is successful.
         */
        public bool InsertFront (int value) {
            if (IsFull ()) {
                return false;
            }
            front = (front - 1 + capacity) % capacity;
            arr[front] = value;
            return true;
        }

        /**
         * Adds an item at the rear of Deque. Return true if the operation is successful.
         */
        public bool InsertLast (int value) {
            if (IsFull ()) {
                return false;
            }
            arr[rear] = value;
            rear = (rear + 1) % capacity;
            return true;
        }

        /**
         * Deletes an item from the front of Deque. Return true if the operation is successful.
         */
        public bool DeleteFront () {
            if (IsEmpty ()) {
                return false;
            }
            // front 被设计在数组的开头，所以是 +1
            front = (front + 1) % capacity;
            return true;
        }

        /**
         * Deletes an item from the rear of Deque. Return true if the operation is successful.
         */
        public bool DeleteLast () {
            if (IsEmpty ()) {
                return false;
            }
            // rear 被设计在数组的末尾，所以是 -1
            rear = (rear - 1 + capacity) % capacity;
            return true;
        }

        /**
         * Get the front item from the deque.
         */
        public int GetFront () {
            if (IsEmpty ()) {
                return -1;
            }
            return arr[front];
        }

        /**
         * Get the last item from the deque.
         */
        public int GetRear () {
            if (IsEmpty ()) {
                return -1;
            }
            // 当 rear 为 0 时防止数组越界
            return arr[(rear - 1 + capacity) % capacity];
        }

        /**
         * Checks whether the circular deque is empty or not.
         */
        public bool IsEmpty () {
            return front == rear;
        }

        /**
         * Checks whether the circular deque is full or not.
         */
        public bool IsFull () {
            // 注意：这个设计是非常经典的做法
            return (rear + 1) % capacity == front;
        }

    }
    public class MyCircularDeque2 {
        private int[] nums;
        private int front = 0;
        private int tail = 0;
        private int size = 0;
        /** Initialize your data structure here. Set the size of the deque to be k. */
        public MyCircularDeque2 (int k) {
            nums = new int[k];
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront (int value) {
            if (IsFull ())
                return false;
            if (front == 0)
                front = nums.Length - 1;
            else
                front--;
            nums[front] = value;
            size++;
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast (int value) {
            if (IsFull ())
                return false;
            nums[tail] = value;
            tail = (tail + 1) % nums.Length;
            size++;
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront () {
            if (size == 0)
                return false;
            front++;
            front = front % nums.Length;
            size--;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast () {
            if (size == 0)
                return false;
            if (tail == 0)
                tail = nums.Length - 1;
            else
                tail--;
            size--;
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront () {
            if (size == 0)
                return -1;
            return nums[front];
        }

        /** Get the last item from the deque. */
        public int GetRear () {
            if (size == 0)
                return -1;
            if (tail == 0)
                return nums[nums.Length - 1];
            return nums[tail - 1];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty () {
            return size == 0;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull () {
            return size == nums.Length;
        }
    }
}