/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;

namespace EZhex1991.DataStructure
{
    public enum RemovePrefer { Left = -1, Self = 0, Right = 1 }

    public interface IBinarySearchTree<ValueType> : IBinaryTree<ValueType>
        where ValueType : IComparable
    {
        void Insert(ValueType value);
        void Remove(ValueType value);
        void Remove(ValueType value, RemovePrefer prefer);
        bool Contains(ValueType value);
        ValueType FindMin();
        ValueType FindMax();
    }
}