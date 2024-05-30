using System;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.UI;
using UnityEngine;

namespace TowerDefense.Script
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform cameraRight, cameraMid;

        private void Awake()
        {
            mainCamera = transform;
        }

        [Button]
        public void MoveCameraRight()
        {
            GamingUIHandler.Instance.CloseGamingUI();
            mainCamera.DOMove(cameraRight.position, 1f);
        }
        
        [Button]
        public void MoveCameraMid()
        {
            GamingUIHandler.Instance.OpenGamingUI();
            mainCamera.DOMove(cameraMid.position, 1f);
        }
    }
}