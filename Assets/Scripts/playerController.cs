using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float mouseSensitivity = 2.0f;
    private Vector3 offset;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject ai;
    [SerializeField] private float attackRange;

    void Start()
    {
        offset = new Vector3(0, -1, -2);
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = cam.transform.rotation * movement;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

        
        cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    public void Attack() 
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, attackRange))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ai)
        {

        }
    }
}
