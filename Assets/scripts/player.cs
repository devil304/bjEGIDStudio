using UnityEngine;
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
	// Use this for initialization
	void Start () {
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);
		hexas = GameObject.FindGameObjectsWithTag ("hex");
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller>();
	}
	
	// Update is called once per frame
	void Update () {
		activehep = 1;
		def = army * (((2 * morale) + economy)/3);
		if (wc.pt && !wc.rt) {
			int counth = 0;
			for (int i = 0; i < hexas.Length; i++) {
				if (hexas [i].tag == "hex" && hexas [i].name == "player") {

				}
			}
			hep = phexas.Length;
			wc.rt = true;
		}
		if (wc.pt && wc.rt) {
			if (Input.GetButtonDown ("Jump")) {
				wc.pt = false;
			}
		}
	}
}
