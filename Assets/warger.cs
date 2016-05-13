using UnityEngine;
using System.Collections;

public class warger : MonoBehaviour {
	public float hp = 0;
	public float mp = 0;
	public int id = 0;
	public string[] test;
	public bool taknie;
	public float x = 0;
	public float m = 0;
	// Use this for initialization
	void Start () {
		id = Random.Range (0,100);
		test [0] = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			int hpx = Random.Range (1, 100);
			hp = (float)hpx;
		} else {
			hp-=0.1F;
		}
		if (mp <= 0) {
			int mpx = Random.Range (1, 100);
			mp = (float)mpx;
		} else {
			mp-=0.1F;
		}
		x += Time.deltaTime;
		if(x > 2){
			int e = Random.Range(0,1);
			if(e == 0){
				taknie=true;
			}else{
				taknie=false;
			}
			x=0;
		}
		m += Time.deltaTime;
		if(m > 1.5F){
			int y = Random.Range(1,test.Length);
			test[0]=test[y];
			m=0;
		}
	}
}
