using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringInPuzzle2 : MonoBehaviour
{
    public bool EnteringPuzzle;

    private GameObject PlayerObj;

    void Start()
    {
        EnteringPuzzle = false;

        PlayerObj = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnteringPuzzle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnteringPuzzle = false;
        }
    }
}
