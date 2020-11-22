using System;
using UnityEngine;

namespace WeirdMeshTool
{
    public class WeirdMesh : MonoBehaviour
    {
        public int segmentsNum;
        public float segmentT;
        public float radius;
        public float z;

        public void ChangeTheMesh()
        {
            var shape = new Shape(segmentsNum, segmentT, radius);
            Vector3[] surfacePoints = DrawShape.SetUpPoints(shape);
            MeshFilter mf = gameObject.GetComponent<MeshFilter>();
            mf.mesh = MeshCreatorStatic.Create3dMesh(surfacePoints, z);
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
        }
    }
}
