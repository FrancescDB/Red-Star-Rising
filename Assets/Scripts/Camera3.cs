using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera3 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam2, Cam3, Cam4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam2.Priority >= Cam4.Priority)
            {
                Cam3.Priority = Cam2.Priority + 1;
            }

            if (Cam2.Priority < Cam4.Priority)
            {
                Cam3.Priority = Cam4.Priority + 1;
            }
        }
    }
}
