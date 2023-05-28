using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 背景を自動回転させたり、マウスドラッグで回転させるクラス
public class ImageMove : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 10f;// 背景の回転スピード
    [HideInInspector]
    Vector3 lastMousePosition;// マウスがクリックされた位置を格納しておく変数
    [HideInInspector]
    Quaternion currentRotation;// 現在のrotationを格納するQuaternion変数を生成
    [HideInInspector]
    Quaternion targetRotation;// 次フレームのrotationを格納するQuaternion変数を生成
    [SerializeField]
    float rotationTimer = 2f;// 背景変更の周期を格納する変数
    [HideInInspector]
    float timer = 10;// タイマー変数　起動時に自動移動させるために、タイマーに10を代入
    [SerializeField]
    float autoMovementSpeed = 0.05f;// 背景の自動回転スピード
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;// タイマー変数に加算
        if (timer >= rotationTimer){// タイマーがrotationTime以上なら
            currentRotation = transform.rotation;// 現在位置をcurrentRotationに代入。三次元の向きを格納
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + autoMovementSpeed, 0f);// 更新される角度をtargetRotationに格納
            transform.rotation = targetRotation;// 現在位置を更新する
        }

        
        if (Input.GetMouseButtonDown(0))// もし左クリックが押されたら
        {
            lastMousePosition = Input.mousePosition;// 現在のマウスの位置をlastMousePositionに代入
        }
        if (Input.GetMouseButton(0))// もし左クリックが押されている間
        {
            timer = 0f;// タイマーを0に初期化する
            float verticalMovement = Input.GetAxis("Mouse X");// マウスのY軸の移動量をverticalMovementに代入
            float horizontalMovement = Input.GetAxis("Mouse Y");// マウスのX軸の移動量をhorizonalMovementに代入

            float rotationY = -verticalMovement * rotationSpeed * Time.deltaTime;// 増加量*定数*時間で移動した距離を計算
            float rotationX = horizontalMovement * rotationSpeed * Time.deltaTime;// 増加量*定数*時間で移動した距離を計算


            currentRotation = transform.rotation;// 現在位置をcurrentRotationに代入。三次元の向きを格納
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationX, currentRotation.eulerAngles.y + rotationY, 0f);// 更新される角度をtargetRotationに格納

            transform.rotation = targetRotation;// 現在位置を更新

            lastMousePosition = Input.mousePosition;// 現在のマウスの位置をlastMousePositionに代入
        }
    }
}