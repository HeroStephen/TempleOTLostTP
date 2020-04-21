using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float cameraMoveSpeed = 1;
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = player.transform.position - offset;
      //  transform.LookAt(player.transform);
    }
}
