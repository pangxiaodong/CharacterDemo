using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 批量设置修改Player.cs脚本
 */
public class PlayerUtil : MonoBehaviour
{
    public CharacterData m_charData;

    public void SetPlayerScript()
    {
        for (int i = 0; i < m_charData.m_charPrefabs.Length; i++)
        {
            // create player script
            //GameObject obj = GameObject.Instantiate(m_charData.m_charPrefabs[i]);
            GameObject obj = m_charData.m_charPrefabs[i];
            Player player = obj.GetComponent<Player>();
            if (player == null)
            {
                player = obj.AddComponent<Player>();
            }

            // fill content of player script
            player.m_charData = m_charData;
            player.m_skinRender = obj.GetComponentInChildren<SkinnedMeshRenderer>();
            player.m_spine = obj.transform.Find("Root/Hips/Spine_01");
            player.m_charIndex = i;
            // save prefab
            // UnityEditor.PrefabUtility.ApplyPrefabInstance(obj, UnityEditor.InteractionMode.AutomatedAction);
            UnityEditor.PrefabUtility.SavePrefabAsset(obj);
            //Destroy(obj);
        }
        Debug.Log("CreatePlayerScript: " + m_charData.m_charPrefabs.Length + " character prefab is processed.");
    }
}
