﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float def;
	public float morale;
	public float economy;
	public float army;
	public int maxm;
	public int maxa;
	public int maxe;
	public int minm;
	public int mina;
	public int mine;
	public int hep;
	public int activehep;
	public int actlud;
	public int maxactlud;
	public GameObject[] hexas;
	public GameObject[] phexas;
	// Use this for initialization
	public worldcontroller wc;
	public Color myc;
	public string myn;
	// Use this for initialization
	void Start () {
		this.name = "Player";
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);
		hexas = GameObject.FindGameObjectsWithTag ("hex");
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller>();
		for (int i = 0; i < wc.hexys.Length; i++) {
			if (Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) <= 25F && Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) > 5F) {
				wc.hexys [i].gameObject.GetComponent<hexp> ().Przejecie (myn,myc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		def = army * (((2 * morale) + economy)/3);
		if (wc.pt && !wc.rt) {
			activehep = 1;
			phexas = new GameObject[0];
			for (int i = 0; i < hexas.Length; i++) {
				if (hexas [i].tag == "hex" && hexas [i].name == "player") {
					GameObject[] tmpgo = new GameObject[1];
					if (phexas.Length != 0) {
						tmpgo = new GameObject[phexas.Length];
						tmpgo = phexas;
						phexas = new GameObject[phexas.Length + 1];
					} else {
						phexas = new GameObject[1];
					}
					if (phexas.Length > 1) {
						for(int x = 0;x<tmpgo.Length;x++){
							phexas[x] = tmpgo[x];
						}
					}
					phexas [phexas.Length - 1] = hexas [i];
					if (hexas [i].GetComponent<hexp> ().lud < hexas [i].GetComponent<hexp> ().maxlud) {
						activehep++;
					}
				}
			}
			hep = phexas.Length + 1;
			wc.rt = true;
		}
	}
	public void turab (){
		if (wc.pt && wc.rt) {
				wc.pt = false;
		}
	}
}
