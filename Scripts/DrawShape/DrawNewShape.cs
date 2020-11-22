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
            var shapeMono = newGameObject.AddComponent<ShapeMono>();
            lineRenderer = newGameObject.AddComponent<LineRenderer>();
            
            var shape = new Shape(segmentsNum, segmentT, radius);
            shapeMono.Initialize(shape, lineRenderer);
            
            ModifyLine();
        }

        private void ModifyLine()
        {
            var shape = new Shape(segmentsNum, segmentT, radius);
            var points = DrawShape.SetUpPoints(shape);
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
