using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(ShapeMono))]
    public class ShapeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShapeMono shapeMono = (ShapeMono)target;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                shapeMono.shape.SegmentsCount = EditorGUILayout.IntSlider("Segments Num", shapeMono.shape.SegmentsCount, 1, 10);
                shapeMono.shape.SegmentsT = EditorGUILayout.Slider("Segments T", shapeMono.shape.SegmentsT, -10, 10);
                shapeMono.shape.Radius = EditorGUILayout.Slider("Radius", shapeMono.shape.Radius, 1, 10);

                if (check.changed)
                    shapeMono.ChangeTheShape();
            }

            var buttonName = (shapeMono.lineRenderer != null) ? "Apply Changes" : "Create New Shape";
            if (GUILayout.Button(buttonName))
                shapeMono.ChangeTheShape();
        }
    }
}
