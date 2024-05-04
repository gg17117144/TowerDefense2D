using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TowerDefense.Script.UI
{
    public class ProgressUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro progressText;
        [SerializeField] private Image progressBar;
        
        [SerializeField] private Transform handleRightPos;
        [SerializeField] private Transform handleLeftPos;
        [SerializeField] private Image progressHandle;
        
        public void ChangeProgressBar(float value)
        {
            
        }
    }
}
