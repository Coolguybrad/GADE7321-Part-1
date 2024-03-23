using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool playerCapable = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (playerCapable && other.gameObject.GetComponent<CharacterStats>().IsPlayer)
        {
            other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-1000, this.gameObject.transform.position.z);
        }

        else if (!playerCapable && !other.gameObject.GetComponent<CharacterStats>().IsPlayer)
        {
            other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
            Debug.Log("Bot Collision");
        }

        Debug.Log("Collision");

    }
}
