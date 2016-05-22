using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
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
	public GameObject[] hexas;
	public GameObject[] phexas;
	// Use this for initialization
	public worldcontroller wc;
	public Color myc;
	public string myn;
	// Use this for initialization
	void Start () {
		this.name = "Player";
		hexas = GameObject.FindGameObjectsWithTag ("hex");
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller>();
		for (int i = 0; i < wc.hexys.Length; i++) {
			if (Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) <= 25F && Vector2.Distance (wc.hexys [i].transform.position, this.transform.position) > 5F) {
				wc.hexys [i].gameObject.GetComponent<hexp> ().Przejecie (myn,myc,this.gameObject);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < u.Length; i++) {
			if (i == 0) {
				u [i] = GameObject.Find ("populacja").GetComponent<ui> ();
				u [i].zmienna = ((int)actlud).ToString();
			}else if (i == 1) {
				u [i] = GameObject.Find ("eko").GetComponent<ui> ();
				u [i].zmienna = ((int)economy).ToString();
			}else if (i == 2) {
				u [i] = GameObject.Find ("pop").GetComponent<ui> ();
				u [i].zmienna = ((int)morale).ToString();
			}
		}
		def = army * (((2 * morale) + economy)/3);
		if (wc.pt && !wc.rt) {
			activehep = 1;
			phexas = new GameObject[1];
			hep = 1;
			for (int i = 0; i < hexas.Length; i++) {
				if (hexas [i].tag == "hex" && hexas [i].name == "player") {
					GameObject[] tmpx = new GameObject[phexas.Length];
					for(int j = 0;j<phexas.Length;j++){
						tmpx[j] = phexas[j];
					}
					phexas = new GameObject[hep];
					for(int j = 0;j<tmpx.Length;j++){
						phexas[j] = tmpx[j];
					}
					phexas [hep-1] = hexas [i];
					hep++;
				}
				actlud = 0;
				morale = 0;
				for (int l = 0; l < phexas.Length; l++) {
					if (phexas [l] != null) {
						phexas [l].GetComponent<hexp> ().up ();
					}
				}
				economy += (actlud / 125F) * (economy / 125F) * (morale / 100F);

				morale -= army / 100;
				wc.rt = true;
			}
		}
	}
	public void turab (){
		if (wc.pt && wc.rt) {
				wc.pt = false;
		}
	}
	public void add(float[] jej){
		maxactlud += jej[2];
		economy += jej[3];
	}
}
