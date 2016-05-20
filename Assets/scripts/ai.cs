using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {
	public float def;
	public int morale;
	public int economy;
	public int army;
	public int upmorale;
	public int upeconomy;
	public int uparmy;
	public int maxm;
	public int maxa;
	public int maxe;
	public int minm;
	public int mina;
	public int mine;
	public bool tura = false;
	// Use this for initialization
	void Start () {
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);
	}
	
	// Update is called once per frame
	void Update () {
		def = (morale * economy * army)/1000;
		if (tura) {
			morale += upmorale;
			economy += upeconomy;
			army += uparmy;
			tura = false;
		}
	}
}
