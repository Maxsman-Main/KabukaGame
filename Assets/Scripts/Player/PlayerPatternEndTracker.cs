using System;
using Level;
using UnityEngine;

namespace Player
{
    public class PlayerPatternEndTracker : MonoBehaviour
    {
        public Action OnEndPattern;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EndPoint endPoint))
            {
                OnEndPattern?.Invoke();
            }
        }
    }
}