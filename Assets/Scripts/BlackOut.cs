using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ブラックアウトした後再び元の透明度に戻すクラス
public class BlackOut : MonoBehaviour
{
    [HideInInspector]
    float fadeSpeed = 0.5f; // ブラックアウトの速度
    [HideInInspector]
    float targetDarkness = 1f; // 最終的な暗さ
    [HideInInspector]
    float targetBrightness = 0f; // 最終的な明るさ
    [HideInInspector]
    float currentDarkness = 0f; // 現在の暗さ
    [SerializeField]
    Image blackoutPanel; // 暗転用のUIパネル

    [HideInInspector]
    float elapsedTime = 8f; // ブラックアウトが開始される周期
    [HideInInspector]
    float timer = 0f; // タイマー変数
    [HideInInspector]
    bool isBlackout = false; // ブラックアウト中かどうか
    [HideInInspector]
    bool firstchenge = true;// １回目のブラックアウトかどうか

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;// タイマー変数に加算

        if (timer >= elapsedTime)// タイマーがelapsedTime以上なら
        {
            timer = 0f;// タイマーを0に初期化する
            StartBlackout();// StartBlackout関数を実行する
        }

        if (isBlackout)// isBlackoutがtrueなら
        {
            if (currentDarkness < targetDarkness)// 最終的な暗さより小さければ
            {
                currentDarkness += fadeSpeed * Time.deltaTime;// 現在の暗さに加算する
                currentDarkness = Mathf.Clamp01(currentDarkness);// 透明度を表す値を制限(確実に0~1の範囲にする)
                blackoutPanel.color = new Color(0f, 0f, 0f, currentDarkness);// 透明度を変更
            }
            else// 最終的な暗さより小さくなければ
            {
                isBlackout = false;// isBlackoutをfalseにする
            }
            timer = 0f;// タイマーを0に初期化する
        }
        else// isBlackoutがfalseなら
        {
            if (currentDarkness > targetBrightness)// 最終的な明るさより大きければ
            {
                currentDarkness -= fadeSpeed * Time.deltaTime;// 現在の暗さに減算する
                currentDarkness = Mathf.Clamp01(currentDarkness);// 透明度を表す値を制限(確実に0~1の範囲にする)
                blackoutPanel.color = new Color(0f, 0f, 0f, currentDarkness);// 透明度を変更
            }
        }
    }

    public void StartBlackout()// 
    {
        currentDarkness = 0f; // currentDarkness(明るさ)を初期化
        isBlackout = true;// isBlackoutをtrueにする
    }
}