using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeirdMeshTool
{
    public class ShapeMono : MonoBehaviour
    {
        [SerializeField]
        public Shape shape = new Shape();
        public LineRenderer lineRenderer;

        public void Initialize(Shape _shape, LineRenderer _lineRenderer)
        {
            shape = _shape;
            lineRenderer = _lineRenderer;
        }

        public void ChangeTheShape()
        {
            Vector3[] newPoints = DrawShape.SetUpPoints(shape);
            
            if (lineRenderer == null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.startWidth = 0.1f;
                lineRenderer.useWorldSpace = false;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.loop = true;
            }
            lineRenderer.positionCount = newPoints.Length;
            lineRenderer.SetPositions(newPoints);
        }
    }
}
