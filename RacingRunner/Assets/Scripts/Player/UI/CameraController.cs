using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CameraController : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera cam;

    private void Start()
    {
        cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();

        if (GetComponent<NetworkObject>().HasInputAuthority)
        {
            cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
            cam.Follow = transform;

            //cam.
        }
    }
}
