/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using UnityEngine;

namespace EZhex1991.DataStructure
{
    public class Main : MonoBehaviour
    {
        private static Main instance;
        public static Main Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<Main>();
                }
                return instance;
            }
        }

        public UI_Menu ui_Menu;

        protected virtual void Awake()
        {
            instance = this;
        }

        void Start()
        {
            ui_Menu.Show();
        }
    }
}