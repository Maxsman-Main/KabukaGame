using System;
using Level;
using UnityEngine;
using Zenject;

public class DamageProvider : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [Inject] private LevelController _levelController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health.Instance.GetDamage(amount);
            _levelController.TeleportPlayerOnPatternStart(FindObjectOfType<StartPoint>().transform);
        }
    }
}
