using UnityEngine;
using System.Collections;

public class hexp : MonoBehaviour {
	public float morale;
	public float economy;
	public float maxlud;
	public float lud = 1000000;
	public GameObject ow;
	public int x;
	public int y;
	void Start(){
		morale = Random.Range(1,10);
		economy = Random.Range(1,10);
		maxlud = Random.Range(1,10);
		while(lud > maxlud){
			lud = Random.Range(1,10);
		}
	}
	public void Przejecie(string nazw,Color nc,GameObject owner){
		this.gameObject.name = nazw;
		this.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
		ow = owner;
		float[] tmpx = new float[4];
		tmpx [0] = morale;
		tmpx [1] = lud;
		tmpx [2] = maxlud;
		tmpx [3] = economy;
		owner.SendMessage("add",tmpx);
	}
}
