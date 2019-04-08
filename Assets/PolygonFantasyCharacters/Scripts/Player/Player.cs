using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterData m_charData;
    public SkinnedMeshRenderer m_skinRender;
    public Animator m_animator;
    public Transform m_spine;
    public int m_charIndex;

    public void ChangeMat(int index)
    {
        m_skinRender.material = m_charData.m_charMats[index];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_animator.Play("Idle");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            m_animator.Play("Run");
        }
    }
}
