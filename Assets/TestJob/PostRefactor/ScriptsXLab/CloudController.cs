using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField]
    private Cloud m_cloud;
    [SerializeField]
    private Transform[] m_points;
    public Transform m_current { get; private set; }
    private int m_currentIndex = 0;
//    [SerializeField]
    protected Vector3 m_velocity = Vector3.zero;
    [SerializeField]
    [Range(1, 10)]
    private float m_maxSpeed = 7f;
    [SerializeField]
    [Range(.5f, 5)]
    private float m_smoothTime = .5f;


    private void Awake()
    {
        m_cloud.StopRain();
    }

    public void Action()
    {
//        m_cloud.StartRain();

        if (m_current == null)
        {
            Debug.Log("Action");

            m_cloud.StopRain();
            m_current = m_points[m_currentIndex];
            if (++m_currentIndex > m_points.Length)
            {
                m_currentIndex = 0;
            }
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (m_current != null)
        {

            var cloudPos = m_cloud.transform.position;
            var targetPos =  m_current.position; // position - позиция в сцене
            targetPos.y = cloudPos.y;
            //cloudPos = Vector3.Lerp(cloudPos, targetPos, Time.deltaTime * m_speed);
            cloudPos = Vector3.SmoothDamp(cloudPos, targetPos, ref m_velocity, m_smoothTime, m_maxSpeed);
            if (Vector3.Distance(cloudPos, targetPos) < .1f)
            {
                m_current = null;
                OnMoveComplete();
            }
            Debug.Log(cloudPos);

            m_cloud.transform.position = cloudPos;
        }
    }

    private void OnMoveComplete()
    {
        m_cloud.StartRain();
    }
}
