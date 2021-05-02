using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(VisualNovel))]
public class EditorUpdate : Editor
{
    public override void OnInspectorGUI()
    {
        VisualNovel visual = (VisualNovel)target;

        if (DrawDefaultInspector())
        {
            if (visual.update)
            {
                visual.TextUpdate(false);
            }
        }

        if (GUILayout.Button("Update"))
        {
            visual.TextUpdate(false);
        }
    }
}
