using UnityEngine;
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
		d1 = GameObject.Find ("morale").GetComponent<Text> ();
		d2 = GameObject.Find ("ekonomia").GetComponent<Text> ();
		d3 = GameObject.Find ("ludnosc").GetComponent<Text> ();
		hxp = transform.parent.GetComponent<hexp> ();
		pp = GameObject.Find ("Player").GetComponent<player>();
		d1.text = hxp.morale.ToString ();
		d2.text = hxp.economy.ToString ();
		d3.text = hxp.lud.ToString ();
		d4.text = hxp.maxlud.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		cos = pp.hexas.Length * hxp.costr;
		d5.text = cos.ToString ();
	}
	public void kup(){
		if (cos < pp.GetComponent<player> ().economy) {
			
		}
	}
}
