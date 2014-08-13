using UnityEngine;
using System.Collections;

public class CreateThePlayers : MonoBehaviour {
	public NetworkManager scriptNetwork;
	// Use this for initialization
	void Start () {
		scriptNetwork = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
