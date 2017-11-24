/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;
using System.Collections.Generic;

namespace EZhex1991.DataStructure
{
    public interface IBinaryTreeNode : IDisposable
    {
        IBinaryTreeNode parent { get; set; }
        IBinaryTreeNode leftChild { get; set; }
        IBinaryTreeNode rightChild { get; set; }

        void SetLeftChild(IBinaryTreeNode node);
        void SetRightChild(IBinaryTreeNode node);
    }

    public interface IBinaryTreeNode<ValueType> : IDisposable
    {
        ValueType value { get; set; }
        IBinaryTreeNode<ValueType> parent { get; set; }
        IBinaryTreeNode<ValueType> leftChild { get; set; }
        IBinaryTreeNode<ValueType> rightChild { get; set; }

        void SetLeftChild(IBinaryTreeNode<ValueType> node);
        void SetRightChild(IBinaryTreeNode<ValueType> node);
    }

    public interface IBinaryTree<ValueType>
    {
        IBinaryTreeNode<ValueType> head { get; set; }
        List<ValueType> PreorderTraversal();
        List<ValueType> InorderTraversal();
        List<ValueType> PostorderTraversal();
        void Clear();
    }
}