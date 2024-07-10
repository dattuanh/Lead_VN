using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    // Access mesh render in quad to access the materials to change the background offset
    private MeshRenderer m_Renderer;
    //public float animationSpeed = 1f;
    public float baseSpeed = 0.5f;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        SpeedManager.UpdateSpeed();
        float animationSpeed = baseSpeed + SpeedManager.GetCurrentSpeed();
        m_Renderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);

        //// Increase the animation speed over time
        //animationSpeed += accelerationRate * Time.deltaTime;

        //// Move the texture
        //m_Renderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);   
    }

}
