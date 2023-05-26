using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 3f;
    [HideInInspector]
    Vector3 lastMousePosition;
    [SerializeField]
    Quaternion currentRotation;
    [SerializeField]
    Quaternion targetRotation;
    [SerializeField]
    float RotationTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        RotationTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        RotationTimer += Time.deltaTime;
        if (RotationTimer >= 2f){
            currentRotation = transform.rotation;
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + 0.02f, 0f);
            transform.rotation = targetRotation;
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            RotationTimer = 0f;
            float verticalMovement = Input.GetAxis("Mouse Y");
            float horizontalMovement = Input.GetAxis("Mouse X");

            float rotationY = -horizontalMovement * rotationSpeed * Time.deltaTime;
            float rotationX = verticalMovement * rotationSpeed * Time.deltaTime;

            // Z軸回転を0に設定
            currentRotation = transform.rotation;
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationX, currentRotation.eulerAngles.y + rotationY, 0f);

            transform.rotation = targetRotation;
            lastMousePosition = Input.mousePosition;
        }
        Debug.Log(RotationTimer);
    }
}