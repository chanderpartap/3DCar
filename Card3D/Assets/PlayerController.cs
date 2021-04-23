using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    public CharacterController controller;
    public float speed = 0.5f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1f;
            Debug.Log(speed);
        }
        else
        {
            speed = 0.5f;
            Debug.Log(speed);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * speed + transform.forward * z * speed;

        controller.Move(move);
    }
}
