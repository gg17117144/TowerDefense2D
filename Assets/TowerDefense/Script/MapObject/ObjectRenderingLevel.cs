using UnityEngine;

namespace TowerDefense.Script.MapObject
{
    public class ObjectRenderingLevel : MonoBehaviour
    {
        private void Start()
        {
            SetSortingLayer();
        }

        void SetSortingLayer()
        {
            var positionY = Mathf.RoundToInt(transform.position.y);
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Default";
            spriteRenderer.sortingOrder = 0 - positionY;
        }
    }
}