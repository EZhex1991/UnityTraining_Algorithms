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
    public class UI_Queue : UI_Base
    {
        public Transform output;

        public InputField input_Capacity;
        public Button button_Init;
        public InputField input_Element;
        public Button button_Enqueue;
        public Button button_Dequeue;
        public Button button_Clear;

        private int m_Capacity = 5;
        private int capacity { get { return m_Capacity; } set { m_Capacity = Mathf.Clamp(value, 0, 10); } }
        private Queue<string> queue;
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
            button_Enqueue.onClick.AddListener(Enqueue);
            button_Dequeue.onClick.AddListener(Dequeue);
            button_Clear.onClick.AddListener(Clear);
            InitQueue();
        }

        void InitQueue()
        {
            input_Capacity.text = capacity.ToString();
            queue = new Queue<string>(capacity);
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
            InitQueue();
        }

        void Enqueue()
        {
            if (queue.Count >= capacity) return;
            queue.Enqueue(input_Element.text);
            imageList[queue.Count - 1].color = Color.green;
            for (int i = queue.Count - 1; i >= 1; i--)
            {
                textList[i].text = textList[i - 1].text;
            }
            textList[0].text = input_Element.text;
        }
        void Dequeue()
        {
            if (queue.Count <= 0) return;
            queue.Dequeue();
            imageList[queue.Count].color = Color.red;
        }
        void Clear()
        {
            queue.Clear();
            for (int i = 0; i < output.childCount; i++)
            {
                imageList[i].color = Color.white;
                textList[i].text = "";
            }
        }
    }
}