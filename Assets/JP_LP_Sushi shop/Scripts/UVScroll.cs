using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbbUtutuya
{
    public class UVScroll : MonoBehaviour
    {
        [SerializeField]
        Vector2 m_uvScrollSpeed = new Vector2(0.0f, -0.24f);
        Renderer m_renderer = null;

        void Start()
        {
            m_renderer = GetComponent<Renderer>();
        }

        void Update()
        {
            if (m_renderer && m_renderer.material)
            {
                m_renderer.material.mainTextureOffset += m_uvScrollSpeed * Time.deltaTime;
            }
        }
    }
}
