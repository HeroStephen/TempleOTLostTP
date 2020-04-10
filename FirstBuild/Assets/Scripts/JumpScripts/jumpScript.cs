/*
	Wonky physics based jump function.
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{

	public float speed;
	public float turnSpeed;
	public float jumpForce;
	public GameObject spawn, player;
	public int allowedJumps = 1;

	private bool isGrounded = true;
	private Rigidbody rb;
	private Vector3 jump;
	private int numJumps = 0;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.5f, 0.0f);
    }


	void FixedUpdate()
	{ 
		//---------------------Movement control-------------------//
		//forward and back movement
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.back * Time.deltaTime * speed;
		}

		//left and right turning
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, Time.deltaTime * turnSpeed * -1, 0);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
		}
	}

	void Update() {
		//makes jump
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
			if(numJumps < allowedJumps) {
				isGrounded = false;
				rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				numJumps = 1;
			}
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		//checks if on ground
		if(collisionInfo.gameObject.tag == "Floor") {
			isGrounded = true;
			numJumps = 0;
		}

		//checks fake floor and does not allow jumping from it
		if(collisionInfo.gameObject.tag == "Fake") {
			collisionInfo.gameObject.SetActive(false);
			isGrounded = false;
		}

		//reset
		if(collisionInfo.gameObject.tag == "HeDed") {
			player.transform.position = spawn.transform.position;
			rb.velocity = Vector3.zero;
		}

	}


}
