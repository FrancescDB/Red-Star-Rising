using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public int EnemyNumber;

    void Start()
    {
        EnemyNumber = 0;    
    }

    public void OneMore()
    {
        EnemyNumber = EnemyNumber + 1;
    }
}
