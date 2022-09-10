using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y<-16)
        {
            Destroy(this.gameObject);
        }
    }
}
