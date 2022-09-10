using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Director : MonoBehaviour
{
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 2f;
    }
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Main()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void Arcade()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
