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
	public float cos;
	public player pp;
	// Use this for initialization
	void Start () {
		hxp = transform.parent.GetComponent<hexp> ();
		pp = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		d1.text = hxp.morale.ToString ();
		d2.text = hxp.economy.ToString ();
		d3.text = hxp.lud.ToString ();
		d4.text = hxp.maxlud.ToString ();
		cos = pp.hexas.Length * hxp.costr;
		d5.text = cos.ToString ();
	}
}
