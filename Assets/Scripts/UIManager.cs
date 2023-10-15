using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text Timing;
    public int Lifes;
    public Image Life1, Life2, Life3, Life4, Life5, TimerImage;

    public Sprite GoodLife;
    public Sprite BadLife;
    private GameObject PlayerObj;
    private GameObject Time;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");

        Life1.sprite = GetComponent<Sprite>();
        Life2.sprite = GetComponent<Sprite>();
        Life3.sprite = GetComponent<Sprite>();
        Life4.sprite = GetComponent<Sprite>();
        Life5.sprite = GetComponent<Sprite>();

        Life1.sprite = GoodLife;
        Life2.sprite = GoodLife;
        Life3.sprite = GoodLife;
        Life4.sprite = GoodLife;
        Life5.sprite = GoodLife;

        Time = GameObject.Find("TimerObj");
    }

    // Update is called once per frame
    void Update()
    {
        Lifes = PlayerObj.GetComponent<Player>().Life;

        switch (Lifes)
        {
            case 5:
                Life5.sprite = GoodLife;
                Life4.sprite = GoodLife;
                Life3.sprite = GoodLife;
                Life2.sprite = GoodLife;
                Life1.sprite = GoodLife;
                break;

            case 4:
                Life5.sprite = BadLife;
                Life4.sprite = GoodLife;
                Life3.sprite = GoodLife;
                Life2.sprite = GoodLife;
                Life1.sprite = GoodLife;
                break;

            case 3:
                Life5.sprite = BadLife;
                Life4.sprite = BadLife;
                Life3.sprite = GoodLife;
                Life2.sprite = GoodLife;
                Life1.sprite = GoodLife;
                break;

            case 2:
                Life5.sprite = BadLife;
                Life4.sprite = BadLife;
                Life3.sprite = BadLife;
                Life2.sprite = GoodLife;
                Life1.sprite = GoodLife;
                break;

            case 1:
                Life5.sprite = BadLife;
                Life4.sprite = BadLife;
                Life3.sprite = BadLife;
                Life2.sprite = BadLife;
                Life1.sprite = GoodLife;
                break;

            case <= 0:
                Life1.sprite = BadLife;
                Life5.sprite = BadLife;
                Life4.sprite = BadLife;
                Life3.sprite = BadLife;
                Life2.sprite = BadLife;
                break;
        }

        Timing.text = string.Format("{0:00}   {1:00}", Time.GetComponent<Timer>().min, Time.GetComponent<Timer>().sec);
    }
}
