using UnityEngine;
using System.Collections;

public class OGameCreationMenu : MonoBehaviour {

	private NetworkManager nm;

	public GameObject ServerObjects;
	public GameObject ClientObjects;

	// Use this for initialization
	void Start () {
		nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		if(nm.AmIServer){
			ServerObjects.SetActive(true);
		}
		else{
			ClientObjects.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
