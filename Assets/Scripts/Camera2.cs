using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera2 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam1, Cam2, Cam3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam1.Priority >= Cam3.Priority)
            {
                Cam2.Priority = Cam1.Priority + 1;
            }

            if (Cam1.Priority < Cam3.Priority)
            {
                Cam2.Priority = Cam3.Priority + 1;
            }
        }
    }
}
