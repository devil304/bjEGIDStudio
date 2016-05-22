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
		tmpx [0] = morale;
		tmpx [2] = maxlud;
		tmpx [3] = economy;
		owner.SendMessage("add",tmpx);
	}
	public void up(){
		lud += lud * (5F / 100F) * (morale / 50F);
		ow.GetComponent<player> ().actlud += lud;
		if (lud > maxlud) {
			lud = maxlud;
		}
	}
}
