using UnityEngine;

public class SawRotator : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, -1, 0));       
    }
}
