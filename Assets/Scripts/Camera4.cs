using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera4 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam3, Cam4, Cam5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam3.Priority >= Cam5.Priority)
            {
                Cam4.Priority = Cam3.Priority + 1;
            }

            if (Cam3.Priority < Cam5.Priority)
            {
                Cam4.Priority = Cam5.Priority + 1;
            }
        }
    }
}
