using UnityEngine;
using System.Collections;

public class mdes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject teb = GameObject.Find ("m");
		Destroy (teb);
	}
}
