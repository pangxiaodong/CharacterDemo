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
            GameObject prefab = m_charData.m_charPrefabs[i];
            Player player = prefab.GetComponent<Player>();
            if (player == null)
            {
                player = prefab.AddComponent<Player>();
            }

            // fill content of player script
            player.m_charData = m_charData;
            player.m_skinRender = prefab.GetComponentInChildren<SkinnedMeshRenderer>();
            player.m_spine = prefab.transform.Find("Root/Hips/Spine_01");
            player.m_charIndex = i;

            // create animator script
            Animator animator = prefab.GetComponent<Animator>();
            if (animator == null)
            {
                animator = prefab.AddComponent<Animator>();
            }

            // fill content of animator script
            animator.runtimeAnimatorController = m_charData.m_animatorController;
            animator.applyRootMotion = false;
            // fill content of player script
            player.m_animator = animator;

            // save prefab
            UnityEditor.PrefabUtility.SavePrefabAsset(prefab);
        }
        Debug.Log("CreatePlayerScript: " + m_charData.m_charPrefabs.Length + " character prefab is processed.");
    }
}
