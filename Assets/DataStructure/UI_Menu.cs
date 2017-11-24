/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using UnityEngine;
using UnityEngine.UI;

namespace EZhex1991.DataStructure
{
    public class UI_Menu : MonoBehaviour, IUI
    {
        public Button button_Exit;

        public Button button_Stack;
        public UI_Stack ui_Stack;
        public Button button_Queue;
        public UI_Queue ui_Queue;
        public Button button_BinarySearchTree;
        public Button button_AVLTree;
        public Button button_SplayTree;
        public UI_Tree ui_Tree;

        void Start()
        {
            button_Exit.onClick.AddListener(Exit);
            button_Stack.onClick.AddListener(Stack);
            button_Queue.onClick.AddListener(Queue);
            button_BinarySearchTree.onClick.AddListener(BinarySearchTree);
            button_AVLTree.onClick.AddListener(AVLTree);
            button_SplayTree.onClick.AddListener(SplayTree);
            ui_Stack.Hide();
            ui_Queue.Hide();
            ui_Tree.Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void Exit()
        {
            Application.Quit();
        }

        public void Stack()
        {
            Hide();
            ui_Stack.Show();
        }
        public void Queue()
        {
            Hide();
            ui_Queue.Show();
        }
        public void BinarySearchTree()
        {
            Hide();
            ui_Tree.Show(new BinarySearchTree<int>());
        }
        public void AVLTree()
        {
            Hide();
            ui_Tree.Show(new BalancedBinarySearchTree<int>());
        }
        public void SplayTree()
        {
            Hide();
            ui_Tree.Show(new BalancedBinarySearchTree<int>());
        }
    }
}