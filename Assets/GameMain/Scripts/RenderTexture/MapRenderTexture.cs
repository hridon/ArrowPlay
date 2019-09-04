using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderTexture : MonoBehaviour
{

    [SerializeField]
    private RenderTexture tex;

    [SerializeField] 
    private MeshRenderer render;

	// Update is called once per frame
	void Update () {
        if (tex != null && render != null)
        {
            render.material.mainTexture = tex;
        }
    }
}
