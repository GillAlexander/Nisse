using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody rb = null;
    private Vector3 fixedUpdatePos = Vector3.zero;
    private Vector3 updatePos = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        updatePos = Input.mousePosition;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            Mathf.Lerp(rb.velocity.magnitude, 0, Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = this.transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -this.transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -this.transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = this.transform.right * movementSpeed;
        }

        transform.forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);

        //if (Input.GetMouseButton(1))
        //{
        //    var calc = updatePos - fixedUpdatePos;
        //    var direction = new Vector3(0, calc.x, calc.z);
        //    direction.Normalize();
        //    direction /= 4;
        //    transform.localRotation *= Quaternion.Euler(direction);
        //}
    }

    private void FixedUpdate()
    {
        fixedUpdatePos = Input.mousePosition;
    }
}
