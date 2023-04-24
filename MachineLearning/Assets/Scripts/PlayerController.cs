using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float acceleration;

    public void updateInput(float leftRight)
    {
        rb.AddForce((Vector3.right * leftRight) * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddForce(0, 0, acceleration, ForceMode.Acceleration);
    }

}
