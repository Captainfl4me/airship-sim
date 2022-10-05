using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Rope))]
public class RopeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Rope rope = (Rope) target;
        
        DrawDefaultInspector();
        GUILayout.Space(10);

        if (GUILayout.Button("Update rope"))
        {
            rope.UpdateRope();
        }
    }
}
