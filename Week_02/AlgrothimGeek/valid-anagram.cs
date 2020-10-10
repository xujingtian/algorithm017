using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    /* 242. 有效的字母异位词 简单 https://leetcode-cn.com/problems/valid-anagram/description/
     *给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。
     *示例 1:
     *
     *输入: s = "anagram", t = "nagaram"
     *输出: true
     *示例 2:
     *
     *输入: s = "rat", t = "car"
     *输出: false
     *说明:
     *你可以假设字符串只包含小写字母。
     *
     *进阶:
     *如果输入字符串包含 unicode 字符怎么办？你能否调整你的解法来应对这种情况？
     */
    public class Solution242 {
        public static bool IsAnagram (string s, string t) {
            //o(nlogn) o(n)
            if (s.Length != t.Length)
                return false;
            char[] sa = s.ToCharArray ();
            char[] ta = t.ToCharArray ();
            Array.Sort (sa);
            Array.Sort (ta);
            //bool isequal= Array.Equals (sa, ta);
            /* \runtime\src\libraries\System.Private.CoreLib\src\System\Object.cs */
            // runtime/src/mono/netcore/System.Private.CoreLib/src/System/Runtime/CompilerServices/RuntimeHelpers.Mono.cs
            // runtime/src/coreclr/src/System.Private.CoreLib/src/System/ValueType.cs
            // runtime\src\libraries\System.Private.CoreLib\src\System\Char.cs
            // runtime\src\libraries\System.Private.CoreLib\src\System\Array.cs 堆排序实现

            /*Array.Equals不行，应该是因为*/
            return Enumerable.SequenceEqual (sa, ta);

        }

        public bool IsAnagra2 (string s, string t) {
            //o(n) o(1)
            if (s.Length != t.Length)
                return false;
            int[] counter = new int[26];
            for (int i = 0; i < s.Length; i++) {
                counter[s[i] - 'a']++;
                counter[t[i] - 'a']--;
            }
            foreach (int count in counter) {
                if (count != 0) {
                    return false;
                }
            }
            return true;
        }
    }
}