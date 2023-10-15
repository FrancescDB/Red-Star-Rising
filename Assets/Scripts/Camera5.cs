using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera5 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam4, Cam5, Cam6;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam4.Priority >= Cam6.Priority)
            {
                Cam5.Priority = Cam4.Priority + 1;
            }

            if (Cam4.Priority < Cam6.Priority)
            {
                Cam5.Priority = Cam6.Priority + 1;
            }
        }
    }
}
