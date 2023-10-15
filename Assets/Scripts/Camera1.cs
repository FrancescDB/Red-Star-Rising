using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera1 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam1, Cam2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cam1.Priority = Cam2.Priority + 1;
        }
    }
}
