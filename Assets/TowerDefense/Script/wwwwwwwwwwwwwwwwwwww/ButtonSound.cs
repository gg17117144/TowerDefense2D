using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.wwwwwwwwwwwwwwwwwwww
{
    public class ButtonSound : MonoBehaviour
    {
        public AudioClip clickSound;
        private AudioSource audioSource;

        void Start()
        {
            // 为按钮添加一个 AudioSource 组件
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clickSound;
        
            // 获取按钮组件
            Button button = GetComponent<Button>();

            // 为按钮点击事件添加音效播放
            if (button != null)
            {
                button.onClick.AddListener(PlaySound);
            }
        }

        void PlaySound()
        {
            audioSource.Play();
        }
    }
}