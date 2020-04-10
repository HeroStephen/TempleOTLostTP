/*
	Opens door when button is stepped on
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
	public GameObject door;

	void OnCollisionStay(Collision collisionInfo) {
		if(collisionInfo.gameObject.tag == "Player") {
			door.SetActive(false);
		}
	}
}
