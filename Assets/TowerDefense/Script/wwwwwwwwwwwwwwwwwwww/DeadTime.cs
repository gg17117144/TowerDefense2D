using UnityEngine;

namespace TowerDefense.Script.wwwwwwwwwwwwwwwwwwww
{
    public class DeadTime : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(Destroy), 1f);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}