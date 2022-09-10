using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public GameObject[] life;
    public int currentlife;
    // Start is called before the first frame update
    void Start()
    {
        currentlife = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
        {
            if (currentlife < 1)
            {
                GameObject.Find("Gameover").GetComponent<Gameover>().Gameover_();
                for (int i = 0; i < 3; i++)
                {
                    life[currentlife].GetComponent<Image>().color = Color.red;
                }
            }
            else
            {
                for (int i = currentlife; i < 3; i++)
                {
                    life[currentlife].GetComponent<Image>().color = Color.red;
                }
            }
            
        }
        

          
    }
}
