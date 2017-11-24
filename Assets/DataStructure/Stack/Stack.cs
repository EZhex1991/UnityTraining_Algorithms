/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 最基本的实现，C#可以直接使用System.Collections.Generic.Stack<T>
*/
namespace EZhex1991.DataStructure
{
    public class Stack<T>
    {
        private T[] m_Elements;
        private T[] elements { get { return m_Elements; } set { m_Elements = value; } }

        public int capacity { get { return m_Elements.Length; } }

        private int m_Count;
        public int count { get { return m_Count; } private set { m_Count = value; } }

        public Stack(int capacity)
        {
            this.elements = new T[capacity];
            this.count = 0;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Push(T data)
        {
            if (count >= capacity)
            {
                return false;
            }
            elements[count] = data;
            count++;
            return true;
        }

        public T Pop()
        {
            if (count <= 0)
            {
                return default(T);
            }
            return elements[--count];
        }

        public T Peek()
        {
            if (count <= 0)
            {
                return default(T);
            }
            return elements[count];
        }
    }
}