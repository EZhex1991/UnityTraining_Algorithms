/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991
{
    public class Fibonacci : MonoBehaviour
    {
        public int number = 20;

        void Start()
        {
            for (int i = 1; i <= number; i++)
            {
                print(i + "\t" + Calculate(i));
            }
        }

        int Calculate(int num)
        {
            if (num <= 2)
            {
                return 1;
            }
            else
            {
                return Calculate(num - 1) + Calculate(num - 2);
            }
        }
    }
}