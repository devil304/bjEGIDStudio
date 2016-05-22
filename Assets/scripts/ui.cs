using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ui : MonoBehaviour {
	public Text zamieniana;
	public string zmienna;
	public string podnaz;
	public player pl;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		zami ();
	}
	public void zami(){
		string tmp = podnaz + zmienna;
			zamieniana.text = tmp;
		}
}
