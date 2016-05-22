using UnityEngine;
using System.Collections;

public class hg : MonoBehaviour {
	public Color[] cr;
	public string[] nazwa;
	public GameObject[] gracze;
	public bool[] tak;
	public float mindys;
	public float maxdys;
	// Use this for initialization
	void Start () {
		tak = new bool[4];
		int i = Random.Range (0, 100);
		if (GameObject.Find ("E1") && Vector2.Distance (this.transform.position, GameObject.Find ("E1").transform.position) > mindys && Vector2.Distance (this.transform.position, GameObject.Find ("E1").transform.position) < maxdys) {
			tak [1] = true;
		} else if (!GameObject.Find ("E1")) {
			tak [1] = true;
		}
		if(GameObject.Find("E2") && Vector2.Distance(this.transform.position,GameObject.Find("E2").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("E2").transform.position)<maxdys){
			tak [2] = true;
		} else if (!GameObject.Find ("E2")) {
			tak [2] = true;
		}
		if(GameObject.Find("Player") && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)<maxdys){
			tak [0] = true;
		} else if (!GameObject.Find ("player")) {
			tak [0] = true;
		}
		if(GameObject.Find("E3") && Vector2.Distance(this.transform.position,GameObject.Find("E3").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("E3").transform.position)<maxdys){
			tak [3] = true;
		} else if (!GameObject.Find ("E3")) {
			tak [3] = true;
		}
		bool takx = true;
		for(int ii = 0;ii<4;ii++){
			if (!tak [ii]) {
				takx = false;
			}
		}
		if (i%50< 4 && takx) {
			if (!GameObject.Find (gracze [i % 50].name) && !GameObject.FindGameObjectWithTag ("player")) {
				Instantiate (gracze [i % 50], this.transform.position, Quaternion.identity);
				this.GetComponent<hexp>().Przejecie (nazwa [i % 50], cr [i % 50],gracze[i%50].gameObject);
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		tak = new bool[4];
		int i = Random.Range (0, 100);
		if (GameObject.Find ("E1") && Vector2.Distance (this.transform.position, GameObject.Find ("E1").transform.position) > mindys && Vector2.Distance (this.transform.position, GameObject.Find ("E1").transform.position) < maxdys) {
			tak [1] = true;
		} else if (!GameObject.Find ("E1")) {
			tak [1] = true;
		}
		if(GameObject.Find("E2") && Vector2.Distance(this.transform.position,GameObject.Find("E2").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("E2").transform.position)<maxdys){
			tak [2] = true;
		} else if (!GameObject.Find ("E2")) {
			tak [2] = true;
		}
		if(GameObject.Find("Player") && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)<maxdys){
			tak [0] = true;
		} else if (!GameObject.Find ("player")) {
			tak [0] = true;
		}
		if(GameObject.Find("E3") && Vector2.Distance(this.transform.position,GameObject.Find("E3").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("E3").transform.position)<maxdys){
			tak [3] = true;
		} else if (!GameObject.Find ("E3")) {
			tak [3] = true;
		}
		bool takx = true;
		for(int ii = 0;ii<4;ii++){
			if (!tak [ii]) {
				takx = false;
			}
		}
		if (i%50< 4 && takx) {
			if (!GameObject.Find (gracze [i % 50].name) && !GameObject.FindGameObjectWithTag ("player")) {
				Instantiate (gracze [i % 50], this.transform.position, Quaternion.identity);
				this.GetComponent<hexp>().Przejecie (nazwa [i % 50], cr [i % 50],gracze[i%50].gameObject);
			}
		}
		Destroy (this);
	}
	void OnMouseDown(){

	}
}
