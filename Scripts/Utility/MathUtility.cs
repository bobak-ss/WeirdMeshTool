using System;
using UnityEngine;

namespace WeirdMeshTool
{
    public static class MathUtility
    {
        public static float rCos(float r, float angle)
        {
            return r * Mathf.Cos(angelToRadian(angle));
        }
        public static float rSin(float r, float angle)
        {
            return r * Mathf.Sin(angelToRadian(angle));
        }
        public static float angelToRadian(float angel)
        {
            return ((float)Math.PI * angel) / 180;
        }
    }
   
}