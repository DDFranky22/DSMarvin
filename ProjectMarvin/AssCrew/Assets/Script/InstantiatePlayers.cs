using UnityEngine;
using System.Collections;

public class InstantiatePlayers : MonoBehaviour {

	public GameObject playerPrefab;
	public CheckingStatePlayer check;
	public GameObject CheckingVictory;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAllPlayers());
		//check = GameObject.Find("NetworkManager").GetComponent<CheckingStatePlayer>();
	}

	IEnumerator WaitAllPlayers(){
		if(Network.isServer)
			Network.Instantiate(CheckingVictory,this.transform.position,Quaternion.identity,0);
		for(int i = 1;i<3;i++){
			yield return new WaitForSeconds(1.0f);
		}
		check = GameObject.Find("NetworkManager").GetComponent<CheckingStatePlayer>();
		if(check.Player){
			yield return new WaitForSeconds(3.0f);
			Vector3 StartPosition = new Vector3(Random.Range(-17.0f,17.0f),0.1f, Random.Range(-10.0f,10.0f));
			Network.Instantiate(playerPrefab, StartPosition,Quaternion.identity,0);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
