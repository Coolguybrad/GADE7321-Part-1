using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    //Camera
    [SerializeField] private Camera playerCam;
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float rotX = 0;
    //movement speeds
    [SerializeField] private bool canWalk = true;
    [SerializeField] private float walk = 5f;
    [SerializeField] private float sprint = 10f;
    //jump height
    [SerializeField] private float jump = 5f;

    Vector3 movementDirection = Vector3.zero;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveForward = transform.TransformDirection(Vector3.forward);
        Vector3 strafeRight = transform.TransformDirection(Vector3.right);
    }
}
