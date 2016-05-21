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
		if (GameObject.Find ("e1") && Vector2.Distance (this.transform.position, GameObject.Find ("e1").transform.position) > mindys && Vector2.Distance (this.transform.position, GameObject.Find ("e1").transform.position) < maxdys) {
			tak [1] = true;
		} else if (!GameObject.Find ("e1")) {
			tak [1] = true;
		}
		if(GameObject.Find("e2") && Vector2.Distance(this.transform.position,GameObject.Find("e2").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("e2").transform.position)<maxdys){
			tak [2] = true;
		} else if (!GameObject.Find ("e2")) {
			tak [2] = true;
		}
		if(GameObject.Find("Player") && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)<maxdys){
			tak [0] = true;
		} else if (!GameObject.Find ("player")) {
			tak [0] = true;
		}
		if(GameObject.Find("e3") && Vector2.Distance(this.transform.position,GameObject.Find("e3").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("e3").transform.position)<maxdys){
			tak [3] = true;
		} else if (!GameObject.Find ("e3")) {
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
				Instantiate (gracze [i % 50], this.transform.position, gracze [i % 50].transform.rotation);
				this.GetComponent<hexp>().Przejecie (nazwa [i % 50], cr [i % 50]);
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		tak = new bool[4];
		int i = Random.Range (0, 100);
		if (GameObject.Find ("e1") && Vector2.Distance (this.transform.position, GameObject.Find ("e1").transform.position) > mindys && Vector2.Distance (this.transform.position, GameObject.Find ("e1").transform.position) < maxdys) {
			tak [1] = true;
		} else if (!GameObject.Find ("e1")) {
			tak [1] = true;
		}
		if(GameObject.Find("e2") && Vector2.Distance(this.transform.position,GameObject.Find("e2").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("e2").transform.position)<maxdys){
			tak [2] = true;
		} else if (!GameObject.Find ("e2")) {
			tak [2] = true;
		}
		if(GameObject.Find("Player") && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("Player").transform.position)<maxdys){
			tak [0] = true;
		} else if (!GameObject.Find ("player")) {
			tak [0] = true;
		}
		if(GameObject.Find("e3") && Vector2.Distance(this.transform.position,GameObject.Find("e3").transform.position)>mindys && Vector2.Distance(this.transform.position,GameObject.Find("e3").transform.position)<maxdys){
			tak [3] = true;
		} else if (!GameObject.Find ("e3")) {
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
				Instantiate (gracze [i % 50], this.transform.position, gracze [i % 50].transform.rotation);
				this.GetComponent<hexp>().Przejecie (nazwa [i % 50], cr [i % 50]);
			}
		}
		Destroy (this);
	}
	void OnMouseDown(){

	}
}
