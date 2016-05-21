using UnityEngine;
using System.Collections;

public class zoom : MonoBehaviour {
	public float tim;
	public bool mo = false;
	public float spz;
	public float maxup;
	public float sup;
	// Use this for initialization
	void Start () {
		spz = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (!mo && this.transform.position.z < spz) {
			Transform to = this.transform;
			to.Translate(Vector3.forward * tim * sup);
		} else {
			if (this.transform.position.z != spz && !mo) {
				this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,spz);
			}
			mo = false;
		}
		tim = Time.deltaTime;
	}
	void OnMouseOver(){
		mo = true;
		if (this.transform.position.z > spz - maxup) {
			Transform to = this.transform;
			to.Translate(Vector3.back * tim * sup);
		}
	}
}
