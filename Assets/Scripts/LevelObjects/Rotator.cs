using UnityEngine;

namespace LevelObjects
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Transform _transform;
    
        void Start()
        {
            _transform = gameObject.GetComponent<Transform>();
        }

        void Update()
        {
            _transform.Rotate(0, speed, 0);
        }
    }
}
