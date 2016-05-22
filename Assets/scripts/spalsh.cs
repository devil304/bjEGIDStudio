using UnityEngine;
using System.Collections;

public class spalsh : MonoBehaviour {
	public float timex;
	public float at;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		at += Time.deltaTime;
		if (at >= timex) {
			Destroy(this.gameObject);
		}
	}
}
