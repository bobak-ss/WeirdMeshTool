using UnityEngine;

namespace WeirdMeshTool
{
    public class MeshCreator : MonoBehaviour
    {
        public float radius;
        public int smoothness;
        
        public void CreateCircle()
        {
            var newGameObject = new GameObject();
            newGameObject.name = "Circle";
            newGameObject.AddComponent<MeshFilter>().mesh = 
                MeshCreatorStatic.CreateCircle(Vector3.zero, radius, smoothness);
            newGameObject.AddComponent<MeshRenderer>(). material = new Material(Shader.Find("Standard"));
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
            var newGameObject = new GameObject();
            newGameObject.name = "Rectangle";
            newGameObject.AddComponent<MeshFilter>().mesh = MeshCreatorStatic.CreateRectangle(m, n);
            newGameObject.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        }

        public void CreateSylinder()
        {
            GameObject newGameObject = new GameObject();
            newGameObject.name = "Sylinder";
            newGameObject.AddComponent<MeshFilter>().mesh = 
                MeshCreatorStatic.CreateSylinder(Vector3.zero, 5, 10);
            newGameObject.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        }
    }   
}