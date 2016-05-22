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
		costr = (morale + economy + maxlud + lud);
	}
	public void Przejecie(string nazw,Color nc,GameObject owner){
		this.gameObject.name = nazw;
		this.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
		ow = owner;
		float[] tmpx = new float[4];
		tmpx [2] = maxlud;
		tmpx [3] = economy;
		owner.SendMessage("add",tmpx);
	}
	public void up(){
		lud += lud * (5F / 100F) * (ow.gameObject.GetComponent<player> ().morale / 50F);
		if (lud > maxlud) {
			lud = maxlud;
		}
		if (ow.gameObject.GetComponent<player> ().actlud >= ow.gameObject.GetComponent<player> ().maxactlud) {
			if (lud > maxlud) {
				lud = maxlud;
			}
			if (morale > 0) {
				morale -= (lud * (1F / 250F)) * (morale/100F);
			} else {
				morale -= (lud * (1F / 250F)) * (morale/100F);
			}
		}
		if (morale > 0) {
			morale += (lud / 175F) * (ow.gameObject.GetComponent<player> ().economy / 125F);
		}
		if (morale <= 0) {
			morale -= (lud * (1F / 250F)) * (morale/100F);
		}
		ow.gameObject.GetComponent<player> ().morale += morale;
		ow.gameObject.GetComponent<player> ().actlud += lud;
	}
}
