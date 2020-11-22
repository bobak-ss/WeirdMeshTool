using UnityEngine;

namespace WeirdMeshTool
{  
    public class DrawNewShape : MonoBehaviour
    {
        public int segmentsNum;
        public float segmentT;
        public float radius;
        private LineRenderer lineRenderer;

        public void Draw()
        {
            var newGameObject = new GameObject();
            var shape = newGameObject.AddComponent<ShapeMono>();
            lineRenderer = newGameObject.AddComponent<LineRenderer>();
            
            shape.Initialize(segmentsNum, segmentT, radius, lineRenderer);
            
            ModifyLine();
        }

        private void ModifyLine()
        {
            var points = DrawShape.SetUpPoints(segmentsNum, segmentT, radius);
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
            lineRenderer.useWorldSpace = false;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.loop = true;
            lineRenderer.name = "New Shape";
        }
    }
}
