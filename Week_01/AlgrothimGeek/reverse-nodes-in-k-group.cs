using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  25. K 个一组翻转链表  https://leetcode-cn.com/problems/reverse-nodes-in-k-group
     *给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。
     *k 是一个正整数，它的值小于或等于链表的长度。
     *如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。
     *
     *
     */
    public class Solution25 {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }

        }
        public ListNode ReverseKGroup (ListNode head, int k) {
            ListNode hair = new ListNode (-1);
            hair.next = head;
            ListNode hairpre = hair;

            while (head != null) {
                ListNode tail = hairpre;
                for (int i = 0; i < k; ++i) {
                    tail = tail.next;
                    if (tail == null) {
                        return hair.next; //注意，在循环没有结束时，tail为NULL，代表剩下的节点已经不能满足K的要求了
                    }
                }
                ListNode nex = tail.next; //此时tail是要分组的尾节点，再next则到了下一个分组的原始头节点，此时是为了做缓存吗？
                ListNode[] reverse = MyReverse (head, tail); //head
                head = reverse[0];
                tail = reverse[1];
                // 把子链表重新接回原链表
                hairpre.next = head;
                tail.next = nex;
                hairpre = tail;
                head = tail.next;
            }

            return hair.next;
        }

        public ListNode[] MyReverse (ListNode head, ListNode tail) {
            ListNode prev = tail.next;
            ListNode p = head;
            while (prev != tail) {
                ListNode nex = p.next;
                p.next = prev;
                prev = p;
                p = nex;
            }
            return new ListNode[] { tail, head };
        }

        public ListNode ReverseKGroup22 (ListNode head, int k) {
            Stack<ListNode> nodeStack = new Stack<ListNode> (k);
            ListNode cur = head;
            ListNode newHead = null;
            ListNode elTmpPre = null;
            while (cur != null) {
                nodeStack.Clear ();
                ListNode tmpHead = cur;
                for (int i = 0; i < k; i++) {
                    if (cur != null)
                        nodeStack.Push (cur);
                    cur = cur?.next;
                }
                if (nodeStack.Count != 3)
                    nodeStack.Clear ();

                while (nodeStack.Count != 0) {
                    ListNode el = nodeStack.Pop ();
                    if (newHead == null)
                        newHead = el;
                    if (elTmpPre == null) {
                        elTmpPre = el;
                    } else {
                        elTmpPre.next = el;
                        elTmpPre = el;
                    }
                }
            }
            return newHead;
            /*  ListNode cur = head;
             HashSet<ListNode> hash = new HashSet<ListNode> ();
             ListNode newHead = null;
             while (cur != null) {
                 ListNode tmpHead = cur;
                 for (int i = 0; i < k; i++) {
                     if(cur!=null)
                         cur = cur.next;
                 }
                 if (cur != null) {
                     while (tmpHead != cur) {
                         ListNode ntmp = tmpHead.next;
                         tmpHead.next = newHead;
                         newHead = tmpHead;
                         tmpHead = ntmp;
                     }
                 }
                 newHead = tmpHead;
             }
             return cur; */

        }

    }
}