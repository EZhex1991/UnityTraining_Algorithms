/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EZhex1991.DataStructure
{
    public class UI_Stack : UI_Base
    {
        public Transform output;

        public InputField input_Capacity;
        public Button button_Init;
        public InputField input_Element;
        public Button button_Push;
        public Button button_Pop;
        public Button button_Clear;

        private int m_Capacity = 5;
        private int capacity { get { return m_Capacity; } set { m_Capacity = Mathf.Clamp(value, 0, 10); } }
        private Stack<string> stack;
        private List<Image> imageList = new List<Image>();
        private List<Text> textList = new List<Text>();

        protected override void Start()
        {
            base.Start();
            foreach (Transform tr in output)
            {
                imageList.Add(tr.GetComponent<Image>());
                textList.Add(tr.GetChild(0).GetComponent<Text>());
            }
            button_Init.onClick.AddListener(Init);
            button_Push.onClick.AddListener(Push);
            button_Pop.onClick.AddListener(Pop);
            button_Clear.onClick.AddListener(Clear);
            InitStack();
        }

        void InitStack()
        {
            input_Capacity.text = capacity.ToString();
            stack = new Stack<string>(capacity);
            for (int i = 0; i < output.childCount; i++)
            {
                imageList[i].gameObject.SetActive(i < capacity);
                imageList[i].color = Color.white;
                textList[i].text = "";
            }
        }

        void Init()
        {
            capacity = System.Convert.ToInt32(input_Capacity.text);
            InitStack();
        }

        void Push()
        {
            if (stack.Push(input_Element.text))
            {
                imageList[stack.count - 1].color = Color.green;
                textList[stack.count - 1].text = input_Element.text;
            }
        }
        void Pop()
        {
            if (stack.Pop() != null)
            {
                imageList[stack.count].color = Color.red;
            }
        }
        void Clear()
        {
            stack.Clear();
            for (int i = 0; i < output.childCount; i++)
            {
                imageList[i].color = Color.white;
                textList[i].text = "";
            }
        }
    }
}