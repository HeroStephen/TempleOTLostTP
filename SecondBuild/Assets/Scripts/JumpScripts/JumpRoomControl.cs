using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpRoomControl : MonoBehaviour
{

    public void ExitStage()
    {
        Debug.Log("Exit stage");
        SceneManager.LoadScene("MenuScene");
    }


}
