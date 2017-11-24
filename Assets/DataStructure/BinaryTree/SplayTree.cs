/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;

namespace EZhex1991.DataStructure
{
    public class SplayTree<ValueType> : BinarySearchTree<ValueType>
        where ValueType : IComparable
    {
        protected override IBinaryTreeNode<ValueType> Insert(IBinaryTreeNode<ValueType> node, ValueType value)
        {
            return base.Insert(node, value);
        }

        public override bool Contains(IBinaryTreeNode<ValueType> node, ValueType value)
        {
            return base.Contains(node, value);
        }
    }
}