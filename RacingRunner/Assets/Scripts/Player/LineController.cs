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

    private int targetLine = 0;


    public override void FixedUpdateNetwork()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(lines[targetLine].x, transform.position.y, transform.position.z), speed );
        
    }

    public void MoveToLine(int lineIndex)
    {
        if(lineIndex + targetLine >= 0 && lineIndex + targetLine < lines.Length)
        targetLine += lineIndex;
    }


}
