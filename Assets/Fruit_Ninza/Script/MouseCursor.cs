using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MouseCursor : MonoBehaviour
{
    // 카메라로부터의 거리
    public float distanceCamera = 5f;
    public float moveSpeed = 1f;
    public GameObject[] effects;
    GameObject sound;
    private Vector3 mousePos;
    private Vector3 nextPos;
    public GameObject flash;
    public GameObject ice;
    public bool icetime;
    public bool bonus;
    float flashcount = 10;
    private void Start()
    {
        sound = GameObject.Find("SoundDirector");
        icetime = false;
        bonus = false;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (distanceCamera < 0f)
            distanceCamera = 0f;
        mousePos = Input.mousePosition;
        mousePos.z = distanceCamera;

        nextPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector3.Lerp(transform.position, nextPos, moveSpeed);
        if(bonus)
        {
            if(GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
            {
                bonus = false;
                GameObject.Find("ScoreDirector").GetComponent<Score>().AddScore_gameover();
            }
        }
        if (Input.GetMouseButton(0))
        {
            this.GetComponent<TrailRenderer>().enabled = true;
            if (!GameObject.Find("Gameover").GetComponent<Gameover>().gameover)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Fruits"))
                    {
                        if(bonus)
                        {
                            GameObject.Find("ScoreDirector").GetComponent<Score>().bonus_score++;
                        }
                        hit.transform.gameObject.tag = "Untagged";
                        sound.GetComponent<Sound>().SliceSound();
                        GameObject.Find("ScoreDirector").GetComponent<Score>().sc++;
                        if (SceneManager.GetActiveScene().name == "Arcade")
                        {
                           if(hit.transform.GetChild(0).gameObject.name =="Fever")
                            {
                                GameObject.Find("CreateFruits").GetComponent<CreateFruits>().FeverTime();
                            }
                           if(hit.transform.GetChild(0).gameObject.name == "Ice")
                            {
                                if (!icetime)
                                {
                                    icetime = true;
                                    ice.SetActive(true);
                                    StartCoroutine(IceTimeEnd(ice));
                                }                    
                            }
                            if (hit.transform.GetChild(0).gameObject.name == "Bonus")
                            {
                                if (!bonus)
                                {
                                    bonus = true;
                                    GameObject.Find("ScoreDirector").GetComponent<Score>().bonus.SetActive(true);
                                    Invoke("EndBonus", 20f);
                                }
                            }
                        }
                        
                        switch (hit.transform.GetChild(0).gameObject.name)
                        {
                            case "Coconut":
                                StartCoroutine(EffectDelete(Instantiate(effects[0], hit.transform.position, Quaternion.identity)));
                                break;
                            case "Apple_Green":
                                StartCoroutine(EffectDelete(Instantiate(effects[1], hit.transform.position, Quaternion.identity)));
                                break;
                            case "Apple_Red":
                                StartCoroutine(EffectDelete(Instantiate(effects[2], hit.transform.position, Quaternion.identity)));
                                break;
                            case "Lemon":
                                StartCoroutine(EffectDelete(Instantiate(effects[3], hit.transform.position, Quaternion.identity)));
                                break;
                            case "Orange":
                                StartCoroutine(EffectDelete(Instantiate(effects[4], hit.transform.position, Quaternion.identity)));
                                break;
                            case "Watermelon":
                                StartCoroutine(EffectDelete(Instantiate(effects[5], hit.transform.position, Quaternion.identity)));
                                break;
                        }
                        hit.transform.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                        hit.transform.GetChild(0).gameObject.SetActive(false);
                        hit.transform.GetChild(1).gameObject.SetActive(true);
                        hit.transform.GetChild(2).gameObject.SetActive(true);
                        hit.transform.GetChild(3).gameObject.SetActive(true);
                        if (hit.transform.GetChild(1).position.x < hit.transform.GetChild(2).position.x)
                        {
                            hit.transform.GetChild(1).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 0), Random.Range(0, 5), 0);
                            hit.transform.GetChild(2).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0);
                        }
                        else
                        {
                            hit.transform.GetChild(2).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 0), Random.Range(0, 5), 0);
                            hit.transform.GetChild(1).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0);
                        }
                        hit.transform.GetChild(1).GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.Range(0, 5), Random.Range(0, 5));
                        hit.transform.GetChild(2).GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.Range(0, 5), Random.Range(0, 5));
                    }
                    else if (hit.transform.CompareTag("Bomb") && hit.transform.GetComponent<Bomb>().check)
                    {
                        if (SceneManager.GetActiveScene().name == "Game")
                        {
                            hit.transform.GetChild(1).gameObject.SetActive(true);
                            Time.timeScale = 0.1f;
                            Invoke("TimeController", 0.3f);
                            hit.transform.GetComponent<Bomb>().check = false;
                            GameObject.Find("Gameover").GetComponent<Gameover>().gameover = true;
                        }
                        else
                        {
                            TimeController();
                            GameObject.Find("TimerDirector").GetComponent<Timer>().time -= 5;
                            hit.transform.GetComponent<Bomb>().check = false;
                        }
                    }
                }
            }
        }
        else
        {
            this.GetComponent<TrailRenderer>().enabled = false;
        }
        
    }
    void TimeController()
    {
        
        Time.timeScale = 2f;
        icetime = false;
        Flash();
        sound.GetComponent<Sound>().BombSound();
    }
    void Flash()
    {
        flash.SetActive(true);
        Color c = flash.GetComponent<Image>().color;
        c.a = --flashcount / 10;
        flash.GetComponent<Image>().color = c;

        if(flashcount>=0)
        {
            Invoke("Flash", 0.2f);
        }
        else
        {
            flash.SetActive(false);
            flashcount = 10;
            if (SceneManager.GetActiveScene().name == "Game")
            {
                GameObject.Find("Gameover").GetComponent<Gameover>().Gameover_();
            }
        }
    }
    void EndBonus()
    {
        if (bonus)
        {
            bonus = false;
            GameObject.Find("ScoreDirector").GetComponent<Score>().AddScore();
        }
    }
    IEnumerator IceTimeEnd(GameObject effect)
    {
        Color c;
        Color c_;
        c_ = effect.GetComponent<Image>().color;
        yield return new WaitForSeconds(5f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            c = effect.GetComponent<Image>().color;
            c.a -= 0.01f;
            effect.GetComponent<Image>().color = c;
            if (c.a <= 0||!icetime)
            {
                icetime = false;
                effect.GetComponent<Image>().color = c_;
                effect.SetActive(false);
                break;
            }
        }
    }
    IEnumerator EffectDelete(GameObject effect)
    {
        Color c;
        yield return new WaitForSeconds(4f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);    
            c = effect.GetComponent<SpriteRenderer>().color;
            c.a -= 0.01f;
            effect.GetComponent<SpriteRenderer>().color = c;
            if(c.a <=0)
            {
                Destroy(effect);
                break;
            }
        }
    }
}
