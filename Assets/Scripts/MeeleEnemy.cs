using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeeleEnemy : MonoBehaviour
{
    public int Life;
    //public Transform movePosition;

    private bool AttackAnim;

    private int State;
    private float Speed;
    private float Step;
    private float Force;
     /**/private bool Damageable;
    private bool Die;

    private Vector3 ViewPos;
    private Vector3 PushDirection;
    private Quaternion Rotation;
    private Rigidbody Rb;
    private GameObject PlayerObj;
    private GameObject CounterObj;
    private Animator EnemyAnim;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        Life = 3;

        AttackAnim = true;

        State = 0;
        Speed = 3f;
        Force = 4f;
        Damageable = true;
        Die = false;

        Rb = GetComponent<Rigidbody>();
        PlayerObj = GameObject.Find("Player");
        CounterObj = GameObject.Find("ContadorEnemigos");
        EnemyAnim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch (State)
        {
            case 0:
                Idle();
                break;

            case 1:
                Walking();
                break;

            case 2:
                Attacking();
                break;

            case 3:
                Dying();
                break;
        }

        if (Die == false)
        {
            if (Vector3.Distance(PlayerObj.transform.position, transform.position) > 5)
            {
                State = 0;
            }
            else
            {
                if (Vector3.Distance(PlayerObj.transform.position, transform.position) > 2)
                {
                    State = 1;
                }
                else
                {
                    State = 2;
                }
            }
        }
        else
        {
            State = 3;
        }
        

    }

    void Idle()
    {
        Rb.velocity = new Vector3(0, Rb.velocity.y, 0);
        EnemyAnim.SetBool("Idle", true);
        EnemyAnim.SetBool("Attacking", false);
        EnemyAnim.SetBool("Walking", false);
        AttackAnim = true;
    }

    void Walking()
    {
        //Step = Speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, PlayerObj.transform.position, Step);

        ViewPos = PlayerObj.transform.position - transform.position;
        ViewPos.y = 0;
        Rotation = Quaternion.LookRotation(ViewPos);
        navMeshAgent.destination = new Vector3(PlayerObj.transform.position.x, 0, PlayerObj.transform.position.z);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 1);
        EnemyAnim.SetBool("Idle", false);
        EnemyAnim.SetBool("Attacking", false);
        EnemyAnim.SetBool("Walking", true);
        AttackAnim = true;
    }

    void Attacking()
    {
        Rb.velocity = new Vector3(0, Rb.velocity.y, 0);
        ViewPos = PlayerObj.transform.position - transform.position;
        ViewPos.y = 0;
        Rotation = Quaternion.LookRotation(ViewPos);

        if(AttackAnim == true)
        {
            StartCoroutine(StartAttack());
        }
    }

    void Dying()
    {
        Rb.velocity = new Vector3(0, Rb.velocity.y, 0);
        ViewPos = PlayerObj.transform.position - transform.position;
        ViewPos.y = 0;
        Rotation = Quaternion.LookRotation(ViewPos);
        EnemyAnim.SetBool("Dying", true);
        EnemyAnim.SetBool("Idle", false);
        EnemyAnim.SetBool("Walking", false);
        EnemyAnim.SetBool("Attacking", false);

    }

    public void TakeDamage()
    {
        Life = Life - 1;

        Debug.Log("EnemyLife:" + Life);

        if (Life <= 0)
        {
            Die = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PushDirection = PlayerObj.transform.position - transform.position;
            //PushDirection = -PushDirection.normalized;
            PushDirection = PushDirection.normalized;
            PlayerObj.GetComponent<Rigidbody>().AddForce(PushDirection * Force, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "PlayerHit")
        {
            TakeDamage();
        }
    }

    public void DestroyMe()
    {
        StartCoroutine(Destroying());
    }

    IEnumerator Destroying()
    {
        CounterObj.GetComponent<EnemyCount>().OneMore();
        Destroy(this.gameObject);

        yield return null;
    }

    IEnumerator StartAttack()
    {
        EnemyAnim.SetBool("Attacking", true);
        EnemyAnim.SetBool("Idle", false);
        EnemyAnim.SetBool("Walking", false);
        AttackAnim = false;

        yield return new WaitForSeconds(0.7f);

        EnemyAnim.SetBool("Attacking", false);
        EnemyAnim.SetBool("Idle", true);
        EnemyAnim.SetBool("Walking", false);

        yield return new WaitForSeconds(1f);

        AttackAnim = true;
    }
}
