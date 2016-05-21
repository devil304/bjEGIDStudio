using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float zoomSpeed = 2.0f;

	public float minZ = -10.0f;
	public float maxZ = -4.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 10.0f;
	public float sensY = 10.0f;
	public float korekta;

	void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, 0, scroll * zoomSpeed, Space.World);
		if (transform.position.z < maxZ && transform.position.z > minZ) {
			minY -= scroll * korekta * (minY/10);
			minX -= scroll * korekta * (minX / 10);
			maxY += scroll * korekta * (maxY/20);
			maxX += scroll * korekta * (maxX/21);
		}
	
		if (transform.position.z > maxZ) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, maxZ);
		}else if(transform.position.z < minZ) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, minZ);
		}

		if (Input.GetMouseButton (1)) {
			transform.position = new Vector3 (transform.position.x - (Input.GetAxis ("Mouse X") * sensX * Time.deltaTime), transform.position.y, transform.position.z);
			transform.position = new Vector3 (transform.position.x, transform.position.y - (Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime), transform.position.z);
			if (transform.position.x > maxX) {
				transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
			}else if (transform.position.x < minX) {
				transform.position = new Vector3 (minX, transform.position.y, transform.position.z);
			}
			if (transform.position.y > maxY) {
				transform.position = new Vector3 (transform.position.x, maxY, transform.position.z);
			}else if (transform.position.y < minY) {
				transform.position = new Vector3 (transform.position.x, minY, transform.position.z);
			}
		}
	}
}
