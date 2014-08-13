using UnityEngine;
using System.Collections;

public class RotateCharachter : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine(Rotate ());
	}


	IEnumerator Rotate(){
		while(true){
			this.gameObject.transform.Rotate(new Vector3(0.0f,1.0f));
			yield return new WaitForSeconds(1.0f/24.0f);
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
