using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomRotation : MonoBehaviour {

	private void Start () {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
	}
	
}
