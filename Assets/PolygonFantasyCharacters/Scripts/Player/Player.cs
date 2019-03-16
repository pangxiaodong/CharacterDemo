using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterData m_charData;
    public SkinnedMeshRenderer m_skinRender;
    public Transform m_spine;
    public int m_charIndex;

    public void ChangeMat(int index)
    {
        m_skinRender.material = m_charData.m_charMats[index];
    }
}
