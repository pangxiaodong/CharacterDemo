using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerUtil))]
[CanEditMultipleObjects]
public class PlayerUtilEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerUtil util = target as PlayerUtil;
        if (GUILayout.Button("Set Player Script for Player Prefab"))
        {
            util.SetPlayerScript();
        }
    }
}
