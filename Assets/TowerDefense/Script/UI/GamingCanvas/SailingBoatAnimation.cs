using DG.Tweening;
using UnityEngine;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class SailingBoatAnimation : MonoBehaviour
    {
        private RectTransform _imageRectTransform; // 目標 Image 的 RectTransform
        [SerializeField] private float rotationAngle = 5f; // Z 軸旋轉的最大角度
        [SerializeField] private float duration = 0.5f; // 每次旋轉的時間

        private void Awake()
        {
            _imageRectTransform = this.GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            StartShake();
        }

        private void OnDisable()
        {
            StopShake();
        }

        private void StartShake()
        {
            // 設置左右旋轉動畫
            _imageRectTransform.DORotate(new Vector3(0, 0, rotationAngle), duration)
                .SetEase(Ease.InOutSine) // 使用平滑的加速減速效果
                .SetLoops(-1, LoopType.Yoyo); // 無限循環，左右往復
        }

        private void StopShake()
        {
            // 停止動畫並重置旋轉
            _imageRectTransform.DOKill();
            _imageRectTransform.rotation = Quaternion.identity; // 重置為原始旋轉
        }
    }
}