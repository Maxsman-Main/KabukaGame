using System;
using Level;
using UnityEngine;
using Zenject;

public class DamageProvider : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    
    private GameObject _player;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    
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
        _player.gameObject.transform.position = point.position;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
