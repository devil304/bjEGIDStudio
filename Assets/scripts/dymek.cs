using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dymek : MonoBehaviour {
	
	public GameObject puf;
	public worldcontroller wc;

	// Use this for initialization
	void Start () {
		wc = GameObject.Find ("Main Camera").GetComponent<worldcontroller> ();
		puf = GameObject.Find ("dymek");
		puf.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown(){
		if (wc.dymkikuwanow && wc.dymkikuwanow != puf) {
			wc.dymkikuwanow.SetActive (false);
			wc.dymkikuwanow = puf;
		} else {
			wc.dymkikuwanow = puf;
		}
		puf.SetActive (!puf.activeSelf);
		}
}