using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(TimeWarper))]
public class TimeWarpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TimeWarper warp = (TimeWarper)target;EditorGUILayout.IntField("Selected Factor Index", warp.selectedFactorIndex);
        EditorGUILayout.LabelField("Current Warp", warp.currentWarp.ToString());
    }
}
