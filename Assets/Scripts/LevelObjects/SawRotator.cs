using UnityEngine;
using Zenject;

public class SawRotator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health.Instance.GetDamage(1);
        }
    }
    
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, -1, 0));       
    }
}
