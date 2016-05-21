using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dymek : MonoBehaviour {
	
	public GameObject puf;

	// Use this for initialization
	void Start () {
		puf = GameObject.Find ("dymek");
		puf.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown(){
		puf.SetActive (!puf.activeSelf);
		}
}