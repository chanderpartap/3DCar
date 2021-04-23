using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    public CharacterController controller;
    public float speed = 10f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
            //Debug.Log(speed);
        }
        else
        {
            speed = 10f;
            //Debug.Log(speed);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z ;

        controller.Move(move * speed * Time.deltaTime);
    }
}
