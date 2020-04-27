using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpRoomControl : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitStage();
        }
    }

    public void ExitStage()
    {
        Debug.Log("Exit stage");
        SceneManager.LoadScene("MenuScene");
    }


}
