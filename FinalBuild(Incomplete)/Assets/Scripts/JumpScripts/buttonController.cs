/*
	Aleene Dupuy
	
	Turns lights on to show correct path when player activates button
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
	public GameObject P1,P2,P3,P4,P5,P6,P7;

	void OnCollisionStay(Collision collisionInfo) {
		if(collisionInfo.gameObject.tag == "Player") {
			//turns on correct path. didn't know a better way to go about this
			P1.SetActive(true);
			P2.SetActive(true);
			P3.SetActive(true);
			P4.SetActive(true);
			P5.SetActive(true);
			P6.SetActive(true);
			P7.SetActive(true);
		}
	}
}
