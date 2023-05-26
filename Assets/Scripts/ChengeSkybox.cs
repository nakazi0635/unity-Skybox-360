using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeSkybox : MonoBehaviour
{
    [SerializeField]
    Material newSkyboxMaterial;

    void Update()
    {

        
        if (Input.GetMouseButtonDown(1))
        {
            RenderSettings.skybox = newSkyboxMaterial;
        }
    }
}
