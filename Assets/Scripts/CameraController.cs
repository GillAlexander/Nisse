using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform rotateAround = null;
    [SerializeField] private float xMultiplier = 1;
    [SerializeField] private float yMultiplier = 1;
    //[SerializeField] private Vector3 offset = Vector3.zero;
    private Camera mainCamera = null;
    private float xDegree = 0;
    private float yDegree = 0;
    private float zOffset = 0;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            xDegree = Input.GetAxis("Mouse X") * xMultiplier;
            yDegree += Input.GetAxis("Mouse Y") * yMultiplier;
            //mainCamera.transform.localRotation = Quaternion.Euler(yDegree, -mainCamera.transform.localRotation.x, 0);
            transform.RotateAround(rotateAround.position, Vector3.up, xDegree);
        }
        var offset = new Vector3(rotateAround.position.x, transform.position.y, rotateAround.position.z);
        transform.position = offset;

        zOffset = Input.GetAxis("Mouse ScrollWheel");
        if (zOffset != 0)
        {

        }
    }
}