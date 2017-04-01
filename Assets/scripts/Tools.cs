using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools {

    /// <summary>
    /// CLamp X, Y and Z of a Vector betwheen 2 numbers.
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="min">Start of the range</param>
    /// <param name="max">End of the range</param>
    /// <returns></returns>
    public static Vector3 Clamp(this Vector3 vec, float min, float max) {
        vec.x = Mathf.Clamp(vec.x, min, max);
        vec.y = Mathf.Clamp(vec.y, min, max);
        vec.z = Mathf.Clamp(vec.z, min, max);

        return vec;
    }


    /// <summary>
    /// Returns the number of what is outside the range. For example. (120, 0, 100) will return 20. (90, 0, 100) will return 0;
    /// </summary>
    /// <param name="num">The number</param>
    /// <param name="min">The start of the range</param>
    /// <param name="max">The end of the tange</param>
    /// <returns>The number that is outdide the range</returns>
    public static float OutsideRange(float num, float min, float max) {
        return num - Mathf.Clamp(num, min, max);
    }

    /// <summary>
    /// Returns the Vector3 of what is outside the range. For example. (new Vector3(120, 90, -5), 0, 100) will return new Vector3(20, 0, -5)
    /// </summary>
    /// <param name="vec">The vector</param>
    /// <param name="min">The start of the range</param>
    /// <param name="max">The end of the tange</param>
    /// <returns>The Vector3 that contains outsided range numbers</returns>
    public static Vector3 OutsideRange(Vector3 vec, float min, float max) {
        return new Vector3(OutsideRange(vec.x, min, max), 
                           OutsideRange(vec.y, min, max), 
                           OutsideRange(vec.z, min, max));
    }
}
