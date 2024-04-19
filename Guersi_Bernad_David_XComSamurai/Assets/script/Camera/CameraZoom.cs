using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    private const float minFollowOffset = 2f;
    private const float maxFollowOffset = 25;

    public static CameraZoom Instance { get;set;}

    [Header("Camera Zoom")]
    [Space]

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer cinemachineTransposer;
    private Vector3 targetFollowOffset;

    [Space]

    [SerializeField] float zoomAmount = 1f;
    [SerializeField] float zoomSpeed = 5f;

    private void Awake()
    {
        Instance = this;
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }
    private void Update()
    {
        CameraZooming();
        
    }

    private void CameraZooming()
    {
        targetFollowOffset.y += InputManager.Instance.GetCameraZoomAmount() * zoomAmount;


        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, minFollowOffset, maxFollowOffset);
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);

    }

    public float GetCameraHeight()
    {
        return targetFollowOffset.y;
    }
}
