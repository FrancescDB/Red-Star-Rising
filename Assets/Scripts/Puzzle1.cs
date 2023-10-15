using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{
    public bool Win;
    public Image FirstCube, SecondCube, ThirdCube;
    public Sprite Cube1Off;
    public Sprite Cube2Off;
    public Sprite Cube3Off;
    public Sprite Cube1On;
    public Sprite Cube2On;
    public Sprite Cube3On;

    private int P1;
    private int P2;
    private int P3;
    private int Solution;
    private int CubeNum;
    private float Speed;
    private bool Timer;
    private GameObject PlayerObj;
    private GameObject ActiveObj;
    private GameObject Cube1;
    private GameObject Cube2;
    private GameObject Cube3;

    // Start is called before the first frame update
    void Start()
    {
        Win = false;

        CubeNum = 1;
        Speed = 200f;
        Timer = true;

        PlayerObj = GameObject.Find("Player");
        ActiveObj = GameObject.Find("Puzzle1Col");
        
        Cube1 = GameObject.Find("Cube 1");
        Cube2 = GameObject.Find("Cube 2");
        Cube3 = GameObject.Find("Cube 3");

        FirstCube.sprite = GetComponent<Sprite>();
        SecondCube.sprite = GetComponent<Sprite>();
        ThirdCube.sprite = GetComponent<Sprite>();

        FirstCube.sprite = Cube1On;
        SecondCube.sprite = Cube2Off;
        ThirdCube.sprite = Cube3Off;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObj.GetComponent<Player>().Interactive == false && ActiveObj.GetComponent<EnteringInPuzzle>().EnteringPuzzle == true)
        {
            if (Win == false)
            {
                if (PlayerObj.GetComponent<Player>().Interactive == false)
                {
                    switch (CubeNum)
                    {
                        case 1:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1On;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            break;

                        case 2:
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2On;
                            ThirdCube.sprite = Cube3Off;
                            break;

                        case 3:
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3On;
                            break;
                    }

                    if (PlayerObj.GetComponent<Player>().InputMovement.x >= 0.75f && Timer == true)
                    {
                        StartCoroutine(TimerRight());
                    }

                    if (PlayerObj.GetComponent<Player>().InputMovement.x < -0.75f && Timer == true)
                    {
                        StartCoroutine(TimerLeft());
                    }

                    if (CubeNum < 1)
                    {
                        CubeNum = 1;
                    }

                    if (CubeNum > 3)
                    {
                        CubeNum = 3;
                    }
                }

                if (PlayerObj.GetComponent<Player>().Interactive == true)
                {
                    Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                }

                if (P2 == 1)
                {
                    Solution = P1 + P3;
                }

                if (P2 == 2)
                {
                    Solution = P1 * P3;
                }

                if (P2 == 3)
                {
                    Solution = P1 - P3;
                }

                if (Solution == 5)
                {
                    Win = true;
                }
            }
        }
    }

    IEnumerator TimerRight()
    {
        CubeNum = CubeNum + 1;
        Timer = false;

        yield return new WaitForSeconds(0.25f);

        Timer = true;
    }

    IEnumerator TimerLeft()
    {
        CubeNum = CubeNum - 1;
        Timer = false;

        yield return new WaitForSeconds(0.25f);

        Timer = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "A5")
        {
            P1 = 5;
        }

        if (other.gameObject.tag == "A3")
        {
            P1 = 3;
        }

        if (other.gameObject.tag == "A2")
        {
            P1 = 2;
        }

        if (other.gameObject.tag == "A10")
        {
            P1 = 10;
        }

        if (other.gameObject.tag == "B+")
        {
            P2 = 1;
        }

        if (other.gameObject.tag == "Bx")
        {
            P2 = 2;
        }

        if (other.gameObject.tag == "B-")
        {
            P2 = 3;
        }

        if (other.gameObject.tag == "C2")
        {
            P3 = 2;
        }

        if (other.gameObject.tag == "C3")
        {
            P3 = 3;
        }

        if (other.gameObject.tag == "C5")
        {
            P3 = 5;
        }
    }
}
