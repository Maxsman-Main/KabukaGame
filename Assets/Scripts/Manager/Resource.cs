using System;
using UnityEngine;
using Zenject;
public class Resource : MonoBehaviour
{
    [SerializeField] int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager.Instance.AddResource(amount);
            Destroy(gameObject);
        }
    }
}