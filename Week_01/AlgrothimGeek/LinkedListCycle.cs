using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  141. 环形链表 https://leetcode-cn.com/problems/linked-list-cycle/
     *给定一个链表，判断链表中是否有环。
     *如果链表中有某个节点，可以通过连续跟踪 next 指针再次到达，则链表中存在环。 
     *为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 
     *如果 pos 是 -1，则在该链表中没有环。注意：pos 不作为参数进行传递，仅仅是为了标识链表的实际情况。
     *如果链表中存在环，则返回 true 。 否则，返回 false 。
     *进阶：
     *你能用 O(1)（即，常量）内存解决此问题吗？ 
     */
    public class Solution141 {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int x) {
                val = x;
                next = null;
            }
        }

        public bool HasCycle (ListNode head) {
            //o(n) o(n)
            HashSet<ListNode> nodeset = new System.Collections.Generic.HashSet<ListNode> ();
            bool ishave = false;
            while (head != null) {
                if (nodeset.Contains (head)) {
                    ishave = true;
                    break;
                }
                nodeset.Add (head);
                head = head.next;
            }
            return ishave;
        }
        public bool HasCycle2 (ListNode head) {
            //o(n) o(1)
            if (head == null || head.next == null) {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast) {
                if (fast == null || fast.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }

    }
}