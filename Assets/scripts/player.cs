using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
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
	public GameObject[] hexas;
	public GameObject[] phexas;
	// Use this for initialization
	public worldcontroller wc;
	public Color myc;
	public string myn;
	public bool trigerrr;
	public int lc;
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
				u [i].zmienna = ((int)actlud).ToString ();
			} else if (i == 1) {
				u [i] = GameObject.Find ("eko").GetComponent<ui> ();
				u [i].zmienna = ((int)economy).ToString ();
			} else if (i == 2) {
				u [i] = GameObject.Find ("pop").GetComponent<ui> ();
				u [i].zmienna = ((int)morale).ToString ();
			}
		}
		GameObject tmpxv = GameObject.Find ("sz");
		tmpxv.GetComponent<Text> ().text = ((int)szpiedzy).ToString();
		GameObject tmpv = GameObject.Find ("rz");
		tmpv.GetComponent<Text> ().text = ((int)army).ToString();
		def = army * (((2 * morale) + economy)/3);
		if (wc.pt && !wc.rt) {
			if (army <= 0) {
				army = 0;
			}
			hexas = GameObject.FindGameObjectsWithTag ("hex");
			wc.rt = true;
			activehep = 1;
			phexas = new GameObject[1];
			hep = 1;
			for (int i = 0; i < hexas.Length; i++) {
				if (hexas [i].tag == "hex" && hexas [i].name == myn) {
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
			}
			actlud = 0;
			morale = 0;
			for (int l = 0; l < phexas.Length; l++) {
				if (phexas [l] != null) {
					phexas [l].GetComponent<hexp> ().up ();
				}
			}
			economy += (actlud / 10F) * (economy / 75F) * (morale / 25F);
			if (actlud >= maxactlud) {
				trigerrr = true;
			} else {
				trigerrr = false;
			}
			morale -= army / 100;
			if(wc.tc > 5){
			if (phexas.Length < 3 || actlud <= 0 || economy <= 0 || morale <= 0) {
				Application.LoadLevel (lc);
			}
			if (phexas.Length > hexas.Length) {
				Application.LoadLevel (lc+1);
			}
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
