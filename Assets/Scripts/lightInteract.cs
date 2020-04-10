/*
	This occurs when the player is near the fire. They press E to interact
	and turn it off to see the lit up path to get to the door.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightInteract : MonoBehaviour {

	public Text fireText;
	public GameObject P1,P2,P3,P4,P5,P6;
	public Material mat;

	void OnCollisionStay(Collision collisionInfo) {
		if(collisionInfo.gameObject.tag == "Player") {
			//instructions for interact
			fireText.gameObject.SetActive(true);
			//turns off
			if (Input.GetKey(KeyCode.E)) {
				this.gameObject.SetActive(false);
				fireText.gameObject.SetActive(false);

				//gross but can't think of a better way right now
				//activates lit up platforms
				P1.SetActive(true);
				P2.SetActive(true);
				P3.SetActive(true);
				P4.SetActive(true);
				P5.SetActive(true);
				P6.SetActive(true);
			}
		}
	}
}
