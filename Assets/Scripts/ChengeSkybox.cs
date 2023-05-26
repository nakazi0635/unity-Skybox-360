using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeSkybox : MonoBehaviour
{
    [SerializeField]
    public Material[] newSkyboxMaterial;
    [SerializeField]
    float skyChengeTime = 0;
    [SerializeField]
    int index = 0;

    void Start()
    {
        index = newSkyboxMaterial.Length;
    }
    

    void Update()
    {
        skyChengeTime += Time.deltaTime;
        if (skyChengeTime >= 1f)
        {
            RenderSettings.skybox = newSkyboxMaterial[Random.Range(0, index)];
            skyChengeTime = 0;
        }
    }
}
