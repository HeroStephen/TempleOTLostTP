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

    //Called by player to update blocks position if it can move to that space
    public void Push(Vector3 direction)
    {
        RaycastHit hit;

        //ensure the block is not pushed into another object
        if(Physics.SphereCast(transform.position, 0.5f, direction, out hit, 2))
        {
            return;
        }
        else
            transform.position += direction;
    }
}
