using UnityEngine;
using System.Collections;

public class hexp : MonoBehaviour {
	public float morale;
	public float economy;
	public float maxlud;
	public float lud;
	public Color[] cr;
	public string[] nazwa;
	// Use this for initialization
	void Start () {
		int i = Random.Range (0, 4);
		Przejecie (nazwa [i], cr [i]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		
	}
	void Przejecie(string nazw,Color nc){
		this.gameObject.name = nazw;
		this.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
	}
}
