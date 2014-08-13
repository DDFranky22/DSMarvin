using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	public GUIText textscript;

	// Use this for initialization
	void Start () {
		textscript = GetComponent<GUIText>();
		StartCoroutine(CountDown());
	}

	IEnumerator CountDown(){
		for(int i = 0;i<3;i++){
			textscript.text = (3-i)+"";
			yield return new WaitForSeconds(1.0f);
		}
		textscript.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
