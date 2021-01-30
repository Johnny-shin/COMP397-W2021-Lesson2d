using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public CharacterController controller;
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;  //default -30.0f
    public float jumpHeight = 3.0f;
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velovity;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // velovity.y = -2.0f;
    }

    // Update is called once per frame - once every 16.6666ms
    // 1000ms for each second
    // approximately updates 60 times per second = 60fps
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded && velovity.y < 0)
        {
            velovity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velovity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velovity.y += gravity * Time.deltaTime;

        controller.Move(velovity * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

}//end of class




