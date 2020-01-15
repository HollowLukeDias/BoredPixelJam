using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    private bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause(panel);
            } else if (isPaused)
            {
                Unpause(panel);
            }   
        }
    }
    
    public void StartGame(string sceneName)
    {
        FindObjectOfType<Fader>().FadeTo(sceneName);
    }

    public void OptionsMenu()
    {
        //TODO: Make another canvas with the sound options and credits
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause(GameObject panel)
    {
        isPaused = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void Unpause(GameObject panel)
    {
        isPaused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
