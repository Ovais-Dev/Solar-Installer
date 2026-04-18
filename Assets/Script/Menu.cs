using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuPanel;

    void Start()
    {
        float width = Screen.currentResolution.width;
        float height = (9f / 16) * width;
        Screen.SetResolution((int)width, (int)height,true);
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            menuPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Play()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
