using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera6 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam5, Cam6, Cam7;

    private bool Entered;
    private GameObject PlayerObj;

    private void Start()
    {
        Entered = false;

        PlayerObj = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Entered == true)
        {
            Cam6.transform.position = new Vector3(PlayerObj.transform.position.x, 2.59f, 0.89f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam5.Priority >= Cam7.Priority)
            {
                Cam6.Priority = Cam5.Priority + 1;
            }

            if (Cam5.Priority < Cam7.Priority)
            {
                Cam6.Priority = Cam7.Priority + 1;
            }

            Entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Entered = false;
        }
    }
}
