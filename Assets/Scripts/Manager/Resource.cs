using System;
using UnityEngine;
using Zenject;
public class Resource : MonoBehaviour
{
    [Inject] private ResourceManager resourceManager;
    [SerializeField] int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        //ResourceManager resourceManager = other.GetComponent<ResourceManager>();
        if (other.CompareTag("Player"))
        {
            ResourceManager.Instance.AddResource(amount);
            Destroy(gameObject);
        }
    }
}