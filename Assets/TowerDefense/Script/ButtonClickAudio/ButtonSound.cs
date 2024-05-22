using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Prefab.Script.ButtonClickAudio
{
    public class ButtonSound : MonoBehaviour
    {
        public AudioClip clickSound;
        private AudioSource _audioSource;

        void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.clip = clickSound;
            
            Button button = GetComponent<Button>();
            
            if (button != null)
            {
                button.onClick.AddListener(PlaySound);
            }
        }

        void PlaySound()
        {
            _audioSource.Play();
        }
    }
}