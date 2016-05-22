using UnityEngine;
using System.Collections;

public class nextlvl : MonoBehaviour {
	public string lel;
	public bool timedx;
	public float howtim;
	float tes = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timedx) {
			tes += Time.deltaTime;
			if (tes >= howtim) {
				Application.LoadLevel (lel);
			}
		}
	}
	public void lodx(){
		Application.LoadLevel (lel);
	}
}
