using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SkyboxMaterialを一定時間で変更するクラス
public class ChengeSkybox : MonoBehaviour
{
    [SerializeField]
    public Material[] newSkyboxMaterial;// SkyboxMaterialを格納しておく変数
    [HideInInspector]
    float skyChengeTime = 10f;// SkyboxMaterialを変更する周期変数
    [HideInInspector]
    float timer = 0;// タイマー変数
    [HideInInspector]
    int index = 0;// 登録したSkyboxMaterialを数える変数

    void Start()
    {
        index = newSkyboxMaterial.Length;// 登録したSkyboxMaterialの数をindexに格納
    }
    

    void Update()
    {
        timer += Time.deltaTime;// タイマー変数に加算
        if (timer >= skyChengeTime)// タイマーがskyChengeTime以上なら
        {
            RenderSettings.skybox = newSkyboxMaterial[Random.Range(0, index)];// ランダムにSkyboxMaterialを変更
            timer = 0;// タイマーを0に初期化する
        }
    }
}
