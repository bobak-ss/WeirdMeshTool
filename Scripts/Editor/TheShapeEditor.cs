using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(ShapeMono))]
    public class TheShapeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShapeMono shapeMono = (ShapeMono)target;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                shapeMono.segmentsNum = EditorGUILayout.IntSlider("Segments Num", shapeMono.segmentsNum, 1, 10);
                shapeMono.segmentT = EditorGUILayout.Slider("Segments T", shapeMono.segmentT, -10, 10);
                shapeMono.radius = EditorGUILayout.Slider("Radius", shapeMono.radius, 1, 10);

                if (check.changed)
                    shapeMono.ChangeTheShape();
            }

            var buttonName = (shapeMono.lineRenderer != null) ? "Apply Changes" : "Create New Shape";
            if (GUILayout.Button(buttonName))
                shapeMono.ChangeTheShape();
        }
    }
}
