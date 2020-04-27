using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour
{
    private BlockButton yellowButton;
    private BlockButton redButton;
    private BlockButton blueButton;

    void Start()
    {
        yellowButton = GameObject.Find("YellowButton").GetComponent<BlockButton>();
        redButton = GameObject.Find("RedButton").GetComponent<BlockButton>();
        blueButton = GameObject.Find("BlueButton").GetComponent<BlockButton>();
    }

    private void Update()
    {
        //disable wall if corresponding button is active
        if(yellowButton.isActivated() && gameObject.name == "YellowWall")
            gameObject.SetActive(false);

        else if(redButton.isActivated() && gameObject.name == "RedWall")
            gameObject.SetActive(false);

        else if(blueButton.isActivated() && gameObject.name == "BlueWall")
            gameObject.SetActive(false);
        
        else
            gameObject.SetActive(true);
    }
}
