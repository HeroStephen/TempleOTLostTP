/*
	Aleene Dupuy

	Movement controller for player. Move with wsad. Jump with space. Collision
	functions check if the player is on the floor, which allows them to jump.
	Also checks if they have finished the level, fallen off a platform, or
	have stepped on a fake platform.
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

	private bool isGrounded = true;
	private Rigidbody rb;
	private Animator anim;

	private JumpRoomControl roomControl;

    // Start is called before the first frame update
    void Start() {
		rb = GetComponent<Rigidbody>();
		anim = gameObject.GetComponent<Animator>();

		roomControl = GameObject.Find("RoomControl").GetComponent<JumpRoomControl>();
    }


	void FixedUpdate() {
		//forward/back movement
		if (Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		else if (Input.GetKey(KeyCode.S)) {
			transform.position += -transform.forward * Time.deltaTime * speed;
		}

		//left/right turn
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(0.0f, Time.deltaTime * -turnSpeed, 0.0f);
		}
		else if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(0.0f, Time.deltaTime * turnSpeed, 0.0f);
		}

		//determines if player can jump
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("RunJumpFlip")) {
				/* Wasn't sure the best way to do this, but this stops the
				   player from interrupting the jump animation.
				*/
			}
			//jumps and plays animation
			else {
				rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				isGrounded = false;
				anim.Play("RunJumpFlip");
			}
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		//checks fake floor and does not allow jumping from it
		if(collisionInfo.gameObject.tag == "Fake") {
			collisionInfo.gameObject.SetActive(false);
			isGrounded = false;
		}

		//reset
		if(collisionInfo.gameObject.tag == "Reset") {
			player.transform.position = spawn.transform.position;
			rb.velocity = Vector3.zero;
		}

	}

	void OnCollisionEnter(Collision collision) {
		//checks if on floor
		if(collision.gameObject.tag == "Floor") {
			isGrounded = true;
		}
		//exits when player is at end
		if(collision.gameObject.tag == "Exit") {
			roomControl.ExitStage();
		}
	}

	//called by animations to play the audio clip
	private void Step()
	{
		GetComponent<AudioSource>().Play();
	}
}
