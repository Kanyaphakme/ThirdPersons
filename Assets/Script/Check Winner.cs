using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour

{
    public static CheckWinner instance;
    public Transform playerRotation;
    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothSpeed = 1.0f;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultCamera.enabled = true;
        winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (target != null && isWinner) 
        {
            Vector3 desiredPositiom = new Vector3(target.position.x,target.position.y,target.position.z+2.2f);
            Vector3 smoothedPosition = Vector3.Lerp(winnerCamera.transform.position, desiredPositiom, smoothSpeed * Time.deltaTime);
            winnerCamera.transform.position = smoothedPosition;
        }

        playerRotation.LookAt(new Vector3(playerRotation.position.x, playerRotation.position.y, winnerCamera.transform.position.z));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Playercontroller.instance.groundedPlayer)
        {
            isWinner = true;
        }
    }
}
