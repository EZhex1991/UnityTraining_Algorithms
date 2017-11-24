/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EZhex1991.DataStructure
{
    public class UI_Tree : UI_Base
    {
        public Transform output;

        public InputField input_Insert;
        public Button button_Insert;
        public InputField input_Remove;
        public Button button_Remove;
        public InputField input_Contains;
        public Button button_Contains;
        public Button button_Clear;

        public IBinarySearchTree<int> intTree;
        public BinaryTree<Image> imageTree = new BinaryTree<Image>();
        public BinaryTree<Text> textTree = new BinaryTree<Text>();

        public void Show<T>(T tree) where T : IBinarySearchTree<int>
        {
            intTree = tree;
            Show();
            RefreshOutput();
        }
        protected override void Start()
        {
            base.Start();
            button_Insert.onClick.AddListener(Insert);
            button_Remove.onClick.AddListener(Remove);
            button_Contains.onClick.AddListener(Contains);
            button_Clear.onClick.AddListener(Clear);
            imageTree.head = new BinaryTreeNode<Image>(output.GetComponent<Image>());
            textTree.head = new BinaryTreeNode<Text>(output.GetChild(0).GetComponent<Text>());
            InitOutput(output, imageTree.head, textTree.head);
            RefreshOutput();
        }
        void InitOutput(Transform tr, IBinaryTreeNode<Image> tImage, IBinaryTreeNode<Text> tText)
        {
            if (tr.childCount == 3)
            {
                Transform left = tr.GetChild(1);
                tImage.SetLeftChild(new BinaryTreeNode<Image>(left.GetComponent<Image>()));
                tText.SetLeftChild(new BinaryTreeNode<Text>(left.GetChild(0).GetComponent<Text>()));
                InitOutput(left, tImage.leftChild, tText.leftChild);
                Transform right = tr.GetChild(2);
                tImage.SetRightChild(new BinaryTreeNode<Image>(right.GetComponent<Image>()));
                tText.SetRightChild(new BinaryTreeNode<Text>(right.GetChild(0).GetComponent<Text>()));
                InitOutput(right, tImage.rightChild, tText.rightChild);
            }
        }

        void Insert()
        {
            int value = Convert.ToInt32(input_Insert.text);
            intTree.Insert(value);
            RefreshOutput();
        }
        void Remove()
        {
            int value = Convert.ToInt32(input_Remove.text);
            intTree.Remove(value);
            RefreshOutput();
        }
        void Contains()
        {
            int value = Convert.ToInt32(input_Contains.text);
            button_Contains.targetGraphic.color = intTree.Contains(value) ? Color.green : Color.red;
        }
        void Clear()
        {
            intTree.Clear();
            RefreshOutput();
        }

        public void RefreshOutput()
        {
            RefreshOutput(intTree.head, imageTree.head, textTree.head);
            string result = "";
            var list = intTree.InorderTraversal();
            if (list != null)
            {
                foreach (var value in list)
                {
                    result += "->" + value;
                }
            }
            print(result);
        }
        public void RefreshOutput(IBinaryTreeNode<int> tInt, IBinaryTreeNode<Image> tImage, IBinaryTreeNode<Text> tText)
        {
            if (tImage != null && tText != null)
            {
                if (tInt != null)
                {
                    tImage.value.color = Color.green;
                    tText.value.text = tInt.value.ToString();
                    RefreshOutput(tInt.leftChild, tImage.leftChild, tText.leftChild);
                    RefreshOutput(tInt.rightChild, tImage.rightChild, tText.rightChild);
                }
                else
                {
                    tImage.value.color = Color.red;
                    tText.value.text = "";
                    RefreshOutput(null, tImage.leftChild, tText.leftChild);
                    RefreshOutput(null, tImage.rightChild, tText.rightChild);
                }
            }
        }
    }
}