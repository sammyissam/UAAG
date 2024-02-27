using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility
{
    public static class Util
    {
        /// <summary>
        /// Goes to next index in the list. When it reaches end of index, it loops if loop = true.
        /// </summary>
        /// <param name="list">The List to iterate through</param>
        /// <param name="index"> The current index position</param>
        /// <param name="loop"> Should it loop</param>
        /// <typeparam name="T">List of some sort</typeparam>
        /// <returns></returns>
        public static int NextIndexInList<T>(List<T> list, int index, bool loop = true)
        {
            if (index + 1 > list.Count - 1)
            {
                return loop ? 0 : index;
            }
            return index + 1;
        }
        /// <summary>
        /// Gets a random point between two Vectors
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Vector3 GetRandomPoint(Vector3 first, Vector3 second)
        {
            float x = Random.Range(first.x, second.x);
            float y = Random.Range(first.y, second.y);
            float z = Random.Range(first.z, second.z);

            return new Vector3(x, y, z);
        }
        
        public static float Sign(float originalNumber, float signedNumber)
        {
            // Check if the original number is negative
            if (originalNumber < 0)
            {
                // Subtract the number to subtract
                return signedNumber * -1;
            }
            // Add the number to add
            return signedNumber;
        }

        public static bool PointVisible(Camera camera, Vector3 vector3, float margin = 0.15f)
        {
            Vector3 v = camera.WorldToScreenPoint(vector3);

            float widthMargin = Screen.width * margin;
            if (v.x < 0 - widthMargin || v.x > Screen.width + widthMargin)
            {
                return false;
            }
            float heightMargin = Screen.height * margin;
            if (v.y < 0 - heightMargin|| v.y > Screen.height + heightMargin)
            {
                return false;
            }

            return true;
        }
    }
}