/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;

namespace EZhex1991.DataStructure
{
    public class BalancedBinarySearchTree<ValueType> : BinarySearchTree<ValueType>
        where ValueType : IComparable
    {
        protected int GetBalanceFactor(IBinaryTreeNode<ValueType> node)
        {
            if (node == null) return 0;
            return GetHeight(node.leftChild) - GetHeight(node.rightChild);
        }

        protected IBinaryTreeNode<ValueType> Balance(IBinaryTreeNode<ValueType> node)
        {
            int bf = GetBalanceFactor(node);
            if (bf >= 2)
            {
                int bfL = GetBalanceFactor(node.leftChild);
                if (bfL >= 0)
                    return RotateLL(node);
                else
                    return RotateLR(node);
            }
            else if (bf <= -2)
            {
                int bfR = GetBalanceFactor(node.rightChild);
                if (bfR <= 0)
                    return RotateRR(node);
                else
                    return RotateRL(node);
            }
            else return node;
        }

        protected override IBinaryTreeNode<ValueType> Insert(IBinaryTreeNode<ValueType> node, ValueType value)
        {
            return Balance(base.Insert(node, value));
        }

        protected override IBinaryTreeNode<ValueType> Remove(IBinaryTreeNode<ValueType> node, ValueType value, RemovePrefer prefer)
        {
            return Balance(base.Remove(node, value, prefer));
        }
    }
}