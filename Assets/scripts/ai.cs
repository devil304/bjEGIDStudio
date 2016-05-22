using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class ai : MonoBehaviour {
	public float szpiedzy;
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
			if (army <= 0) {
				army = 0;
			}
			hexass = GameObject.FindGameObjectsWithTag ("hex");
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
			economy += ((actlud / 25F) * (economy / 100F) * (morale / 50F))/wc.tc;
			if (actlud >= maxactlud) {
				trigerrr = true;
			} else {
				trigerrr = false;
			}
			morale -= army / 100;
			if (actlud >= maxactlud) {
				float ludnaj = 0;
				int best = 0;
				for(int i=0;i<hexass.Length;i++){
					for (int j = 0; j < phexas.Length; j++) {
						if (Vector2.Distance (hexass[i].transform.position,phexas[j].transform.position) <= 25 && hexass[i].name != myn) {
							if((hexass.Length * (hexass [i].GetComponent<hexp> ().costr/100)) < economy){
								if ((hexass [i].GetComponent<hexp> ().maxlud - hexass [i].GetComponent<hexp> ().lud) > ludnaj) {
									ludnaj = hexass [i].GetComponent<hexp> ().maxlud - hexass [i].GetComponent<hexp> ().lud;
									best = i;
								}
							}
						}
					}
				}
				economy -= phexas.Length * (hexass [best].GetComponent<hexp> ().costr/100);
				hexass [best].GetComponent<hexp> ().Przejecie (myn, myc, this.gameObject);
			} else {
				float ludnaj = 0;
				int best = 0;
				for(int i=0;i<hexass.Length;i++){
					for (int j = 0; j < phexas.Length; j++) {
						if (Vector2.Distance (hexass[i].transform.position,phexas[j].transform.position) <= 25 && hexass[i].name != myn) {
							if((hexass.Length * (hexass [i].GetComponent<hexp> ().costr/100)) < economy){
								if (hexass [i].GetComponent<hexp> ().economy > ludnaj) {
									ludnaj = hexass [i].GetComponent<hexp> ().maxlud - hexass [i].GetComponent<hexp> ().lud;
									best = i;
								}
							}
						}
					}
				}
				economy -= phexas.Length * (hexass [best].GetComponent<hexp> ().costr/100);
				hexass [best].GetComponent<hexp> ().Przejecie (myn, myc, this.gameObject);
			}
			if (actlud > (maxactlud / 4)) {
				int best = 0;
				float jejl = 0;
				for (int j = 0; j < phexas.Length; j++) {
					if (phexas [j].GetComponent<hexp> ().lud > jejl) {
						jejl = phexas [j].GetComponent<hexp> ().lud;
						best = j;
					}
				}
				float tet = phexas[best].GetComponent<hexp> ().lud / 3;
				phexas[best].GetComponent<hexp> ().lud -= tet;
				army += tet;
			}
			GameObject tey = GameObject.Find ("Player");
			if (tey.GetComponent<player> ().economy > economy) {
				for (int y = 0; y < wc.tc; y++) {
					int best = 0;
					float jejl = 0;
					for (int j = 0; j < phexas.Length; j++) {
						if (phexas [j].GetComponent<hexp> ().lud > jejl) {
							jejl = phexas [j].GetComponent<hexp> ().lud;
							best = j;
						}
					}
					float tet = phexas [best].GetComponent<hexp> ().lud / 5;
					economy -= phexas [best].GetComponent<hexp> ().economy;
					phexas [best].GetComponent<hexp> ().lud -= tet;
					army += tet;
				}
				int ghg = Random.Range (0, (int)szpiedzy);
				tey.GetComponent<player> ().economy -= tey.GetComponent<player> ().economy * (ghg / 100);
			}
			int ghgx = Random.Range(0,(1*wc.tc));

		}
	}
	public void add(float[] jej){
		maxactlud += jej[2];
		economy += jej[3];	
	}
}
