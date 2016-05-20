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
	// Use this for initialization
	public worldcontroller wc;
	// Use this for initialization
	void Start () {
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);

		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller>();
	}
	
	// Update is called once per frame
	void Update () {
		def = army * (((2 * morale) + economy)/3);
		if (wc.pt && !wc.rt) {
			wc.rt = true;
		}
		if (wc.pt && wc.rt) {
			if (Input.GetButtonDown ("Jump")) {
				wc.pt = false;
			}
		}
	}
}
