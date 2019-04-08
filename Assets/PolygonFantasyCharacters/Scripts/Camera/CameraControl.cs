using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_angleXMin = -50.0f;
    public float m_angleXMax = 50.0f;
    public float m_angleYMin = -50.0f;
    public float m_angleYMax = 50.0f;
    public float m_speedX = 4.0f;
    public float m_speedY = 1.0f;

    public Transform m_lookAt;
    public Transform m_camera;
    public float m_distance = 10.0f;

    private float m_currentX = 0.0f;
    private float m_currentY = 0.0f;

    private void Start()
    {
    }

    private void Update()
    {
        m_currentX += Input.GetAxis("Mouse X") * m_speedX;
        m_currentY += Input.GetAxis("Mouse Y") * m_speedY;
        m_currentX = Mathf.Clamp(m_currentX, m_angleXMin, m_angleXMax);
        m_currentY = Mathf.Clamp(m_currentY, m_angleYMin, m_angleYMax);
    }

    private void LateUpdate()
    {
        if (m_camera != null && m_lookAt != null)
        {
            Vector3 dir = new Vector3(0, 0, m_distance);
            Quaternion rotation = Quaternion.Euler(m_currentY, m_currentX, 0);
            m_camera.position = m_lookAt.position + rotation * dir;
            m_camera.LookAt(m_lookAt.position);
        }
    }
}