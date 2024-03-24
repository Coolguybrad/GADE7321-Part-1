using UnityEngine;
using TMPro;
using System.Collections;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool playerCapable = false;
    [SerializeField] private Transform flagRespawnLocation;
    [SerializeField] private TMP_Text captureText;
    
    public Transform FlagRespawnLocation
    {
        get { return flagRespawnLocation; }
        set { flagRespawnLocation = value; }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator HideText(float time)
    {
        yield return new WaitForSeconds(time);
        captureText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "AI")
        {
            if (playerCapable)
            {
                if (other.tag == "Player")
                {
                    other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
                    captureText.color = Color.blue;
                    captureText.text = "BLUE HAS TAKEN A FLAG";
                }
                else if (other.tag == "AI")
                {
                    captureText.color = Color.red;
                    this.gameObject.transform.position = FlagRespawnLocation.position;
                    captureText.text = "RED HAS RETURNED A FLAG";
                }

            }

            else if (!playerCapable)
            {
                
                if (other.tag == "Player")
                {
                    captureText.color = Color.blue;
                    this.gameObject.transform.position = FlagRespawnLocation.position;
                    captureText.text = "BLUE HAS RETURNED A FLAG";

                }
                else if (other.tag == "AI")
                {
                    captureText.color = Color.red;
                    other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
                    captureText.text = "RED HAS TAKEN A FLAG";
                }

            }
            StartCoroutine(HideText(2f));
        }




        Debug.Log("Collision");
    }

}
