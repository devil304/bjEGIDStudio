using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class worldcontroller : MonoBehaviour {
	public ai[] ais;
	public bool pt = true;
	public bool rt = false	;
	public int tc = 1;
	public ui u;
	public GameObject uk;
	public int tur;
	public GameObject[] hexys;
	public GameObject play;
	public GameObject dymkikuwanow;
	// Use this for initialization
	void Start () {
		hexys = GameObject.FindGameObjectsWithTag ("hex");		
	}
	
	// Update is called once per frame
	void FixedUpdate(){
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
	}
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
					uk = GameObject.Find ("koniec");
					uk.GetComponent<Text>().text = "Gracz";
					tc++;
					u = GameObject.Find ("tura").GetComponent<ui> ();
					u.zmienna = tc.ToString();
				}
			}
		}
	}
}
