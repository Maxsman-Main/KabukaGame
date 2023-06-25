using UnityEngine;

namespace CameraTracking
{
    public class PlayerCameraTracker : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float maxDistance;

        private Transform _transform;
        
        private void Start()
        {
            _transform = gameObject.GetComponent<Transform>();
        }

        private void Update()
        {
            if ((_transform.position - player.transform.position).x >= maxDistance)
            {
                var position = player.transform.position;
                _transform.position = new Vector3(position.x, position.y, _transform.position.z);
            }

            if ((_transform.position - player.transform.position).y >= maxDistance)
            {
                var position = player.transform.position;
                _transform.position = new Vector3(position.x, position.y, _transform.position.z);
            }
        }
    }
}