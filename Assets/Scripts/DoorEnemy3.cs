using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnemy3 : MonoBehaviour
{
    private GameObject CountObj;
    private Animator DoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        CountObj = GameObject.Find("ContadorEnemigos");
        DoorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountObj.GetComponent<EnemyCount>().EnemyNumber >= 8)
        {
            DoorAnim.SetBool("Moving", true);
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
