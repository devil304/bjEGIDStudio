using UnityEngine;
using System.Collections;

public class worldcontroller : MonoBehaviour {
	public ai[] ais;
	public bool pt = true;
	public bool rt = false	;
	public int tc = 1;
	public GameObject[] hexys;
	public GameObject play;
	public float sec;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ais.Length < 3 || !play || ais.Length >= 4) {
			GameObject[] enemys = GameObject.FindGameObjectsWithTag ("Menemy");
			play = GameObject.FindGameObjectWithTag ("player");
			ais = new ai[enemys.Length];
			for (int i = 0; i < enemys.Length; i++) {
				ais [i] = enemys [i].GetComponent<ai> ();
			}
			if (ais.Length < 3 || !play || ais.Length >= 4) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
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
		sec += Time.deltaTime;
	}
}
