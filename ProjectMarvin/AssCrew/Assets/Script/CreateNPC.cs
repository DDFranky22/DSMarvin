using UnityEngine;
using System.Collections;

public class CreateNPC : MonoBehaviour {

	public GameObject playerPrefab;
	public NetworkManager netManager;

	// Use this for initialization
	IEnumerator InstantiateNetworkingNPC () {
		while(Network.connections.Length<=0){
			print ("No connection avaiable");
			yield return new WaitForSeconds(0.5f);
		}
		while(netManager==null){
			netManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		}
		yield return new WaitForSeconds(3.0f);
		if(Network.connections.Length>0&&Network.isServer){
			for(int i = 0;i<netManager.getNpcNumber();i++)
				Network.Instantiate(playerPrefab, new Vector3(Random.Range(-17.0f,17.0f),0.0f, Random.Range(-10.0f,10.0f)),Quaternion.identity,0);
		}
	}

	void Start(){
		StartCoroutine(InstantiateNetworkingNPC());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
