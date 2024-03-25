using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private bool canAttack = true;

    [SerializeField] private Image crosshair;

    void Start()
    {

        Time.timeScale = 1;
        offset = new Vector3(0, -1, -2);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }

    }

    IEnumerator Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, attackRange))
        {
            Debug.Log(hit.transform.gameObject);
            if (hit.transform.CompareTag("AI"))
            {
                
                hit.transform.GetComponent<CharacterStats>().Respawn(hit.transform.gameObject);
            }
            else
            {
                ParticleSystem particleSystem = Instantiate(particles, hit.transform.position, Quaternion.identity);
                particleSystem.Play();
                Destroy(particleSystem.gameObject, 2f);
            }
        }
        canAttack = false;
        StartCoroutine(blinkCrosshair());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator blinkCrosshair() 
    {
        while (!canAttack)
        {
            crosshair.enabled = !crosshair.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        crosshair.enabled = true;
    }

    //public void Attack()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, attackRange))
    //    {
    //        Debug.Log(hit.transform.gameObject);
    //        if (hit.transform.CompareTag("AI"))
    //        {

    //            hit.transform.GetComponent<CharacterStats>().Respawn(hit.transform.gameObject);
    //        }
    //        else
    //        {
    //            ParticleSystem particleSystem = Instantiate(particles, hit.transform.position, Quaternion.identity);
    //            particleSystem.Play();
    //            Destroy(particleSystem.gameObject, 2f);
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ai)
        {
            collision.transform.GetComponent<CharacterStats>().Respawn(this.transform.gameObject);
        }
    }
}
