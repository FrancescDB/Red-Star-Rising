using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int min, sec;
    public float TimePassed;
    public GameObject TextObj;
    public GameObject ExplosionObj;
    public GameObject CanvasObj;

    private GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        TimePassed = 300f;

        PlayerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (TimePassed <= 0)
        {
            StartCoroutine(Destruction());
        }

        if (TimePassed > 0)
        {
            TimePassed = TimePassed - Time.deltaTime;

            min = (int)(TimePassed / 60f);

            if (TimePassed < 60)
            {
                sec = (int)(TimePassed);
            }

            if (TimePassed >= 60)
            {
                sec = (int)(TimePassed - min * 60);
            }
        }
    }

    IEnumerator Destruction()
    {
        CanvasObj.SetActive(false);
        ExplosionObj.GetComponent<Animator>().SetBool("White", true);

        yield return new WaitForSeconds(0.5f);

        PlayerObj.GetComponent<Player>().Life = 0;
    }
}
