using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {
	public AudioClip[] otherClip;
	AudioSource audiox;
	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start () {
		audiox = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audiox.isPlaying && Application.loadedLevelName != "gex") {
			audiox.clip = otherClip [Random.Range (0, otherClip.Length - 1)];
			audiox.Play ();
		} else if(!audiox.isPlaying){
		GameObject tmp = GameObject.Find ("Main Camera");
		if(tmp.GetComponent<worldcontroller>().ais.Length == 3){
			audiox.clip = otherClip [Random.Range (0, otherClip.Length - 1)];
			audiox.Play ();
		}
		}
	}
}
