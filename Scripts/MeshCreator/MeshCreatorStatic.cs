using UnityEngine;

namespace WeirdMeshTool
{
    public static class MeshCreatorStatic
    {
        public static Mesh Create2dMesh(Vector3[] points)
        {
            int triangleNumber = points.Length;
            Vector3[] vertices = new Vector3[triangleNumber + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            Vector3[] normals = new Vector3[vertices.Length];

            int[] tris = new int[triangleNumber * 3];

            // vertices & normals
            for (int i = 0; i < vertices.Length; i++)
            {
                if (i == 0)
                {
                    vertices[i] = new Vector3(0, 0, 0);
                }
                else
                {
                    vertices[i] = points[i - 1];
                }
                normals[i] = Vector3.back;

                // CreateSphere(vertices[i], "v" + i);
            }

            // uv
            float uvPart = 1 / ((float)triangleNumber / 2);
            uv[0] = new Vector2(0.5f, 0.5f);
            for (int i = 1; i <= triangleNumber / 2; i++)
            {
                uv[i] = new Vector2(uvPart * i, uv[i].y);

                uv[i + (triangleNumber / 2)] = new Vector2(1 - uvPart * i, uv[i].y);
            }
            for (int i = 1; i <= triangleNumber / 2; i++)
            {
                uv[i + (triangleNumber / 4)] = new Vector2(uv[i].x, 1 - uvPart * i);
            }
            for (int i = 1; i <= triangleNumber / 4; i++)
            {
                uv[i] = new Vector2(uv[i].x, uvPart * i + 0.5f);
            }
            for (int i = 1; i <= triangleNumber / 4; i++)
            {
                uv[i + (triangleNumber / 4) * 3] = new Vector2(uv[i].x, uvPart * i + 0.5f);
            }

            // triangles
            int j = 0;
            for (int i = 1; i <= triangleNumber; i++)
            {
                tris[j] = i;
                tris[j + 1] = 0;
                if (i == triangleNumber)
                    tris[j + 2] = 1;
                else
                    tris[j + 2] = i + 1;

                j += 3;
            }
            
            var mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = tris;
            mesh.normals = normals;
            mesh.uv = uv;
            
            return mesh;
        }

        public static Mesh Create3dMesh(Vector3[] surfacePoints, float height)
        {
            Mesh surface1 = Create2dMesh(surfacePoints);
            Vector3[] surfacePoints2 = new Vector3[surfacePoints.Length];
            for (int i = 0; i < surfacePoints.Length; i++)
                surfacePoints2[i] = surfacePoints[i] + new Vector3(0, 0, height);
            Mesh surface2 = Create2dMesh(surfacePoints2);
            Mesh body = CreateRectangle(surfacePoints, surfacePoints2);

            CombineInstance[] combine = new CombineInstance[3];
            combine[0].mesh = surface1;
            combine[1].mesh = body;
            combine[2].mesh = surface2;

            combine[0].transform = Matrix4x4.zero;
            combine[1].transform = Matrix4x4.zero;
            combine[2].transform = Matrix4x4.zero;
            
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine, true, false);
            return mesh;
        }

        public static Mesh CreateRectangle(Vector3[] m, Vector3[] n)
        {
            // vertices & uvs
            Vector3[] vertices = new Vector3[m.Length + n.Length];
            Vector2[] uv = new Vector2[vertices.Length];
            Vector3[] normals = new Vector3[vertices.Length];
            float eachTriangleX = 1f / (float)(m.Length - 1);
            for (int i = 0; i < m.Length; i++)
            {
                vertices[i] = m[i];
                uv[i] = new Vector2(i * eachTriangleX , 0f);
                normals[i] = Vector3.back;

                vertices[i + m.Length] = n[i];
                uv[i + m.Length] = new Vector2(i * eachTriangleX , 1f);
                normals[i + m.Length] = Vector3.back;
                // CreateSphere(vertices[i], "vertice-" + i);
                // CreateSphere(vertices[i + m.Length], "vertice-" + (i + m.Length));
            }

            int[] tris = new int[(m.Length - 1) * 6];
            int j = 0;
            for (int i = 0; i < m.Length - 1; i++)
            {
                tris[j] = i;
                tris[j + 1] = i + 1;
                tris[j + 2] = i + 1 + m.Length;
                tris[j + 3] = i + 1 + m.Length;
                tris[j + 4] = i + m.Length;
                tris[j + 5] = i;

                j += 6;
            }

            var mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = tris;
            mesh.normals = normals;
            mesh.uv = uv;

            return mesh;
        }

        public static Mesh CreateCircle(Vector3 center, float radius, int triangleNumber = 12)
        {
            Vector3[] circlePoints = GetCirclePoints(center, radius, triangleNumber);
            return Create2dMesh(circlePoints);
        }

        public static Mesh CreateSylinder(Vector3 center, float radius, float height, int smoothness = 12)
        {
            Vector3 center1 = center + new Vector3(0, 0, 0);
            Vector3 center2 = center + new Vector3(0, 0, height);

            Mesh circle1 = CreateCircle(center1, radius, smoothness);
            Mesh circle2 = CreateCircle(center2, radius, smoothness);
            Mesh body = CreateRectangle(GetCirclePoints(center1, radius, smoothness), 
                                        GetCirclePoints(center2, radius, smoothness));

            CombineInstance[] combine = new CombineInstance[3];
            combine[0].mesh = circle1;
            combine[1].mesh = body;
            combine[2].mesh = circle2;

            combine[0].transform = Matrix4x4.zero;
            combine[1].transform = Matrix4x4.zero;
            combine[2].transform = Matrix4x4.zero;
            
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine, true, false);
            return mesh;
        }

        public static Vector3[] GetCirclePoints(Vector3 center, float radius, int triangleCount = 12)
        {
            float triangleDegree = 360f / triangleCount;
            Vector3[] pointsv3 = new Vector3[triangleCount + 1];

            for (int i = 0; i < triangleCount + 1; i++)
            {
                pointsv3[i] = new Vector3(center.x + rCos(radius, i * triangleDegree), 
                                        center.y + rSin(radius, i * triangleDegree),
                                        center.z);
            }

            return pointsv3;
        }
        public static Vector3[] GetCirclePointsByDegree(Vector2 center, float radius, int degree = 360, float z = 0)
        {
            int segmentDegree = 360 / degree;
            Vector3[] pointsv3 = new Vector3[degree + 1];

            for (int i = 0; i < degree + 1; i++)
            {
                pointsv3[i] = new Vector3(center.x + rCos(radius, i * segmentDegree), 
                                        center.y + rSin(radius, i * segmentDegree),
                                        z);
            }

            return pointsv3;
        }

        private static float rCos(float r, float angle)
        {
            return r * Mathf.Cos(angle * Mathf.Deg2Rad);
        }
        private static float rSin(float r, float angle)
        {
            return r * Mathf.Sin(angle * Mathf.Deg2Rad);
        }
        private static void CreateSphere(Vector3 position, string name)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = position;
            go.name = name;
            go.transform.localScale = Vector3.one * 0.5f;
        }
        private static GameObject GetSphere(Vector3 position, string name)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = position;
            go.name = name;
            go.transform.localScale = Vector3.one * 0.5f;
            return go;
        }
    }    
}