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
	public bool tura = false;
	// Use this for initialization
	void Start () {
		morale = Random.Range (minm, maxm);
		economy = Random.Range (mine, maxe);
		army = Random.Range (mina, maxa);
	}
	
	// Update is called once per frame
	void Update () {
		def = army * (((2 * morale) + economy)/3);
		if (tura) {
			tura = false;
		}
	}
}
