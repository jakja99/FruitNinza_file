using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fruit : MonoBehaviour
{
    public AudioSource slice;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.GetChild(1).position.y<-15&& this.transform.GetChild(2).position.y < -15)
        {
            if(this.transform.GetChild(0).transform.gameObject.activeSelf ==true)
            {
                if (SceneManager.GetActiveScene().name == "Game")
                {
                    GameObject.Find("LifeDirector").GetComponent<Life>().currentlife -= 1;
                }

            }
            Destroy(this.gameObject);
        }
    }
}
