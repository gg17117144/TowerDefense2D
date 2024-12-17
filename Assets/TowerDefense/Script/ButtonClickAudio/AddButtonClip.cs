using System;
using TowerDefense.Prefab.Script.ButtonClickAudio;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.ButtonClickAudio
{
    public class AddButtonClip : MonoBehaviour
    {
        public AudioClip clickSound;

        [Obsolete("Obsolete")]
        void Start()
        {
            Button[] buttons = FindObjectsOfType<Button>();

            foreach (Button button in buttons)
            {
                if (button.gameObject.GetComponent<ButtonSound>() == null)
                {
                    ButtonSound buttonSound = button.gameObject.AddComponent<ButtonSound>();
                    buttonSound.clickSound = clickSound;
                }
            }
        }
    }
}
