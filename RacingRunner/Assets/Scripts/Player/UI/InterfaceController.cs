using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

public class InterfaceController : NetworkBehaviour
{
    private Transform start;

    private TMP_Text dist;

    private void Start()
    {
        //start = GameObject.Find("GameStarter").transform;
        if(HasInputAuthority)
        dist = GameObject.Find("DistanceToStartText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (HasInputAuthority)
            dist.text = $"{transform.position.z}";
    }
}
