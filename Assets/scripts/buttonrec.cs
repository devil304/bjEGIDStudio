using UnityEngine;
using System.Collections;

public class buttonrec : MonoBehaviour {
	public string target;
	public GameObject what;
	public void rec(){
		what.SendMessage (target);
	}
}
