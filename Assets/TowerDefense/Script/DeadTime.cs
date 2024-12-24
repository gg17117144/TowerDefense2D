using UnityEngine;

namespace TowerDefense.Script
{
    public class DeadTime : MonoBehaviour
    {
        void OnEnable()
        {
            Invoke(nameof(CloseObject), 1f);
        }

        private void CloseObject()
        {
            gameObject.SetActive(false);
        }
    }
}