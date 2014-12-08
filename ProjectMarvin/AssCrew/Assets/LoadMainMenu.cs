using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {
	public float load;
	// Use this for initialization
	void Start () {
		StartCoroutine(loadMenu());
	}

	IEnumerator loadMenu(){
		yield return new WaitForSeconds(load);
		Application.LoadLevel("MenuTest");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
