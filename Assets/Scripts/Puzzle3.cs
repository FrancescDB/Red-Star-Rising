using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour
{
    public bool Win;
    public Image FirstCube, SecondCube, ThirdCube, FourthCube, FifthCube, SixthCube, SeventhCube;
    public Sprite Cube1Off;
    public Sprite Cube2Off;
    public Sprite Cube3Off;
    public Sprite Cube4Off;
    public Sprite Cube5Off;
    public Sprite Cube6Off;
    public Sprite Cube7Off;
    public Sprite Cube1On;
    public Sprite Cube2On;
    public Sprite Cube3On;
    public Sprite Cube4On;
    public Sprite Cube5On;
    public Sprite Cube6On;
    public Sprite Cube7On;

    private int P1;
    private int P2;
    private int P3;
    private int P4;
    private int P5;
    private int P6;
    private int P7;
    private int Solution;
    private int CubeNum;
    private float Speed;
    private bool Timer;
    private GameObject Cube1;
    private GameObject Cube2;
    private GameObject Cube3;
    private GameObject Cube4;
    private GameObject Cube5;
    private GameObject Cube6;
    private GameObject Cube7;
    private GameObject PlayerObj;
    private GameObject ActiveObj;

    // Start is called before the first frame update
    void Start()
    {
        Win = false;

        CubeNum = 1;
        Speed = 200f;
        Timer = true;
        
        PlayerObj = GameObject.Find("Player");
        ActiveObj = GameObject.Find("Puzzle3Col");

        Cube1 = GameObject.Find("Cube 9");
        Cube2 = GameObject.Find("Cube 10");
        Cube3 = GameObject.Find("Cube 11");
        Cube4 = GameObject.Find("Cube 12");
        Cube5 = GameObject.Find("Cube 13");
        Cube6 = GameObject.Find("Cube 14");
        Cube7 = GameObject.Find("Cube 15");

        FirstCube.sprite = GetComponent<Sprite>();
        SecondCube.sprite = GetComponent<Sprite>();
        ThirdCube.sprite = GetComponent<Sprite>();
        FourthCube.sprite = GetComponent<Sprite>();
        FifthCube.sprite = GetComponent<Sprite>();
        SixthCube.sprite = GetComponent<Sprite>();
        SeventhCube.sprite = GetComponent<Sprite>();

        FirstCube.sprite = Cube1On;
        SecondCube.sprite = Cube2Off;
        ThirdCube.sprite = Cube3Off;
        FourthCube.sprite = Cube4Off;
        FifthCube.sprite = Cube5Off;
        SixthCube.sprite = Cube6Off;
        SeventhCube.sprite = Cube7Off;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObj.GetComponent<Player>().Interactive == false && ActiveObj.GetComponent<EnteringInPuzzle3>().EnteringPuzzle == true) 
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
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1On;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 2:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2On;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 3:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3On;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 4:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4On;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 5:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5On;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 6:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6On;
                            SeventhCube.sprite = Cube7Off;
                            break;

                        case 7:
                            Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerObj.GetComponent<Player>().InputMovement.y * Speed, 0);
                            FirstCube.sprite = Cube1Off;
                            SecondCube.sprite = Cube2Off;
                            ThirdCube.sprite = Cube3Off;
                            FourthCube.sprite = Cube4Off;
                            FifthCube.sprite = Cube5Off;
                            SixthCube.sprite = Cube6Off;
                            SeventhCube.sprite = Cube7On;
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

                    if (CubeNum > 7)
                    {
                        CubeNum = 7;
                    }
                }

                if (PlayerObj.GetComponent<Player>().Interactive == true)
                {
                    Cube1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Cube7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                }

                if (P2 == 1)
                {
                    if (P4 == 1)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 + P3 + P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 + P3 + P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 + P3 + P5 - P7;
                        }
                    }

                    if (P4 == 2)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 + P3 * P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 + P3 * P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 + P3 * P5 - P7;
                        }
                    }

                    if (P4 == 3)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 + P3 - P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 + P3 - P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 + P3 - P5 - P7;
                        }
                    }
                }

                if (P2 == 2)
                {
                    if (P4 == 1)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 * P3 + P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 * P3 + P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 * P3 + P5 - P7;
                        }
                    }

                    if (P4 == 2)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 * P3 * P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 * P3 * P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 * P3 * P5 - P7;
                        }
                    }

                    if (P4 == 3)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 * P3 - P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 * P3 - P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 * P3 - P5 - P7;
                        }
                    }
                }

                if (P2 == 3)
                {
                    if (P4 == 1)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 - P3 + P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 - P3 + P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 - P3 + P5 - P7;
                        }
                    }

                    if (P4 == 2)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 - P3 * P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 - P3 * P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 - P3 * P5 - P7;
                        }
                    }

                    if (P4 == 3)
                    {
                        if (P6 == 1)
                        {
                            Solution = P1 - P3 - P5 + P7;
                        }

                        if (P6 == 2)
                        {
                            Solution = P1 - P3 - P5 * P7;
                        }

                        if (P6 == 3)
                        {
                            Solution = P1 - P3 - P5 - P7;
                        }
                    }
                }

                if (Solution == 24)
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
        if (other.gameObject.tag == "A2")
        {
            P1 = 2;
        }

        if (other.gameObject.tag == "A7")
        {
            P1 = 7;
        }

        if (other.gameObject.tag == "B-")
        {
            P2 = 3;
        }

        if (other.gameObject.tag == "Bx")
        {
            P2 = 2;
        }

        if (other.gameObject.tag == "B+")
        {
            P2 = 1;
        }

        if (other.gameObject.tag == "C10")
        {
            P3 = 10;
        }

        if (other.gameObject.tag == "C5")
        {
            P3 = 5;
        }

        if (other.gameObject.tag == "C3")
        {
            P3 = 3;
        }

        if (other.gameObject.tag == "C2")
        {
            P3 = 2;
        }

        if (other.gameObject.tag == "D-")
        {
            P4 = 3;
        }

        if (other.gameObject.tag == "D+")
        {
            P4 = 1;
        }

        if (other.gameObject.tag == "E2")
        {
            P5 = 2;
        }

        if (other.gameObject.tag == "E7")
        {
            P5 = 7;
        }

        if (other.gameObject.tag == "E5")
        {
            P5 = 5;
        }

        if (other.gameObject.tag == "F-")
        {
            P6 = 3;
        }

        if (other.gameObject.tag == "Fx")
        {
            P6 = 2;
        }

        if (other.gameObject.tag == "G10")
        {
            P7 = 10;
        }

        if (other.gameObject.tag == "G3")
        {
            P7 = 3;
        }

        if (other.gameObject.tag == "G5")
        {
            P7 = 5;
        }
    }
}
