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
	public bool cb = false;
	public float dys;
	// Use this for initialization
	void Start () {
		d1 = GameObject.Find ("morale").GetComponent<Text> ();
		d2 = GameObject.Find ("ekonomia").GetComponent<Text> ();
		d3 = GameObject.Find ("ludnosc").GetComponent<Text> ();
		hxp = transform.parent.GetComponent<hexp> ();
		GameObject lol = GameObject.Find("Player");
		pp = lol.GetComponent<player>();
		d1.text = ((int)hxp.morale).ToString ();
		d2.text = ((int)hxp.economy).ToString ();
		d3.text = ((int)hxp.lud).ToString ();
		d4.text = ((int)hxp.maxlud).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		cos = pp.hexas.Length * (hxp.costr/125);
		d5.text = ((int)cos).ToString ();
	}
	public void pobur(){
		pp.army += this.transform.parent.gameObject.GetComponent<hexp> ().lud * (1 / 3);
		this.transform.parent.gameObject.GetComponent<hexp> ().lud -= this.transform.parent.gameObject.GetComponent<hexp> ().lud * (1 / 3);
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
