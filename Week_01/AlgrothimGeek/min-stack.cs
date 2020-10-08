using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  155. 最小栈  II  https://leetcode-cn.com/problems/min-stack/
     *设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。
     *push(x) —— 将元素 x 推入栈中。
     *pop() —— 删除栈顶的元素。
     *top() —— 获取栈顶元素。
     *getMin() —— 检索栈中的最小元素。
     */
    public class MinStack {
        /** initialize your data structure here. */
        Stack<int> _initStack = null;
        Stack<int> _minStack = null;

        public MinStack () {
            _initStack = new Stack<int> ();
            _minStack = new Stack<int> ();
            _minStack.Push (int.MaxValue);
        }

        public void Push (int x) {
            _initStack.Push (x);
            _minStack.Push (Math.Min (_minStack.Peek (), x));
        }

        public void Pop () {
            _initStack.Pop ();
            _minStack.Pop ();
        }

        public int Top () {
            return _initStack.Peek ();
        }

        public int GetMin () {
            return _minStack.Peek ();
        }
    }
}