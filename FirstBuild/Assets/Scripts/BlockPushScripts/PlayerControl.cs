using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 1;
    private float rotationSpeed = 150.0f;

    private bool againstBlock = false;
    private GameObject objectTouching;

    private float pushDist = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //---------------------Movement control-------------------//
        //forward and back movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }
        
        //left and right turning
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed * -1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
        }


        //-----------------------Pushing control------------------------//
        if (againstBlock)
        {
            //when the player presses space, they will trigger the push animation and push the block
            // in the cardinal direciton the player is facing.
            if (Input.GetKey(KeyCode.Space))
            {

                Vector3 pushVect = Vector3.zero;
                
                //check which direction the object should move based on side pushed from
              
                //either forward or right
                if(transform.forward.x > 0 && transform.forward.z > 0)
                {
                    //push forward
                    if (Mathf.Abs(transform.forward.x) < Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3 (0.0f, 0.0f, pushDist);
                    //push right
                    else if(Mathf.Abs(transform.forward.x) < Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(pushDist, 0.0f, 0.0f);
                }
                //either right or down
                else if(transform.forward.x > 0 && transform.forward.z < 0)
                {
                    //push right
                    if (Mathf.Abs(transform.forward.x) > Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(pushDist, 0.0f, 0.0f);
                    //push down
                    else if (Mathf.Abs(transform.forward.x) < Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(0.0f, 0.0f, pushDist * -1);
                }
                //either down or left
                else if(transform.forward.x < 0 && transform.forward.z < 0)
                {
                    //push down
                    if (Mathf.Abs(transform.forward.x) < Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(0.0f, 0.0f, pushDist * -1);
                    //push left
                    else if (Mathf.Abs(transform.forward.x) > Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(pushDist * -1, 0.0f, 0.0f);
                }
                //either left or forward
                else if(transform.forward.x < 0 && transform.forward.z > 0)
                {
                    //push left
                    if (Mathf.Abs(transform.forward.x) > Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(pushDist * -1, 0.0f, 0.0f);
                    //push forward
                    else if (Mathf.Abs(transform.forward.x) < Mathf.Abs(transform.forward.z))
                        pushVect = new Vector3(0.0f, 0.0f, pushDist);
                }

                //Update the objects position based on direction of push
                objectTouching.transform.position += pushVect;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Movable")
        {
            againstBlock = true;
            objectTouching = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Movable")
        {
            againstBlock = false;
        }
    }
}
