using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace TowerDefense.Script
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform cameraRight, cameraMid;

        private void Start()
        {
            mainCamera = this.transform;
        }

        [Button]
        void MoveCameraRight()
        {
            mainCamera.DOMove(cameraRight.position, 1f);
        }
        
        [Button]
        void MoveCameraMid()
        {
            mainCamera.DOMove(cameraMid.position, 1f);
        }
    }
}