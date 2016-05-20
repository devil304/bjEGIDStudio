using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {
	public int def;
	public int morale;
	public int economy;
	public int upmorale;
	public int upeconomy;
	public int uparmy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (def < 0) {
			def = 0;
		}
	}
}
