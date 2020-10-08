using System;
using System.Collections.Generic;

namespace AlgrothimGeek {

    /* 两两交换链表中的节点  https://leetcode-cn.com/problems/swap-nodes-in-pairs/
     *给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
     *你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
     *示例:
     *给定 1->2->3->4, 你应该返回 2->1->4->3.
     */

    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution24 {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode SwapPairs (ListNode head) {
            /* recursive solution o(n) o(n)*/
            if (head == null || head.next == null)
                return head;
            ListNode secnode = head.next;
            ListNode firnode = head;
            firnode.next = SwapPairs (secnode.next);
            secnode.next = firnode;
            return secnode;

        }
        public ListNode SwapPairs2 (ListNode head) {
            /* iterative solution */

            // Dummy node acts as the prevNode for the head node
            // of the list and hence stores pointer to the head node.
            ListNode dummy = new ListNode (-1);
            dummy.next = head;

            ListNode prevNode = dummy;

            while ((head != null) && (head.next != null)) {

                // Nodes to be swapped
                ListNode firstNode = head;
                ListNode secondNode = head.next;

                // Swapping
                prevNode.next = secondNode;
                firstNode.next = secondNode.next;
                secondNode.next = firstNode;

                // Reinitializing the head and prevNode for next swap
                prevNode = firstNode;
                head = firstNode.next; // jump
            }

            // Return the new head node.
            return dummy.next;
        }
    }
}