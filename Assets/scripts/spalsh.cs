using UnityEngine;
using System.Collections;

public class spalsh : MonoBehaviour {
	public float timex;
	public float at;
	public GameObject aa;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		at += Time.deltaTime;
		if (at >= timex) {
			aa.SetActive(true);
			Destroy (this.gameObject);
		} else {
			aa.SetActive(false);
		}
	}
}
