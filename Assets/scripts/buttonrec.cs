using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonrec : MonoBehaviour {
	public GameObject pl;
	void Update(){
		if (!pl) {
			pl = GameObject.Find ("Player");
		}
	}
	public void dawaj(){
		pl.GetComponent<player> ().turab ();
	}
}
