using System;
using UnityEngine;

namespace TowerDefense.Script.MapObject
{
    public class ObjectRenderingOrderLayer : MonoBehaviour
    {
        
        private SpriteRenderer _spriteRenderer;
        private void Start()
        {
            // SetSortingLayer();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            SetSortingLayer();
        }

        void SetSortingLayer()
        {
            var positionY = Mathf.RoundToInt(transform.position.y);
            var spriteRenderer = _spriteRenderer;
            spriteRenderer.sortingLayerName = "Default";
            spriteRenderer.sortingOrder = 0 - positionY;
        }
    }
}