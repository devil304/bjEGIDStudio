using UnityEngine;
using System.Collections;

public class worldcontroller : MonoBehaviour {
	public ai[] ais;
	public bool pt = true;
	public bool rt = false	;
	public int tc = 1;
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
			int cont = 0;
			for (int i = 0; i < ais.Length; i++) {
				if (ais [i].tura) {
					cont++;
				}
				if (cont >= ais.Length) {
					pt = true;
					tc++;
				}
			}
		}
	}
}
