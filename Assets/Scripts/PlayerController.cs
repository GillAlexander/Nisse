using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody rb = null;
    private Vector3 fixedUpdatePos = Vector3.zero;
    private Vector3 updatePos = Vector3.zero;
    private bool hasInput = false;
    [SerializeField] private GameObject playerVisuals = null;

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
            rb.velocity = playerVisuals.transform.forward * movementSpeed;
            hasInput = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -playerVisuals.transform.right * movementSpeed;
            hasInput = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -playerVisuals.transform.forward * movementSpeed;
            hasInput = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = playerVisuals.transform.right * movementSpeed;
            hasInput = true;
        }

        if (hasInput)
        {
            if (Input.GetMouseButton(1))
            {
                playerVisuals.transform.forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
            }
            //rb.velocity = playerVisuals.transform.forward * movementSpeed;
        }
            
        //transform.forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);

        hasInput = false;
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
