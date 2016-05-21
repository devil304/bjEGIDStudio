using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ai : MonoBehaviour {
	public float def;
	public float morale;
	public float economy;
	public float army;
	public int hep;
	public int activehep;
	public float acl;
	public float maxacl;
	public GameObject[] hexas;
	public GameObject[] phexas;
	// Use this for initialization
	public worldcontroller wc;
	public bool tura = false;
	public Color myc;
	public string myn;
	// Use this for initialization

	void Start () {
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller> ();
		string my = "(";
		char mc = my[0];
		string[] ssize = this.name.Split(mc);
		this.name = ssize[0];
		for (int i = 0; i < wc.hexys.Length; i++) {
			if (Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) <= 25F && Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) > 5F) {
				wc.hexys [i].gameObject.GetComponent<hexp> ().Przejecie (myn,myc,this.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		def = army * (((2 * morale) + economy)/3);
		if (tura) {
			//tura = false;
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
							for (int x = 0; x < tmpgo.Length; x++) {
								phexas [x] = tmpgo [x];
							}
						}
						phexas [phexas.Length - 1] = hexas [i];
						if (hexas [i].GetComponent<hexp> ().lud < hexas [i].GetComponent<hexp> ().maxlud) {
							activehep++;
						}
					}
				}
				hep = phexas.Length + 1;
			}
		}
	}
	public void add(float[] jej){
		morale += jej[0];
		acl += jej[1];
		maxacl += jej[2];
		economy += jej[3];
	}
}
