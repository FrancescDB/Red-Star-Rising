using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera7 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam6, Cam7, Cam8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cam6.Priority >= Cam8.Priority)
            {
                Cam7.Priority = Cam6.Priority + 1;
            }

            if (Cam6.Priority < Cam8.Priority)
            {
                Cam7.Priority = Cam8.Priority + 1;
            }
        }
    }
}
