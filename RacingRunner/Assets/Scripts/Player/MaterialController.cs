using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MaterialController : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    [SerializeField]
    private Shader shader;

    private Color cl;

    [ContextMenu("EtiBlikiOslepliaut")]
    public void EtiBlikiOslepliaut()
    {

        _material.SetFloat("_Mode", 3);

        _material.SetInt("_ZWrite", 3);
        _material.renderQueue = 3000;

        _material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

        _material.DisableKeyword("_ALPHATEST_ON");
        _material.EnableKeyword("_ALPHABLEND_ON");
        _material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        //_material.

        /*_material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        _material.SetInt("_ZWrite", 0);
        _material.DisableKeyword("_ALPHATEST_ON");
        _material.EnableKeyword("_ALPHABLEND_ON");
        _material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        

        //set transparency
        _material.SetColor("_Color", new Color(1, 1, 1, 0.3f));*/

    }


}
