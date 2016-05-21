using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {
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
	public bool tura = false;
	// Use this for initialization
	void Start () {
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller> ();
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);
	}
	
	// Update is called once per frame
	void Update () {
		def = army * (((2 * morale) + economy)/3);
		if (tura) {
			tura = false;
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
				wc.rt = true;
			}
			if (wc.pt && wc.rt) {
				if (Input.GetButtonDown ("Jump")) {
					wc.pt = false;
				}
			}
		}
	}
}
