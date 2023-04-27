using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class LineController : NetworkBehaviour
{


    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] lines;

    [SerializeField]
    private int targetLine = 0;


    public override void FixedUpdateNetwork()
    {
        /*if (GetInput(out NetworkInputData networkInput))
        {
            if (networkInput.line != 0) 
            Debug.Log(networkInput.line);

            MoveToLine(networkInput.line);*/

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(lines[targetLine].x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        //}
    }

    public void MoveToLine(int lineIndex)
    {
        Rpc_RequestChangePos(lineIndex);

        //if (lineIndex + targetLine >= 0 && lineIndex + targetLine < lines.Length)
        //targetLine += lineIndex;
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    private void Rpc_RequestChangePos(int lineIndex)
    {
        if (lineIndex + targetLine >= 0 && lineIndex + targetLine < lines.Length)
            targetLine += lineIndex;
    }


}
