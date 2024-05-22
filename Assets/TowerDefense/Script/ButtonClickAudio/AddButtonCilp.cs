using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Prefab.Script.ButtonClickAudio
{
    public class AddButtonCilp : MonoBehaviour
    {
        public AudioClip clickSound;

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
