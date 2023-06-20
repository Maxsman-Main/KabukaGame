using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float speed;
    
    private int _currentPoint = 0;

    void Update()
    {
        if (_currentPoint >= points.Count)
        {
            _currentPoint = 0;
        }
        
        
        if(Vector2.Distance(gameObject.transform.position, points[_currentPoint].transform.position) > 0.2f) 
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, 
                points[_currentPoint ].transform.position, speed * Time.deltaTime);
        }
        else
        {
            _currentPoint += 1;
        }
    }
}
