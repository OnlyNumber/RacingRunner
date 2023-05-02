using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SkinController : NetworkBehaviour
{

    [SerializeField]
    private List<GameObject> _carList;

    [Networked(OnChanged = nameof(OnSkinChanged))]
    private int skinNumber { get; set; }




    private void Start()
    {
        skinNumber = -1;
        Rpc_RequestChangeSkin(DataHolder.car);
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void Rpc_RequestChangeSkin(int skinNumber, RpcInfo info = default)
    {
        this.skinNumber = skinNumber;
    }

    static void OnSkinChanged(Changed<SkinController> changed)
    {
        changed.Behaviour.OnSkinChange();
    }

    private void OnSkinChange()
    {
        _carList[0].SetActive(false);
        _carList[skinNumber].SetActive(true);
    
    }


}
