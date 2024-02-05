using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 inputMoveDirection;
    private Vector3 moveVector;

    private Vector3 rotationVector;

    [SerializeField] Transform BoundX;
    [SerializeField] Transform BoundX1;
    [SerializeField] Transform BoundZ;
    [SerializeField] Transform BoundZ1;


    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    private void Update()
    {
        inputMoveDirection = new Vector3 (0, 0, 0);
        rotationVector = new Vector3(0, 0, 0);

   
        CameraMoving();
          
        
        CameraRotating();
    }

    private void CameraMoving()
    {
        Vector2 inputMoveDir = InputManager.Instance.GetCameraMoveVector();

        Vector3 moveVector = transform.forward * inputMoveDir.y + transform.right * inputMoveDir.x;

        
        transform.position += moveSpeed * Time.deltaTime * moveVector;

        if (transform.position.x < BoundX.position.x)
        {
            transform.position = new Vector3 (BoundX.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > BoundX1.position.x)
        {
            transform.position = new Vector3(BoundX1.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.z < BoundZ.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, BoundZ.position.z);
        }

        if (transform.position.z > BoundZ1.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, BoundZ1.position.z);
        }
    }

  

    private void CameraRotating()
    {
        rotationVector.y = InputManager.Instance.GetCameraRotateAmount();

        transform.eulerAngles += rotationSpeed * Time.deltaTime * rotationVector;
    }

 
}
