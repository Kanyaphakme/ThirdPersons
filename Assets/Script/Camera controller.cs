using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [SerializeField] private float mouseSensitity = 3.0f;

    private float rotationX;
    private float rotationY;

    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3.0f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField] private float smootnTime = 0.2f;
    [SerializeField] private Vector3 rotationXMinMAx = new Vector2(-20, 40);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitity;

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, rotationXMinMAx.x, rotationXMinMAx.y);

        Vector3 nextRotation = new Vector3 (rotationY, rotationX);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smootnTime);
        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
