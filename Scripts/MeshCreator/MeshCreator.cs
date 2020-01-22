using UnityEngine;

namespace WeirdMeshTool
{
    public class MeshCreator : MonoBehaviour
    {
        public float radius;
        public int smoothness;
        
        public void CreateCircle()
        {
            GameObject go = new GameObject();
            go.name = "Circle";
            MeshFilter mf = go.AddComponent<MeshFilter>();
            mf.mesh = MeshCreatorStatic.CreateCircle(Vector3.zero, radius, smoothness);
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
        }

        public void CreateRectangle()
        {
            Vector3[] m = new Vector3[10];
            Vector3[] n = new Vector3[10];

            for (int i = 0; i < 10; i++)
            {
                m[i] = new Vector3(i, 5, 0);
                n[i] = new Vector3(i, -5, -5);
            }
            GameObject go = new GameObject();
            go.name = "Rectangle";
            MeshFilter mf = go.AddComponent<MeshFilter>();
            mf.mesh = MeshCreatorStatic.CreateRectangle(m, n);
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
        }

        public void CreateSylinder()
        {
            GameObject go = new GameObject();
            go.name = "Sylinder";
            MeshFilter mf = go.AddComponent<MeshFilter>();
            mf.mesh = MeshCreatorStatic.CreateSylinder(Vector3.zero, 5, 10);
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
        }
    }   
}