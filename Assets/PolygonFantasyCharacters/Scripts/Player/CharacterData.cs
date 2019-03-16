using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MyAssets/CharacterData")]
public class CharacterData : ScriptableObject
{
    public GameObject[] m_charPrefabs;
    public Material[] m_charMats;
}
