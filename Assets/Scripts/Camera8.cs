using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera8 : MonoBehaviour
{
    public CinemachineVirtualCamera Cam7, Cam8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cam8.Priority = Cam7.Priority + 1;
        }
    }
}
