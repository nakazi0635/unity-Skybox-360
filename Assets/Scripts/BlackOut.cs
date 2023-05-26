using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // ブラックアウトの速度
    public float targetDarkness = 1f; // 最終的な暗さの割合
    public float targetBrightness = 0f; // 最終的な明るさの割合
    private float currentDarkness = 0f; // 現在の暗さの割合

    public Image blackoutPanel; // 暗転用のUIパネル

    private float elapsedTime = 0f; // 経過時間
    private bool isBlackout = false; // ブラックアウト中かどうか
    private bool firstchenge = true;

    void Start()
    {

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 8f)
        {
            elapsedTime = 0f;
            StartBlackout();
        }

        if (isBlackout)
        {
            if (currentDarkness < targetDarkness)
            {
                currentDarkness += fadeSpeed * Time.deltaTime;
                currentDarkness = Mathf.Clamp01(currentDarkness);
                blackoutPanel.color = new Color(0f, 0f, 0f, currentDarkness);
            }
            else
            {
                isBlackout = false;
            }
            elapsedTime = 0f;
            Debug.Log(elapsedTime);
        }
        else
        {
            if (currentDarkness > targetBrightness)
            {
                currentDarkness -= fadeSpeed * Time.deltaTime;
                currentDarkness = Mathf.Clamp01(currentDarkness);
                blackoutPanel.color = new Color(0f, 0f, 0f, currentDarkness);
            }
        }
    }

    public void StartBlackout()
    {
        currentDarkness = 0f; // 初期化
        isBlackout = true;
    }
}