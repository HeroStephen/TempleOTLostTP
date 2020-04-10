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
/*

	for testing without model purposes!!


	void FixedUpdate()
    {
		//not part of my script
		//forward/backwards movement
		float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(0, -z, 0);

		//rotation for left/right movement
		if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
		}
        else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
		}
		//end not part of my script
    }
*/
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
