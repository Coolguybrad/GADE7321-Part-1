using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool holdingFlag = false;
    [SerializeField] private int score = 0;
    [SerializeField] private Transform respawn;
    [SerializeField] private GameObject designatedFlag;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ai;

    public bool HoldingFlag
    {
        get { return holdingFlag; }
        set { holdingFlag = value; }
    }
    public bool IsPlayer
    {
        get { return isPlayer; }
        set { isPlayer = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Respawn(ai);
        }
    }

    public void Respawn(GameObject respawnee)
    {
        Debug.Log("respawn");

        if (respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag)
        {

            //respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag = false;
            designatedFlag.transform.position = new Vector3(respawnee.transform.position.x, respawnee.transform.position.y - 0.7f, respawnee.transform.position.z);

        }
        respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag = false;
        respawnee.gameObject.transform.position = respawnee.gameObject.GetComponent<CharacterStats>().respawn.position;

    }

}
