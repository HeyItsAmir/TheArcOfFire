using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IsPause()
    {
        if (Time.timeScale > 0f)
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);

        }
        //else if (Time.timeScale < 1f)
        //{
        //    Time.timeScale = 1f;
        //    pauseUI.SetActive(false);
        //}
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
    public void MainMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }
}
