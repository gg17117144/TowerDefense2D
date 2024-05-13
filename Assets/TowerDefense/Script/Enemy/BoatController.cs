using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace TowerDefense.Script.Enemy
{
    public class BoatController : MonoBehaviour
    {
        [SerializeField] private Transform boatCamera;
        [SerializeField] private Transform boatRight, boatLeft;

        private void Start()
        {
            boatCamera = this.transform;
        }

        [Button]
        void MoveBoatRight()
        {
            boatCamera.DOMove(boatRight.position, 5f);
        }
        
        [Button]
        void MoveBoatLeft()
        {
            boatCamera.DOMove(boatLeft.position, 5f);
        }
    }
}