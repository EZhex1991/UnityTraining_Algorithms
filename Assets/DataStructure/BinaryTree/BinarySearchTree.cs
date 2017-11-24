/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;

namespace EZhex1991.DataStructure
{
    public class BinarySearchTree<ValueType> : BinaryTree<ValueType>, IBinarySearchTree<ValueType>
        where ValueType : IComparable
    {
        protected IBinaryTreeNode<ValueType> RotateLL(IBinaryTreeNode<ValueType> node)
        {
            IBinaryTreeNode<ValueType> newRoot = node.leftChild;
            node.SetLeftChild(newRoot.rightChild);
            newRoot.SetRightChild(node);
            return newRoot;
        }
        protected IBinaryTreeNode<ValueType> RotateRR(IBinaryTreeNode<ValueType> node)
        {
            IBinaryTreeNode<ValueType> newRoot = node.rightChild;
            node.SetRightChild(newRoot.leftChild);
            newRoot.SetLeftChild(node);
            return newRoot;
        }
        protected IBinaryTreeNode<ValueType> RotateLR(IBinaryTreeNode<ValueType> node)
        {
            node.SetLeftChild(RotateRR(node.leftChild));
            return RotateLL(node);
        }
        protected IBinaryTreeNode<ValueType> RotateRL(IBinaryTreeNode<ValueType> node)
        {
            node.SetRightChild(RotateLL(node.rightChild));
            return RotateRR(node);
        }

        public virtual void Insert(ValueType value)
        {
            head = Insert(head, value);
        }
        protected virtual IBinaryTreeNode<ValueType> Insert(IBinaryTreeNode<ValueType> node, ValueType value)
        {
            if (node == null) return new BinaryTreeNode<ValueType>(value);
            int result = value.CompareTo(node.value);
            if (result < 0)
            {
                node.SetLeftChild(Insert(node.leftChild, value));
            }
            else if (result > 0)
            {
                node.SetRightChild(Insert(node.rightChild, value));
            }
            return node;
        }

        public virtual void Remove(ValueType value)
        {
            head = Remove(head, value, RemovePrefer.Right);
        }
        public virtual void Remove(ValueType value, RemovePrefer prefer)
        {
            head = Remove(head, value, prefer);
        }
        protected virtual IBinaryTreeNode<ValueType> Remove(IBinaryTreeNode<ValueType> node, ValueType value, RemovePrefer prefer)
        {
            if (node == null) return null;
            int result = value.CompareTo(node.value);
            if (result < 0)
            {
                node.SetLeftChild(Remove(node.leftChild, value, prefer));
            }
            else if (result > 0)
            {
                node.SetRightChild(Remove(node.rightChild, value, prefer));
            }
            else
            {
                if (node.leftChild != null && node.rightChild != null)
                {
                    if (prefer == RemovePrefer.Left)
                    {
                        RemoveLeft(node, value, prefer);
                    }
                    else if (prefer == RemovePrefer.Right)
                    {
                        RemoveRight(node, value, prefer);
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (node.leftChild != null && node.rightChild == null)
                {
                    RemoveLeft(node, value, prefer);
                }
                else if (node.leftChild == null && node.rightChild != null)
                {
                    RemoveRight(node, value, prefer);
                }
                else
                {
                    return null;
                }
            }
            return node;
        }
        protected virtual IBinaryTreeNode<ValueType> RemoveLeft(IBinaryTreeNode<ValueType> node, ValueType value, RemovePrefer prefer)
        {
            IBinaryTreeNode<ValueType> leftMax = FindMax(node.leftChild);
            node.value = leftMax.value;
            node.SetLeftChild(Remove(node.leftChild, node.value, prefer));
            return node;
        }
        protected virtual IBinaryTreeNode<ValueType> RemoveRight(IBinaryTreeNode<ValueType> node, ValueType value, RemovePrefer prefer)
        {
            IBinaryTreeNode<ValueType> rightMin = FindMin(node.rightChild);
            node.value = rightMin.value;
            node.SetRightChild(Remove(node.rightChild, node.value, prefer));
            return node;
        }

        public virtual bool Contains(ValueType value)
        {
            return Contains(head, value);
        }
        public virtual bool Contains(IBinaryTreeNode<ValueType> node, ValueType value)
        {
            if (node == null) return false;
            int result = value.CompareTo(node.value);
            if (result < 0)
                return Contains(node.leftChild, value);
            else if (result > 0)
                return Contains(node.rightChild, value);
            else
                return true;
        }

        public virtual ValueType FindMin()
        {
            return head == null ? default(ValueType) : FindMin(head).value;
        }
        public virtual IBinaryTreeNode<ValueType> FindMin(IBinaryTreeNode<ValueType> node)
        {
            return node.leftChild == null ? node : FindMin(node.leftChild);
        }
        public virtual ValueType FindMax()
        {
            return head == null ? default(ValueType) : FindMax(head).value;
        }
        public virtual IBinaryTreeNode<ValueType> FindMax(IBinaryTreeNode<ValueType> node)
        {
            return node.rightChild == null ? node : FindMax(node.rightChild);
        }
    }
}