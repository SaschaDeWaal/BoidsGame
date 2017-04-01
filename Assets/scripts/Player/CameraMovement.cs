using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private const float CAMERA_HEIGHT = 3;
    private const float CAMERA_SPEED = 5;
    private const float ROTATION_DEADZONE = 0.1f;

    private GameObject player;
    private GameObject camera;
    private Vector3 lastPosition;
    

	private void Start () {
        player       = GameObject.FindGameObjectWithTag("Player");
        camera       = transform.GetChild(0).gameObject;
        lastPosition = player.transform.position;
    }
	
	private void Update () {
        PlayerRotation();
        CameraRotation();
    }

    private void PlayerRotation() {
        Vector3 point   = player.transform.position;
        Vector3 moveDir = lastPosition - player.transform.position;
       
        if(moveDir.x != 0 || moveDir.z != 0) {
            float angle = Quaternion.Dot(transform.rotation, player.transform.rotation);

            if(Mathf.Abs(angle) > ROTATION_DEADZONE) {
                player.transform.RotateAround(point, new Vector3(0, -angle, 0), Time.deltaTime * 150);

                //we need to move the camera the other direction because the camera is a child of the player.
                transform.RotateAround(point, new Vector3(0, angle, 0), Time.deltaTime * 150);
            }
        }

        lastPosition = player.transform.position;
    }

    private void CameraRotation() {
        Vector3 point = player.transform.position;
        transform.RotateAround(point, new Vector3(0, 1, 0), Time.deltaTime * 100 * Input.GetAxis("Mouse X"));
        camera.transform.RotateAround(point, camera.transform.right * -1, Time.deltaTime * 100 * Input.GetAxis("Mouse Y"));
    }
}
