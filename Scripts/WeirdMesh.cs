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

        internal void ChangeTheMesh()
        {
            Vector3[] surfacePoints = DrawShapeStatic.SetUpPoints(segmentsNum, segmentT, radius);
            MeshFilter mf = gameObject.GetComponent<MeshFilter>();
            mf.mesh = MeshCreatorStatic.Create3dMesh(surfacePoints, z);
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
        }
    }
}
