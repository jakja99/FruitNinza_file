using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject fruit;
    public GameObject start;
    public GameObject fruita;
    public GameObject arcade;
    public GameObject fruitq;
    public GameObject quit;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        fruit.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
        start.transform.Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        fruita.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
        arcade.transform.Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        fruitq.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
        quit.transform.Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
    }
}
