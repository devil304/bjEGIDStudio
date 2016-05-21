using UnityEngine;
using System.Collections;

public class hexp : MonoBehaviour {
	public float morale;
	public float economy;
	public float maxlud;
	public float lud;
	public int x;
	public int y;
	public void Przejecie(string nazw,Color nc){
		this.gameObject.name = nazw;
		this.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
	}
}
