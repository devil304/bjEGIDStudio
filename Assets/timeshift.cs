using UnityEngine;
using System.Collections;

public class timeshift : MonoBehaviour {
	struct ts{
		public Vector3 poz;
		public Transform coto;
		public Quaternion rot;
		public Vector2 vel;
		public float av;
	};

	public float timesl = 0;
	public bool tss = false;
	public GameObject[] ok;
	public int ex = 0;
	public bool redy = true;
	public bool more = false;
	ts[,] tims;
	public bool but = false;
	public int actex = 0;
	public Vector2[] lvel;
	public float[] lav;

	// Use this for initialization
	void Start () {
		ok = GameObject.FindGameObjectsWithTag ("ts");
		Debug.Log (ok.Length);
		tims = new ts[ok.Length, 125];
		lvel = new Vector2[ok.Length];
		lav = new float[ok.Length];
	}
	
	// Update is called once per frame
	void Update(){
		for (int i = 0; i < ok.Length; i++) {
			Rigidbody2D rb = ok [i].gameObject.GetComponent<Rigidbody2D> ();
			Debug.Log (rb.velocity);
			Debug.Log (rb.angularVelocity);
		}
		if (Input.GetButtonDown("Jump")) {
			redy = false;
			actex = ex;
			if (!tss && !but) {
				Debug.Log ("zapis");
				tss = true;
				ex -= 1;
				for (int i = 0; i < ok.Length; i++) {
					Rigidbody2D rb = ok [i].gameObject.GetComponent<Rigidbody2D> ();
					Time.timeScale = 0.000001F;
					lvel [i] = rb.velocity;
					lav [i] = rb.angularVelocity;
					Debug.Log ("zapis1");
					Destroy (rb);
					Debug.Log ("zapis2");
				}
				Time.timeScale = 1F;
				but = !but;
			} else if(tss){
				but = !but;
			}
			Debug.Log (ex);
		}
		//Debug.Log (tss);
	}
	void FixedUpdate () {
		timesl += Time.deltaTime;
		if (timesl >= 0.04F) {
			if (ex == tims.GetLength(1)) {
				more = true;
				ex = 0;
			}
			timesl = 0;
			if (!tss) {
				for (int i = 0; i < ok.Length; i++) {
					tims [i, ex].coto = ok [i].transform;
					tims [i, ex].poz = ok [i].transform.position;
					tims [i, ex].rot = ok [i].transform.rotation;
					/*Debug.Log (tims [i, ex].coto);
					Debug.Log(tims[i,ex].coto);
					Debug.Log(tims[i,ex].poz);
					Debug.Log(tims[i,ex].rot);*/
				}
				ex++;
			}
			if (tss) {
				if (ex <= actex) {
					for (int i = 0; i < ok.Length; i++) {
						if(tims [i, ex].coto != null){
						tims [i, ex].coto = ok [i].transform;
						ok [i].transform.position = tims [i, ex].poz;
						ok [i].transform.rotation = tims [i, ex].rot;
						//Debug.Log (tims [i, ex].coto);
						}
					}
					ex--;
					if (ex <= 0) {
						ex = 0;
						if (more == true) {
							ex = tims.GetLength (1) - 1;
						} else {
							tss = false;
							but = false;
							Debug.Log (ex);
						}
					}
				} else if(ex > actex && more == true){
					for (int i = 0; i < ok.Length; i++) {
						if(tims [i, ex].coto != null){
						tims [i, ex].coto = ok [i].transform;
						ok [i].transform.position = tims [i, ex].poz;
						ok [i].transform.rotation = tims [i, ex].rot;
						//Debug.Log (tims [i, ex].coto);
						}
					}
					ex--;
					if (ex <= actex) {
						ex = actex + 1;
						tss = false;
						but = false;
						Debug.Log (ex);
					}
				}
			}
			if (!but && !redy) {
				redy = true;
				Debug.Log ("odczyt");
				for (int i = 0; i < ok.Length; i++) {
					Time.timeScale = 0.000001F;
					Debug.Log ("odczyt2d1");
					Rigidbody2D rb = ok [i].gameObject.AddComponent<Rigidbody2D>();					
					Debug.Log ("odczyt2d2");
					rb.velocity = new Vector2(0,0);
					rb.angularVelocity = 0;
					rb.velocity = lvel[i];
					rb.angularVelocity = lav[i];
				}
				Time.timeScale = 1F;
				tss = false;
			}
		}
	}
}
