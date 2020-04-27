using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockButton : MonoBehaviour
{

    private bool activated = false;

    public bool isActivated() { return activated;  }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "YellowBlock" && gameObject.name == "YellowButton")
        {
            activated = true;
            Debug.Log("yellow pressed");
        }
        else if (collision.gameObject.name == "RedBlock" && gameObject.name == "RedButton")
        {
            activated = true;
            Debug.Log("red pressed");
        }
        else if (collision.gameObject.name == "BlueBlock" && gameObject.name == "BlueButton")
        {
            activated = true;
            Debug.Log("blue pressed");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            activated = false;
        }
    }
}
