using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class ai : MonoBehaviour {
	public ui[] u;
	public float def;
	public float morale;
	public float economy;
	public float army;
	public int hep;
	public int activehep;
	public float actlud;
	public float maxactlud;
	public GameObject moje;
	public GameObject[] hexass;
	public GameObject[] phexas;
	// Use this for initialization
	public worldcontroller wc;
	public Color myc;
	public string myn;
	public bool trigerrr;
	public bool tura = false;
	// Use this for initialization

	void Start () {
		hexass = GameObject.FindGameObjectsWithTag ("hex");
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
			tura = false;
			activehep = 1;
			phexas = new GameObject[1];
			hep = 1;
			for (int i = 0; i < hexass.Length; i++) {
				if (hexass [i].tag == "hex" && hexass [i].name == myn) {
					GameObject[] tmpx = new GameObject[phexas.Length];
					for(int j = 0;j<phexas.Length;j++){
						tmpx[j] = phexas[j];
					}
					phexas = new GameObject[hep];
					for(int j = 0;j<tmpx.Length;j++){
						phexas[j] = tmpx[j];
					}
					phexas [hep-1] = hexass [i];
					hep++;
				}
			}
			actlud = 0;
			morale = 0;
			for (int l = 0; l < phexas.Length; l++) {
				if (phexas [l] != null) {
					phexas [l].GetComponent<hexp> ().up ();
				}
			}
			economy += (actlud / 50F) * (economy / 100F) * (morale / 75F);
			if (actlud >= maxactlud) {
				trigerrr = true;
			} else {
				trigerrr = false;
			}
			morale -= army / 100;
		}
	}
	public void add(float[] jej){
		maxactlud += jej[2];
		economy += jej[3];	
	}
}
