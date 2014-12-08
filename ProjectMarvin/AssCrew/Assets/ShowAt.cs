using UnityEngine;
using System.Collections;

public class ShowAt : MonoBehaviour {
	public float start;
	public float fadeInTime;
	public GUIText text;
	// Use this for initialization
	void Start () {
		text = GetComponent<GUIText>();
		text.enabled = false;
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn(){
		yield return new WaitForSeconds(start);
		text.enabled = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
