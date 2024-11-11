using UnityEngine;

namespace TowerDefense.Script
{
    public class DeadTime : MonoBehaviour
    {
        void Start()
        {
            Invoke(nameof(Destroy), 1f);
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}