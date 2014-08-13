using UnityEngine;
using System.Collections;

public class ChangeMusicVolume : MonoBehaviour {

	public bool remove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float Chose(float x){
		float v = x;
		if(!remove){
			if(v<1.0f){
				v+=0.1f;
			}
			else{
				v = 1.0f;
			}
			return v;
		}
		else{
			if(v>0.0f){
				v-=0.1f;
			}
			else{
				v = 0.0f;
			}
			return v;
		}
	}
}
