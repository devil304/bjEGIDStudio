using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public worldcontroller wc;
	// Use this for initialization
	void Start () {
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
