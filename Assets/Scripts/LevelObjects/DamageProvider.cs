using Level;
using UnityEngine;
using Zenject;

public class DamageProvider : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health.Instance.GetDamage(amount);
            TeleportPlayerOnPatternStart(FindObjectOfType<StartPoint>().transform);
        }
    }

    private void TeleportPlayerOnPatternStart(Transform point)
    {
        var player = GameObject.FindWithTag("Player");
        player.gameObject.transform.position = point.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
