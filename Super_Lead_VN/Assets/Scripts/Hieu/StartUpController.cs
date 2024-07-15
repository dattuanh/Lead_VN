using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpController : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    public float offset;
    public Material mat; 

    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
