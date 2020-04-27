using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

    private GameObject pedestal;

    // Start is called before the first frame update
    void Start()
    {
        pedestal = GameObject.Find("Pedestal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pedestal.transform);
        transform.RotateAround(pedestal.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
