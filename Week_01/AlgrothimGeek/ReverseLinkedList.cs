using System;
using System.Collections.Generic;

namespace AlgrothimGeek {

    /*
    反转链表  https://leetcode-cn.com/problems/reverse-linked-list/
    反转一个单链表。

    *示例:
    *
    *输入: 1->2->3->4->5->NULL
    *输出: 5->4->3->2->1->NULL
    *进阶:
    *你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
    */
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public class Solution206 {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int x) { val = x; }
        }

        public ListNode ReverseList (ListNode head) {
            //O(n) O(1)
            /* ListNode cur = head;
            ListNode pre = null;
            while (cur != null) {
                ListNode tmp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = tmp;
            }
            return pre; */
            /* iterative solution */
            ListNode newHead = null;
            while (head != null) {
                ListNode next = head.next;
                head.next = newHead;
                newHead = head;
                head = next;
            }
            return newHead;
        }
        public ListNode ReverseList2 (ListNode head) {
            //O(n) O(n)
            /* if (head == null || head.next == null)
                return head;
            head = ReverseList2 (head);
            head.next.next = head;
            head.next = null;
            return head; */
            /* recursive solution */
            return reverseListInt (head, null);
        }

        private ListNode reverseListInt (ListNode head, ListNode newHead) {
            if (head == null)
                return newHead;
            ListNode next = head.next;
            head.next = newHead;
            return reverseListInt (next, head);
        }
    }
}