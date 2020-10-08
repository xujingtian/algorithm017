using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  142. 环形链表 II  https://leetcode-cn.com/problems/linked-list-cycle-ii
     *给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
     *为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 
     *如果 pos 是 -1，则在该链表中没有环。     
     */
    public class Solution142 {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int x) {
                val = x;
                next = null;
            }
        }
        public ListNode DetectCycle (ListNode head) {
            /* Dictionary<ListNode, int> tmp = new Dictionary<ListNode, int> ();
            int pos = -1;
            while (head != null) {
                pos++;
                if (tmp.ContainsKey (head)) {
                    return head;
                }
                tmp.Add (head, pos);
                head = head.next;
            }
            return null; */
            HashSet<ListNode> nodeset = new System.Collections.Generic.HashSet<ListNode> ();
            while (head != null) {
                if (nodeset.Contains (head)) {
                    return head;
                }
                nodeset.Add (head);
                head = head.next;
            }
            return null;
        }
        public ListNode DetectCycle2 (ListNode head) {
            Dictionary<ListNode, int> tmp = new Dictionary<ListNode, int> ();
            int pos = -1;
            while (head != null) {
                pos++;
                if (tmp.ContainsKey (head)) {
                    return head;
                }
                tmp.Add (head, pos);
                head = head.next;
            }
            return null;
        }

        /**
         * 双指针 时间复杂度 O(n) 空间复杂度 O(1)
         *
         * 先用双指针法判断链表是否有环，若有则返回第一次相遇的节点
         *
         * 第一次相遇时，假设【慢指针】 slow 走了 k 步，那么快指针 fast 一定走了 2k 步，
         * 也就是说比 slow 多走了 k 步（也就是环的长度）。
         *
         * 设【相遇点】距【环的起点】的距离为 m，
         *      那么【环的起点】距【头结点】 head 的距离为 k - m，（慢指针是第一次走到这）
         * 也就是说如果从 head 前进 k - m 步就能到达环起点。
         * 巧的是，如果从相遇点继续前进 k - m 步，也能再次到达环起点。
         *
         * 所以，我们让一个指针从起点出发，另一个指针从相遇点出发，二者速度相同，相遇时，就到达了环的起点
         *
         * @param head
         * @return
         */

        public ListNode DetectCycle3 (ListNode head) {
            if (head == null) {
                return null;
            }

            // If there is a cycle, the fast/slow pointers will intersect at some
            // node. Otherwise, there is no cycle, so we cannot find an e***ance to
            // a cycle.
            ListNode intersect = GetIntersect (head);
            if (intersect == null) {
                return null;
            }

            // To find the e***ance to the cycle, we have two pointers traverse at
            // the same speed -- one from the front of the list, and the other from
            // the point of intersection.
            ListNode ptr1 = head;
            ListNode ptr2 = intersect;
            while (ptr1 != ptr2) {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return ptr1;
        }
        private ListNode GetIntersect (ListNode head) {
            ListNode tortoise = head;
            ListNode hare = head;

            // A fast pointer will either loop around a cycle and meet the slow
            // pointer or reach the `null` at the end of a non-cyclic list.
            while (hare != null && hare.next != null) {
                tortoise = tortoise.next;
                hare = hare.next.next;
                if (tortoise == hare) {
                    return tortoise;
                }
            }

            return null;
        }

    }
}