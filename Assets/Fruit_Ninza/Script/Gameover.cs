using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gameover : MonoBehaviour
{
    public bool gameover;
    public GameObject ui;
    public GameObject go;
    int count;
    int w;
    int h;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        count = 0;
        w = 0;
        h = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Gameover_()
    {
        gameover = true;
        go.transform.GetChild(1).gameObject.SetActive(true);
        Gameover_Txt();

    }
    void Gameover_Txt()
    {
        if (count < 30)
        {
            go.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta += new Vector2(40, 10);
            count++;
            Invoke("Gameover_Txt", 0.1f);
        }
        else
        {
            Invoke("Result", 2f);
        }
    }
    void Result()
    {
        go.transform.GetChild(1).gameObject.SetActive(false);
        ui.SetActive(false);
        go.transform.GetChild(0).gameObject.SetActive(true);
    }
}
