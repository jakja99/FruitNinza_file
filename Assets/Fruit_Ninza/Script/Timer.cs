using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public GameObject timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 61f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Gameover").GetComponent<Gameover>().gameover&& !GameObject.Find("Mouse").GetComponent<MouseCursor>().icetime)
        {
            if (time > 0)
            {
                time -= Time.deltaTime / 2;
                timer.GetComponent<Text>().text = ((int)time / 60).ToString("0") + ":" + ((int)time % 60).ToString("00");
            }
            else
            {
                time = 0;
                timer.GetComponent<Text>().text = ((int)time / 60).ToString("0") + ":" + ((int)time % 60).ToString("00");
                GameObject.Find("Gameover").GetComponent<Gameover>().Gameover_();
            }
        }
    }
}
