using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private const float MOVE_SPEED = 15;
    private const float ROTATE_SPEED = 3;

    private CharacterController controller;

	private void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	private void Update () {
        controller.SimpleMove(transform.forward * Input.GetAxis("Vertical") * MOVE_SPEED);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * ROTATE_SPEED);
    }
}
