using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObject : MonoBehaviour {


    private static GameObject managerObject = null;

    /// <summary>
    /// Return a Component that is attacked to the Manager Object 
    /// </summary>
    /// <typeparam name="T">Type of a Component</typeparam>
    /// <returns>Component</returns>
	public static T Find<T>() where T : Component {
        if (managerObject == null) {
            managerObject = GameObject.FindGameObjectWithTag("Managers");
        }
        return (T)managerObject.GetComponent(typeof(T));
    }
}
