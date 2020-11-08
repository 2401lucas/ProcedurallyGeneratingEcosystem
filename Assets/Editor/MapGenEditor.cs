using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGen))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelGen levelGen = (LevelGen)target;
        if (DrawDefaultInspector())
            if (levelGen.autoUpdate)
                levelGen.DrawMapInEditor();

        if (GUILayout.Button("Generate"))
            levelGen.DrawMapInEditor();
    }
}
