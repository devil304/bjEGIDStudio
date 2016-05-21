using UnityEngine;
using System.Collections;

public class hexp : MonoBehaviour {
	public float morale;
	public float economy;
	public float maxlud;
	public float lud;
	public Color[] cr;
	public string[] nazwa;
	public int x;
	public int y;
	public GameObject[] gracze;
	public bool tak;
	public float mindys;
	// Use this for initialization
	void Start () {
		int i = Random.Range (0, 4);
		if(
		if (!GameObject.Find(gracze[i].name) && !GameObject.FindGameObjectWithTag("player") && tak) {
			Instantiate (gracze [i],this.transform.position,gracze[i].transform.rotation);
			Przejecie (nazwa [i], cr [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int i = Random.Range (0, 4);
		if (!GameObject.Find(gracze[i].name) && !GameObject.FindGameObjectWithTag("player")) {
			Instantiate (gracze [i],this.transform.position,gracze[i].transform.rotation);
			Przejecie (nazwa [i], cr [i]);
		}
	}
	void OnMouseDown(){
		
	}
	void Przejecie(string nazw,Color nc){
		this.gameObject.name = nazw;
		this.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = nc;
	}
}
