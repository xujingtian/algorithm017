using System;
using System.Collections.Generic;

namespace AlgrothimGeek {
    /*  20. 有效的括号 https://leetcode-cn.com/problems/valid-parentheses/
     *给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
     *有效字符串需满足：
     *左括号必须用相同类型的右括号闭合。
     *左括号必须以正确的顺序闭合。
     *注意空字符串可被认为是有效字符串。
     *
     *
     */
    public class Solution20 {
        public bool IsValid (string s) {
            if (s.Length % 2 == 1) {
                return false;
            }
            Stack<char> st = new Stack<char> ();
            Dictionary<char, char> dictionary = new Dictionary<char, char> ();
            dictionary.Add (')', '(');
            dictionary.Add (']', '[');
            dictionary.Add ('}', '{');
            char[] chars = s.ToCharArray ();

            foreach (char c in chars) {
                if (c.Equals ('(') || c.Equals ('[') || c.Equals ('{')) //判断是不是左括号
                {
                    st.Push (c); //将左括号放入堆栈中
                }
                //如果是右括号
                //判断前面是否有左括号，如果有左括号是不是和自己是一对。
                else if (st.Count == 0 || !st.Pop ().Equals (dictionary[c])) {
                    return false;
                }
            }
            //遍历完之后左括号应该都已经弹出，堆栈中应该为空。
            return st.Count == 0;
        }
        public bool IsValid2 (string s) {
            Stack<char> stack = new Stack<char> ();

            for (int i = 0; i < s.Length; ++i) {
                if (s[i] == '(') stack.Push (')');
                else if (s[i] == '[') stack.Push (']');
                else if (s[i] == '{') stack.Push ('}');
                else if (stack.Count != 0 || s[i] != stack.Pop ()) return false;
            }

            return stack.Count == 0;
        }

        private bool IsFormat (char start, char end) {
            /* if (start != '(' || start != '[' || start != '{') {
                return false;
            } */
            if (start == '(' && end == ')')
                return true;
            else if (start == '[' && end == ']')
                return true;
            else if (start == '{' && end == '}')
                return true;
            return false;
        }

    }
}