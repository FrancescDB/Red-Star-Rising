using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript2 : MonoBehaviour
{
    private bool Healeable;
    private GameObject PlayerObj;

    public GameObject HealObj;

    void Start()
    {
        Healeable = false;

        PlayerObj = GameObject.Find("Player");
    }

    void Update()
    {
        if (Healeable && PlayerObj.GetComponent<Player>().HealMe == true && PlayerObj.GetComponent<Player>().Life < 5)
        {
            PlayerObj.GetComponent<Player>().Life = PlayerObj.GetComponent<Player>().Life + 1;
            Destroy(HealObj);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Healeable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Healeable = false;
        }
    }
}
