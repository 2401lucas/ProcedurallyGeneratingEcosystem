using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpdatableData), true)]
public class UpdateDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UpdatableData updatableData = (UpdatableData) target;

        if (GUILayout.Button("Update"))
        {
            updatableData.NotifyOfUpdatedValues();
            EditorUtility.SetDirty(target);
        }
    }
}
