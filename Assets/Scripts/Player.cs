using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public int Life;
    public bool Attacking;
    public bool Interactive;
    public bool HealMe;
    public Vector2 InputMovement;
    public GameObject RealPuzzleObj;
    public GameObject RealPuzzleObj2;
    public GameObject RealPuzzleObj3;
    public GameObject Canvas2;

    private int RandomDeath;
    private float SpeedWalk;
    private float SpeedRun;
    private float SpeedRoll;
    private float ViewPos;
    private bool Moving;
    private bool Golpe;
    private bool Damage;
    private bool Running;
    private bool EndCoroutine;
    private bool Rolling;
    private bool RollAgain;
    private bool Dying;
    private bool Puzzle1Win;
    private bool Puzzle2Win;
    private bool Puzzle3Win;
    private Vector2 RollVector;

    private bool AttackingAnim;

    private Animator PlayerAnim;
    private Rigidbody Rb;
    private GameObject UIObj;
    private GameObject EnemyObj;
    private GameObject PuzzleObj;
    private GameObject Puzzle2Obj;
    private GameObject Puzzle3Obj;

    void Awake()
    {
        Life = 5;
        Interactive = true;

        SpeedWalk = 5f;
        SpeedRun = 7.5f;
        SpeedRoll = 12.5f;
        Moving = false;
        Attacking = false;
        Golpe = false;
        Damage = false;
        Running = false;
        EndCoroutine = true;
        Rolling = false;
        Dying = false;
        RollAgain = true;
        HealMe = false;

        Puzzle1Win = false;
        Puzzle2Win = false;
        Puzzle3Win = false;

        Rb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        UIObj = GameObject.Find("Canvas (UI)");
        PuzzleObj = GameObject.Find("Puzzle1Col");
        Puzzle2Obj = GameObject.Find("Puzzle2Col");
        Puzzle3Obj = GameObject.Find("Puzzle3Col");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (Rolling == false)
        {
            InputMovement = context.ReadValue<Vector2>();

            Moving = true;
        }  
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (Interactive == true)
        {
            if (EndCoroutine == true && Rolling == false)
            {
                if (context.started)
                {
                    StartCoroutine(Attackk());
                    AttackingAnim = true;
                }

                if (context.canceled)
                {
                    Attacking = false;
                }
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (Rolling == false)
        {
            if (context.started)
            {
                if (Interactive == true)
                {
                    if (Puzzle1Win == false)
                    {
                        if (PuzzleObj.GetComponent<EnteringInPuzzle>().EnteringPuzzle == true)
                        {
                            Interactive = false;
                            RealPuzzleObj.SetActive(true);
                            UIObj.SetActive(false);
                        }
                    }

                    if (Puzzle2Win == false)
                    {
                        if (Puzzle2Obj.GetComponent<EnteringInPuzzle2>().EnteringPuzzle == true)
                        {
                            Interactive = false;
                            RealPuzzleObj2.SetActive(true);
                            UIObj.SetActive(false);
                        }
                    }

                    if (Puzzle3Win == false)
                    {
                        if (Puzzle3Obj.GetComponent<EnteringInPuzzle3>().EnteringPuzzle == true)
                        {
                            Interactive = false;
                            RealPuzzleObj3.SetActive(true);
                            UIObj.SetActive(false);
                        }
                    }

                    HealMe = true;
                }
            }

            if (context.canceled)
            {
                HealMe = false;
            }
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (Interactive == true)
        {
            if (context.started && Rolling == false && RollAgain == true)
            {
                StartCoroutine(Rolled());
            }
        }
    }
    
    public void OnRun(InputAction.CallbackContext context)
    {
        if (Interactive == true)
        {
            if (Rolling == false)
            {
                if (context.action.triggered)
                {
                    Running = true;
                }

                if (context.canceled)
                {
                    Running = false;
                }
            }
        }  
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if (Interactive == false)
        {
            if (Puzzle1Win == false)
            {
                StartCoroutine(InteractingTrue());
                RealPuzzleObj.SetActive(false);
            }

            UIObj.SetActive(true);
        }

        if (Interactive == false)
        {
            if (Puzzle2Win == false)
            {
                StartCoroutine(InteractingTrue());
                RealPuzzleObj2.SetActive(false);
            }

            UIObj.SetActive(true);
        }

        if (Interactive == false)
        {
            if (Puzzle3Win == false)
            {
                StartCoroutine(InteractingTrue());
                RealPuzzleObj3.SetActive(false);
            }

            UIObj.SetActive(true);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Pause");
    }

    void Update()
    {
        if (Golpe == false)
        {
            if (InputMovement == new Vector2(0, 0))
            {
                Moving = false;
            }

            if (Moving == true && Interactive == true)
            {
                ViewPos = Mathf.Atan2(InputMovement.x, InputMovement.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, ViewPos, 0f);
            }
        }

        if (Damage == true)
        {
            TakeDamage();
        }

        if (Rolling == false)
        {
            RollVector = InputMovement;
        }

        Animations();

        if (Life <= 0)
        {
            Golpe = true;
            Dying = true;
            Rb.velocity = new Vector3(0, 0, 0);
        }

        if (Puzzle1Win == false)
        {
            if (RealPuzzleObj.GetComponent<Puzzle1>().Win == true)
            {
                StartCoroutine(DestroyPuzzle1());
                Interactive = true;
            }
        }

        if (Puzzle2Win == false)
        {
            if (RealPuzzleObj2.GetComponent<Puzzle2>().Win == true)
            {
                StartCoroutine(DestroyPuzzle2());
                Interactive = true;
            }
        }

        if (Puzzle3Win == false)
        {
            if (RealPuzzleObj3.GetComponent<Puzzle3>().Win == true)
            {
                StartCoroutine(DestroyPuzzle3());
                Interactive = true;
            }
        }

        if (Interactive == true)
        {
            RealPuzzleObj.SetActive(false);
            RealPuzzleObj2.SetActive(false);
            RealPuzzleObj3.SetActive(false);
            UIObj.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (Golpe == false)
        {
            if (Interactive == true)
            {
                if (Rolling == true)
                {
                    Rb.velocity = new Vector3(RollVector.x * SpeedRoll, 0, RollVector.y * SpeedRoll);
                }
                else
                {
                    if (Running == false)
                    {
                        Rb.velocity = new Vector3(InputMovement.x * SpeedWalk, 0, InputMovement.y * SpeedWalk);
                    }
                    else
                    {
                        Rb.velocity = new Vector3(InputMovement.x * SpeedRun, 0, InputMovement.y * SpeedRun);
                    }
                }  
            }
            else
            {
                if (AttackingAnim == true)
                {
                    Rb.velocity = new Vector3(InputMovement.x * SpeedWalk, 0, InputMovement.y * SpeedWalk);
                }
                else
                {
                    Rb.velocity = new Vector3(0, 0, 0);
                }
            }
        }
    }

    public void TakeDamage()
    {
        Life = Life - 1;
        
        StartCoroutine(Golpeando());
    }

    IEnumerator DestroyPuzzle1()
    {
        Interactive = true;
        Puzzle1Win = true;

        yield return null;

        Destroy(RealPuzzleObj);
        Destroy(PuzzleObj);
    }

    IEnumerator DestroyPuzzle2()
    {
        Interactive = true;
        Puzzle2Win = true;

        yield return null;

        Destroy(RealPuzzleObj2);
        Destroy(Puzzle2Obj);
        Canvas2.SetActive(true);
    }

    IEnumerator DestroyPuzzle3()
    {
        Interactive = true;
        Puzzle3Win = true;

        yield return null;

        Destroy(RealPuzzleObj3);
        Destroy(Puzzle3Obj);
    }

    IEnumerator InteractingTrue()
    {
        yield return null;

        Interactive = true;
    }

    IEnumerator Golpeando()
    {
        Golpe = true;
        Damage = false;

        yield return new WaitForSeconds(0.5f);

        Golpe = false;
    }

    IEnumerator Attackk()
    {
        EndCoroutine = false;
        Attacking = true;
        AttackingAnim = true;

        yield return null;

        Attacking = false;   

        yield return new WaitForSeconds(0.15f);

        EndCoroutine = true;
        AttackingAnim = false;
    }

    IEnumerator Rolled()
    {
        Rolling = true;
        RollAgain = false;

        yield return new WaitForSeconds (0.5f);

        Rolling = false;

        yield return new WaitForSeconds(0.5f);

        RollAgain = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyHit")
        {
            Damage = true;
        }
    }
    
    void Animations()
    {
        if (Dying == false)
        {
            if (Golpe == false)
            {
                if (Interactive == true)
                {
                    if (Rolling == true)
                    {
                        PlayerAnim.SetBool("Rolling", true);
                        PlayerAnim.SetBool("Walking", false);
                        PlayerAnim.SetBool("Running", false);
                        PlayerAnim.SetBool("Attacking", false);
                        PlayerAnim.SetBool("Hit", false);
                        PlayerAnim.SetBool("Idle", false);
                    }
                    else
                    {
                        if (Running == false)
                        {
                            PlayerAnim.SetBool("Walking", true);
                            PlayerAnim.SetBool("Running", false);
                            PlayerAnim.SetBool("Rolling", false);
                            PlayerAnim.SetBool("Hit", false);
                            PlayerAnim.SetBool("Idle", false);
                            PlayerAnim.SetBool("Attacking", false);
                        }
                        else
                        {
                            PlayerAnim.SetBool("Running", true);
                            PlayerAnim.SetBool("Walking", false);
                            PlayerAnim.SetBool("Rolling", false);
                            PlayerAnim.SetBool("Idle", false);
                            PlayerAnim.SetBool("Hit", false);
                            PlayerAnim.SetBool("Attacking", false);
                        }
                    }
                }
                else
                {
                    if (AttackingAnim == true)
                    {
                        PlayerAnim.SetBool("Attacking", true);
                        PlayerAnim.SetBool("Idle", false);
                        PlayerAnim.SetBool("Hit", false);
                        PlayerAnim.SetBool("Running", false);
                        PlayerAnim.SetBool("Rolling", false);
                        PlayerAnim.SetBool("Walking", false);
                    }
                    else
                    {
                        PlayerAnim.SetBool("Idle", true);
                        PlayerAnim.SetBool("Hit", false);
                        PlayerAnim.SetBool("Running", false);
                        PlayerAnim.SetBool("Rolling", false);
                        PlayerAnim.SetBool("Walking", false);
                        PlayerAnim.SetBool("Attacking", false);
                    }
                }
            }
            else
            {
                PlayerAnim.SetBool("Hit", true);
                PlayerAnim.SetBool("Idle", false);
                PlayerAnim.SetBool("Walking", false);
                PlayerAnim.SetBool("Rolling", false);
                PlayerAnim.SetBool("Running", false);
                PlayerAnim.SetBool("Attacking", false);
            }

            if (Rb.velocity == new Vector3 (0,0,0))
            {
                if (AttackingAnim == true)
                {
                    PlayerAnim.SetBool("Attacking", true);
                    PlayerAnim.SetBool("Idle", false);
                    PlayerAnim.SetBool("Hit", false);
                    PlayerAnim.SetBool("Running", false);
                    PlayerAnim.SetBool("Rolling", false);
                    PlayerAnim.SetBool("Walking", false);
                }
                else
                {
                    PlayerAnim.SetBool("Idle", true);
                    PlayerAnim.SetBool("Hit", false);
                    PlayerAnim.SetBool("Running", false);
                    PlayerAnim.SetBool("Rolling", false);
                    PlayerAnim.SetBool("Walking", false);
                    PlayerAnim.SetBool("Attacking", false);
                }
            }
        }
        else
        {
            StartCoroutine(AnimDeath());
        }
    }

    IEnumerator AnimDeath()
    {
        PlayerAnim.SetBool("Hit", true);
        PlayerAnim.SetBool("Idle", false);
        PlayerAnim.SetBool("Walking", false);
        PlayerAnim.SetBool("Attacking", false);
        PlayerAnim.SetBool("Running", false);
        PlayerAnim.SetBool("Rolling", false);
        RandomDeath = Random.Range(1, 101);

        yield return new WaitForSeconds (0.5f);

        if (RandomDeath >= 1 && RandomDeath <= 5)
        {
            PlayerAnim.SetBool("Dying2", true);
            PlayerAnim.SetBool("Hit", false);
        }
        
        if (RandomDeath > 5)
        {
            PlayerAnim.SetBool("Dying1", true);
            PlayerAnim.SetBool("Hit", false);
        }
    }

    public void GoToDeathMenu()
    {
        SceneManager.LoadScene(3);
    }
}
