using UnityEngine;

namespace WeirdMeshTool
{
    public class Shape
    {
        public int SegmentsCount;
        public float SegmentsT;
        public float Radius;
        
        public Shape()
        {
            SegmentsCount = 1;
            SegmentsT = 0;
            Radius = 1;
        }
        public Shape(int segmentsCount, float segmentsT, float radius)
        {
            SegmentsCount = segmentsCount;
            SegmentsT = segmentsT;
            Radius = radius;
        }
    }
}