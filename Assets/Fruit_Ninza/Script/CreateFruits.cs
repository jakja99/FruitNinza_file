using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreateFruits : MonoBehaviour
{
    public GameObject[] fruits;                     //°úÀÏ ¹è¿­ + ÆøÅº Æ÷ÇÔ
    GameObject sound;
    bool create;
    int type = 0;
    float createspeed;
    int count;
    GameObject f;
    int fever;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        fever = 0;
        create = true;
        createspeed = 0.5f;
        Time.timeScale = 2f;
        sound = GameObject.Find("SoundDirector");
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
        {
            if (GameObject.FindGameObjectsWithTag("Fruits").Length == 0 && create)
            {
                type = Random.Range(0, 3);
                if (type == 0)
                {
                    CreateFruitRow();
                    create = false;
                }
                else
                {
                    CreateFruitSeveral();
                    create = false;
                }

            }
        }
    }
    void CreateFruitRow()
    {
        if(count<5)
        {
            int i;
            int j;
            if(SceneManager.GetActiveScene().name=="Arcade")
            {
                j = Random.Range(0, 3);
                if (j == 0)
                {
                    //i = Random.Range(7, 10);
                    i = 10;
                }
                else
                {
                    i = 7;
                }
            }
            else
            {
                i = 7;
            }
            count++;
            f = Instantiate(fruits[Random.Range(0, i)], new Vector3(Random.Range(-4, 5), -15, 5), Quaternion.identity);
            f.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), Random.Range(18, 25), 0);
            f.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.value, Random.value, Random.value);
            Invoke("CreateFruitRow", createspeed);
            if (!GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
            {
                sound.GetComponent<Sound>().ThrowSound();
            }
        }
        else
        {
            Invoke("CreateCheck", 3*Time.timeScale);
            count = 0;
        }
    }
    void CreateFruitSeveral()
    {
        for(int i =0;i<5;i++)
        {
            int j;
            int k;
            if (SceneManager.GetActiveScene().name == "Arcade")
            {
                k = Random.Range(0, 2);
                if (k == 0)
                {
                    if (GameObject.Find("Mouse").GetComponent<MouseCursor>().icetime)
                    {
                        j = 8;
                    }
                    else
                    {
                        j = 9;
                    }
                }
                else
                {
                    j = 7;
                }
            }
            else
            {
                j = 7;
            }
            int x = Random.Range(0, 3);
            if(x!=0)
            {
                f = Instantiate(fruits[Random.Range(0, j)], new Vector3(Random.Range(-5, 6), -15, 5), Quaternion.identity);
                f.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 5), Random.Range(15, 20), 0);
                f.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.value, Random.value);   
            }
        }
        sound.GetComponent<Sound>().ThrowSound();
        Invoke("CreateCheck", 3 * Time.timeScale);
    }
    void CreateCheck()
    {
        create = true;
    }
    public void FeverTime()
    {
        if (fever < 20)
        {
            int i;
            i = Random.Range(0, 2);
            if (i == 0)
            {
                f = Instantiate(fruits[Random.Range(0, 6)], new Vector3(-20, 0, 5), Quaternion.identity);
                f.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(5, 10), Random.Range(7, 10), 0);
                f.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.value, Random.value);
            }
            else
            {
                f = Instantiate(fruits[Random.Range(0, 6)], new Vector3(20, 0, 5), Quaternion.identity);
                f.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, -5), Random.Range(7, 10), 0);
                f.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.value, Random.value);
            }
            fever++;
            Invoke("FeverTime", 0.3f);
        }
        else
        {
            fever = 0;
        }
    }
}
