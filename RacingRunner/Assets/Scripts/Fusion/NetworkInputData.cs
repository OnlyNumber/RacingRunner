using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public int line;
    public NetworkBool isPressedBrake;
}
