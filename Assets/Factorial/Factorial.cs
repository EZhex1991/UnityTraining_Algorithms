/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991
{
    public class Factorial : MonoBehaviour
    {
        public int number = 3;

        void Start()
        {
            Debug.Log(Calculate(number));
        }

        int Calculate(int num)
        {
            if (num <= 0)
            {
                return num == 0 ? 1 : 0;
            }
            else
            {
                return num * Calculate(num - 1);
            }
        }
    }
}