using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject menuPanel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            menuPanel.SetActive(!menuPanel.activeInHierarchy);


        }
        
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Restart()
    {

        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);

    }

    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void HowToPlay()
    {
        menuPanel.SetActive(true);
    }

    public void Back()
    {

        menuPanel.SetActive(false);
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
}
