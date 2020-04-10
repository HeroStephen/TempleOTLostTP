using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{

    private Vector3 startPos;
 
    void Start()
    {
        startPos = transform.position;
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}
