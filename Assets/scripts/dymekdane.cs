﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dymekdane : MonoBehaviour {
	public hexp hxp;
	public Text d1;
	public Text d2;
	public Text d3;
	public Text d4;
	public Text d5;
	public double cos;
	public player pp;
	public bool cb = false;
	public float dys;
	public float tet;
	// Use this for initialization
	void Start () {
		d1 = GameObject.Find ("morale").GetComponent<Text> ();
		d2 = GameObject.Find ("ekonomia").GetComponent<Text> ();
		d3 = GameObject.Find ("ludnosc").GetComponent<Text> ();
		hxp = transform.parent.GetComponent<hexp> ();
		GameObject lol = GameObject.Find("Player");
		pp = lol.GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		d1.text = ((int)hxp.morale).ToString ();
		d2.text = ((int)hxp.economy).ToString ();
		d3.text = ((int)hxp.lud).ToString ();
		d4.text = ((int)hxp.maxlud).ToString ();
		cos = pp.hexas.Length * (hxp.costr/100);
		d5.text = ((int)cos).ToString ();
	}
	public void pobur(){
		if (this.transform.parent.gameObject.name == "player") {
			tet = this.transform.parent.gameObject.GetComponent<hexp> ().lud / 3;
			pp.GetComponent<player> ().army += tet;
			this.transform.parent.gameObject.GetComponent<hexp> ().lud -= tet;
		} else if (this.transform.parent.gameObject.name != "hexp(Clone)") {
			this.transform.parent.gameObject.GetComponent<hexp> ().ow.GetComponent<ai>().army -= pp.GetComponent<player> ().army;
			pp.GetComponent<player> ().army = 0;
		}
	}
	public void szpiegs(){
		if (this.transform.parent.gameObject.name == "player" && pp.GetComponent<player> ().economy > this.transform.parent.gameObject.GetComponent<hexp> ().economy) {
			tet = this.transform.parent.gameObject.GetComponent<hexp> ().lud / 5;
			pp.GetComponent<player> ().szpiedzy += tet;
			this.transform.parent.gameObject.GetComponent<hexp> ().lud -= tet;
			pp.GetComponent<player> ().economy -= this.transform.parent.gameObject.GetComponent<hexp> ().economy;
		} else if (this.transform.parent.gameObject.name != "hexp(Clone)") {
			this.transform.parent.gameObject.GetComponent<hexp> ().ow.GetComponent<ai>().economy -= this.transform.parent.gameObject.GetComponent<hexp> ().economy * (pp.GetComponent<player> ().szpiedzy / 100);
			pp.GetComponent<player> ().szpiedzy = 0;
		}
	}
	public void kup(){
		if (cos < pp.economy) {
			for (int i = 0; i < pp.GetComponent<player> ().phexas.Length; i++) {
				if (Vector2.Distance (pp.GetComponent<player> ().phexas[i].transform.position,this.transform.parent.transform.position) <= 25) {
					dys = Vector2.Distance (pp.GetComponent<player> ().phexas [i].transform.position, this.transform.parent.transform.position);
					cb = true;
				}
			}
			if (cb) {
				pp.GetComponent<player> ().economy -= cos;
				this.transform.parent.gameObject.GetComponent<hexp> ().Przejecie (pp.GetComponent<player> ().myn, pp.GetComponent<player> ().myc, pp.gameObject);
				cb = false;
			}
		}
	}
}
