using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource a;
    public AudioClip throwsound;
    public AudioClip slice;
    public AudioClip bomb;
    public AudioClip ice;
    // Start is called before the first frame update
    void Start()
    {
        a = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BombSound()
    {
        a.PlayOneShot(bomb,0.7f);
    }
    public void SliceSound()
    {
        a.PlayOneShot(slice, 0.7f);
    }
    public void ThrowSound()
    {
        a.PlayOneShot(throwsound, 0.7f);
    }
    public void IceSound()
    {
        a.PlayOneShot(ice, 0.7f);
    }
}
