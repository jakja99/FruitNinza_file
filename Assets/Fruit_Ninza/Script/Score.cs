using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public GameObject score;
    public GameObject highscore;
    public GameObject score_;
    public GameObject highscore_;
    public GameObject bonus;
    public int sc;
    private int hsc;
    public int bonus_score;
    string keyname = "Highscore";
    string Keyname_a = "Highscore_a";
    
    // Start is called before the first frame update 
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        sc = 0;
        bonus_score = 0;
        if (SceneManager.GetActiveScene().name == "Game")
        {
            hsc = PlayerPrefs.GetInt(keyname, 0);
        }
        else
        {
            hsc = PlayerPrefs.GetInt(Keyname_a, 0);
        }
        highscore.GetComponent<Text>().text = $"{hsc.ToString("0")}";
    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<Text>().text = sc.ToString("0");
        score_.GetComponent<Text>().text = sc.ToString("0");
        highscore_.GetComponent<Text>().text = $"{hsc.ToString("0")}";
        if (sc>hsc)
        {
            highscore.GetComponent<Text>().text = sc.ToString("0");
            if(GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
            {
                if (SceneManager.GetActiveScene().name == "Game")
                {
                    PlayerPrefs.SetInt(keyname, sc);
                    hsc = PlayerPrefs.GetInt(keyname, 0);
                }
                else
                {
                    PlayerPrefs.SetInt(Keyname_a, sc);
                    hsc = PlayerPrefs.GetInt(Keyname_a, 0);
                }
                
                highscore.GetComponent<Text>().text = $"{hsc.ToString("0")}";
            }
        }
        if(GameObject.Find("Mouse").GetComponent<MouseCursor>().bonus)
        {
            bonus.GetComponent<Text>().text = "+ " + bonus_score.ToString("0");
        }
    }
    public void AddScore()
    {
        if(bonus_score>0)
        {
            bonus_score--;
            sc++;
            bonus.GetComponent<Text>().text = "+ " + bonus_score.ToString("0");
            Invoke("AddScore", 0.1f);
        }
        else
        {
            bonus.SetActive(false);
        }
    }
    public void AddScore_gameover()
    {
        sc += bonus_score;
        bonus.GetComponent<Text>().text = "+ " + bonus_score.ToString("0");
        bonus.SetActive(false);
    }
}
