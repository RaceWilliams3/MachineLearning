using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    
    public void UpdatePosition()
    {
        transform.position = startPos;
        transform.position += new Vector3(Random.Range(-3f, 3), startPos.y, startPos.y);
    }
}
