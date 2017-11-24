/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System.Collections.Generic;

namespace EZhex1991.DataStructure
{
    public class BinaryTreeNode<ValueType> : IBinaryTreeNode<ValueType>
    {
        protected ValueType m_Value;
        public ValueType value { get { return m_Value; } set { m_Value = value; } }
        protected BinaryTreeNode<ValueType> m_Parent;
        public IBinaryTreeNode<ValueType> parent { get { return m_Parent; } set { m_Parent = value as BinaryTreeNode<ValueType>; } }
        protected BinaryTreeNode<ValueType> m_LeftChild;
        public IBinaryTreeNode<ValueType> leftChild { get { return m_LeftChild; } set { m_LeftChild = value as BinaryTreeNode<ValueType>; } }
        protected BinaryTreeNode<ValueType> m_RightChild;
        public IBinaryTreeNode<ValueType> rightChild { get { return m_RightChild; } set { m_RightChild = value as BinaryTreeNode<ValueType>; } }

        public BinaryTreeNode(ValueType value)
        {
            m_Value = value;
        }

        public void SetLeftChild(IBinaryTreeNode<ValueType> node)
        {
            if (leftChild == node) return;
            if (leftChild != null)
            {
                leftChild.parent = null;
            }
            if (node != null)
            {
                node.parent = this;
            }
            leftChild = node;
        }
        public void SetRightChild(IBinaryTreeNode<ValueType> node)
        {
            if (rightChild == node) return;
            if (rightChild != null)
            {
                rightChild.parent = null;
            }
            if (node != null)
            {
                node.parent = this;
            }
            rightChild = node;
        }

        public void Dispose()
        {
            if (leftChild != null)
            {
                leftChild.Dispose();
                leftChild = null;
            }
            if (rightChild != null)
            {
                rightChild.Dispose();
                rightChild = null;
            }
            parent = null;
        }
    }

    public class BinaryTree<ValueType> : IBinaryTree<ValueType>
    {
        public IBinaryTreeNode<ValueType> head { get; set; }

        public List<ValueType> PreorderTraversal()
        {
            List<ValueType> result = new List<ValueType>();
            PreorderTraversal(head, ref result);
            return result;
        }
        protected virtual void PreorderTraversal(IBinaryTreeNode<ValueType> node, ref List<ValueType> result)
        {
            if (node == null) return;
            result.Add(node.value);
            PreorderTraversal(node.leftChild, ref result);
            PreorderTraversal(node.rightChild, ref result);
        }
        public List<ValueType> InorderTraversal()
        {
            List<ValueType> result = new List<ValueType>();
            InorderTraversal(head, ref result);
            return result;
        }
        protected virtual void InorderTraversal(IBinaryTreeNode<ValueType> node, ref List<ValueType> result)
        {
            if (node == null) return;
            InorderTraversal(node.leftChild, ref result);
            result.Add(node.value);
            InorderTraversal(node.rightChild, ref result);
        }
        public List<ValueType> PostorderTraversal()
        {
            List<ValueType> result = new List<ValueType>();
            PostorderTraversal(head, ref result);
            return result;
        }
        protected virtual void PostorderTraversal(IBinaryTreeNode<ValueType> node, ref List<ValueType> result)
        {
            if (node == null) return;
            PostorderTraversal(node.leftChild, ref result);
            PostorderTraversal(node.rightChild, ref result);
            result.Add(node.value);
        }

        public int GetHeight(IBinaryTreeNode<ValueType> node)
        {
            if (node == null) return 0;
            return Max(GetHeight(node.leftChild), GetHeight(node.rightChild)) + 1;
        }
        private int Max(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        public void Clear()
        {
            if (head != null)
            {
                head.Dispose();
            }
            head = null;
        }
    }
}