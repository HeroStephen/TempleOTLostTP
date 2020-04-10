using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{

    private BlockButton yellowButton;
    private BlockButton redButton;
    private BlockButton blueButton;
    private MovableBlock yellowBlock;
    private MovableBlock redBlock;
    private MovableBlock blueBlock;
    private GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
        yellowButton = GameObject.Find("YellowButton").GetComponent<BlockButton>();
        redButton = GameObject.Find("RedButton").GetComponent<BlockButton>();
        blueButton = GameObject.Find("BlueButton").GetComponent<BlockButton>();
        yellowBlock = GameObject.Find("YellowBlock").GetComponent<MovableBlock>();
        redBlock = GameObject.Find("RedBlock").GetComponent<MovableBlock>();
        blueBlock = GameObject.Find("BlueBlock").GetComponent<MovableBlock>();
        exitDoor = GameObject.Find("ExitDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if(yellowButton.isActivated() && redButton.isActivated() && blueButton.isActivated())
        {
            Debug.Log("All good");
            exitDoor.SetActive(false);
        }

        //options to reset block positions
        if (Input.GetKey(KeyCode.R))
            redBlock.Reset();
        if (Input.GetKey(KeyCode.F))
            yellowBlock.Reset();
        if (Input.GetKey(KeyCode.V))
            blueBlock.Reset();


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
