using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(MeshCreator))]
    public class EdtorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            MeshCreator meshCreator = (MeshCreator)target;
            
            meshCreator.radius = EditorGUILayout.FloatField(new GUIContent ("Circle Radius"), meshCreator.radius);
            meshCreator.smoothness = EditorGUILayout.IntField(new GUIContent ("Circle Smoothness"), meshCreator.smoothness);

            if(GUILayout.Button("Build Circle"))
            {
                meshCreator.CreateCircle();
            }
            if(GUILayout.Button("Build Rectangle"))
            {
                meshCreator.CreateRectangle();
            }
            if(GUILayout.Button("Build Sylinder"))
            {
                meshCreator.CreateSylinder();
            }
        }
    }   
}