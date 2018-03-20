/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using System.Collections.Generic;
using UnityEngine;

namespace EZhex1991
{
    public class Permutation : MonoBehaviour
    {
        public List<char> charList = new List<char>() { 'a', 'b', 'c' };
        public int length = 3;

        void Start()
        {
            Append(charList, "", length);
        }

        void Append(List<char> charList, string str, int length)
        {
            if (length <= 0)
            {
                print(str);
            }
            else
            {
                for (int i = 0; i < charList.Count; i++)
                {
                    string newStr = str + charList[i];
                    List<char> newList = new List<char>(charList);
                    newList.RemoveAt(i);
                    Append(newList, newStr, length - 1);
                }
            }
        }
    }
}