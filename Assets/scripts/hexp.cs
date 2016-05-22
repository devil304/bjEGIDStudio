using UnityEngine;
using System.Collections;

public class hexp : MonoBehaviour {
	public float morale;
	public float economy;
	public float maxlud;
	public float lud;
	public GameObject ow;
	public int x;
	public int y;
	public float costr;
	void Start(){
		morale = Random.Range(1,10);
		economy = Random.Range(1,10);
		maxlud = Random.Range(1,12);
		while(lud > maxlud){
			lud = Random.Range(1,10);
		}
	}
	void Update(){
		if (!ow) {
			costr = (morale + economy + maxlud + lud);
		} else if (ow.name == "Player") {
			costr = (morale + economy + maxlud + lud) * (ow.GetComponent<player> ().economy / 10);
		} else if (ow.name == "E1" || ow.name == "E2" || ow.name == "E3") {
			costr = (morale + economy + maxlud + lud) * (ow.GetComponent<ai> ().economy / 10);
		} else {
			costr = (morale + economy + maxlud + lud);
		}
	}
	public void Przejecie(string nazw,Color nc,GameObject owner){
		if (ow) {
			this.gameObject.name = nazw;
			this.transform.GetChild (0).transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
			ow = owner;
			float[] tmpx = new float[4];
			tmpx [2] = maxlud;
			tmpx [3] = economy;
			owner.SendMessage ("add", tmpx);
		} else {
			this.gameObject.name = nazw;
			this.transform.GetChild (0).transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
			ow = owner;
			float[] tmpx = new float[4];
			tmpx [2] = maxlud;
			tmpx [3] = economy;
			owner.SendMessage ("add", tmpx);
		}
	}
	public void up(){
		if (ow.name == "Player") {
			if (lud >= maxlud) {
				lud = maxlud;
			} else {
				if ((lud * ((int)ow.gameObject.GetComponent<player> ().morale / 100F)) == 0) {
					if ((lud * ((int)ow.gameObject.GetComponent<player> ().morale / 75F)) == 0) {
						if ((lud * ((int)ow.gameObject.GetComponent<player> ().morale / 50F)) == 0) {
							lud += 0.25F;
						} else {
							lud += (lud * ((int)ow.gameObject.GetComponent<player> ().morale / 50F)) / 2;
						}
					} else {
						lud += (lud * ((int)ow.gameObject.GetComponent<player> ().morale / 75F)) / 2;
					}
				} else {
					lud += (lud * ((int)ow.gameObject.GetComponent<player> ().morale / 100F)) / 2;
				}
			}
			if (lud >= maxlud) {
				lud = maxlud;
			}
			ow.gameObject.GetComponent<player> ().actlud += lud;
			if (ow.gameObject.GetComponent<player> ().trigerrr == true) {
				if (morale > 0) {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				} else {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				}
			} else {
				if (morale > 0) {
					morale += (lud / 100F) * (ow.gameObject.GetComponent<player> ().economy / 100F);
				}
				if (morale <= 0) {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				}
			}
			ow.gameObject.GetComponent<player> ().morale += morale;
		} else {
			if (lud >= maxlud) {
				lud = maxlud;
			} else {
				if ((lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 100F)) == 0) {
					if ((lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 75F)) == 0) {
						if ((lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 50F)) == 0) {
							lud += 0.25F;
						} else {
							lud += (lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 50F)) / 2;
						}
					} else {
						lud += (lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 75F)) / 2;
					}
				} else {
					lud += (lud * ((int)ow.gameObject.GetComponent<ai> ().morale / 100F)) / 2;
				}
			}
			if (lud >= maxlud) {
				lud = maxlud;
			}
			ow.gameObject.GetComponent<ai> ().actlud += lud;
			if (ow.gameObject.GetComponent<ai> ().trigerrr == true) {
				if (morale > 0) {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				} else {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				}
			} else {
				if (morale > 0) {
					morale += (lud / 100F) * (ow.gameObject.GetComponent<ai> ().economy / 100F);
				}
				if (morale <= 0) {
					morale -= (lud * (1F / 5F)) * (morale / 10F);
				}
			}
			ow.gameObject.GetComponent<ai> ().morale += morale;
		}
	}
	public void korektax(){
		if (this.name == "E1") {
			this.name = "e1";
		} else if (this.name == "E2") {
			this.name = "e2";
		} else if (this.name == "E3") {
			this.name = "e3";
		}
	}
}
