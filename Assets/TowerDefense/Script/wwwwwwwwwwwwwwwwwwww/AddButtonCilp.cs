using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.wwwwwwwwwwwwwwwwwwww
{
    public class AddButtonCilp : MonoBehaviour
    {
        public AudioClip clickSound;

        void Start()
        {
            // 查找场景中所有的按钮
            Button[] buttons = FindObjectsOfType<Button>();

            foreach (Button button in buttons)
            {
                // 如果按钮上没有 ButtonSound 组件，则添加一个
                if (button.gameObject.GetComponent<ButtonSound>() == null)
                {
                    ButtonSound buttonSound = button.gameObject.AddComponent<ButtonSound>();
                    buttonSound.clickSound = clickSound;
                }
            }
        }
    }
}
