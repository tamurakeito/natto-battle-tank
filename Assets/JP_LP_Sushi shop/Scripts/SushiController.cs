using UnityEngine;
using UnityEngine.AI;

namespace SbbUtutuya
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class SushiController : MonoBehaviour
    {
        [SerializeField]
        Transform[] m_wayPoints = null;

        [SerializeField]
        Transform m_firstWayPoint = null;

        NavMeshAgent m_navMeshAgent = null;
        int m_nextWayPointId = 0;

        void Start()
        {
            m_navMeshAgent = GetComponent<NavMeshAgent>();

            if (m_wayPoints.Length > 0)
            {
                if (m_firstWayPoint)
                {
                    for (int i = 0; i < m_wayPoints.Length; ++i)
                    {
                        if (m_firstWayPoint == m_wayPoints[i])
                        {
                            m_nextWayPointId = i;
                            break;
                        }
                    }
                }
                else
                {
                    m_nextWayPointId = 0;
                }
                m_navMeshAgent.SetDestination(m_wayPoints[m_nextWayPointId].position);
            }
        }

        void Update()
        {
            if (m_wayPoints.Length > 0)
            {
                if (Vector3.Distance(transform.position, m_wayPoints[m_nextWayPointId].position) < 0.5f)
                {
                    ++m_nextWayPointId;
                    if (m_nextWayPointId >= m_wayPoints.Length)
                    {
                        m_nextWayPointId = 0;
                    }
                    m_navMeshAgent.SetDestination(m_wayPoints[m_nextWayPointId].position);
                }
            }
        }
    }
}
