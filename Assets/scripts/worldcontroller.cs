using UnityEngine;
using System.Collections;

public class worldcontroller : MonoBehaviour {
	public ai[] ais;
	public bool pt = true;
	public bool rt = true;
	// Use this for initialization
	void Start () {
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("enemy");
		ais = new ai[enemys.Length];
		for (int i = 0; i < enemys.Length; i++) {
			ais [i] = enemys [i].GetComponent<ai> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!pt && rt) {
			for (int i = 0; i < ais.Length; i++) {
				ais [i].tura = true;
			}
			rt = false;
		}
		if (!pt && !rt) {
		
		}
	}
}
