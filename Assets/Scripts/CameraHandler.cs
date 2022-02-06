using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    float orthographicSize;
    float targetOrthographicSize;

    void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }
    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float moveSpeed = 20f;
        Vector3 moveDir = new Vector3(x, y).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void HandleZoom()
    {
        float zoomSpeed = 5f;
        float zoomAmount = 2f;
        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targetOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);
        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
