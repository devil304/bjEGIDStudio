using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float speed = 25.0f;
	private float zoomSpeed = 2.0f;

	public float minX = -560.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		if (Input.GetKey(KeyCode.RightArrow)){
				transform.position += Vector3.right * speed * Time.deltaTime;

		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
