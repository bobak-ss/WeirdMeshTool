using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(WeirdMesh))]
    public class WeirdMeshEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            WeirdMesh weirdMesh = (WeirdMesh)target;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                weirdMesh.segmentsNum = EditorGUILayout.IntSlider ("Segments Num", weirdMesh.segmentsNum, 0, 10);
                weirdMesh.segmentT = EditorGUILayout.Slider("Segments T", weirdMesh.segmentT, -10, 10);
                weirdMesh.radius = EditorGUILayout.Slider("Radius", weirdMesh.radius, 0, 10);
                weirdMesh.z = EditorGUILayout.Slider("Z", weirdMesh.z, 0, 10);
                
                if (check.changed)
                {
                    Debug.Log("Changed!!");
                    weirdMesh.ChangeTheMesh();
                }
            }

            if (GUILayout.Button("Change New Shape"))
            {
                weirdMesh.ChangeTheMesh();
            }

        }
    }
}
