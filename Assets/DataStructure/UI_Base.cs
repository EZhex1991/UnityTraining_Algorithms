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
    public interface IUI
    {
        void Show();
        void Hide();
    }

    public abstract class UI_Base : MonoBehaviour, IUI
    {
        public Button button_Back;

        protected virtual void Start()
        {
            button_Back.onClick.AddListener(Hide);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        public virtual void Hide()
        {
            gameObject.SetActive(false);
            Main.Instance.ui_Menu.Show();
        }
    }
}