using UnityEngine;
using System.Collections;

public class SpawnOwnBarOnline : MonoBehaviour {
	
	public GameObject prefab;
	public PlayerMovement3D scriptMovement;
	private GUITexture scriptTexture;
	private GameObject Indicator;
	private GameObject Bar;
	private GUIText scriptText;
	// Use this for initialization
	void Start () {
		if(networkView.isMine){
			scriptMovement = GetComponent<PlayerMovement3D> ();
			Indicator = Instantiate(prefab, prefab.transform.position, Quaternion.identity) as GameObject;
			Bar = Indicator.transform.GetChild(0).gameObject;
			scriptMovement.BarObject = Bar;
			scriptTexture = Bar.GetComponent<GUITexture> ();
			int PlayerNumber = 2;
			scriptText = Indicator.GetComponent<GUIText> ();
			scriptText.text = "Player";
			switch (PlayerNumber) {
			case 0:
				Indicator.transform.position = new Vector3(0.08f,0.22f);
				break;
			case 1:
				Indicator.transform.position = new Vector3(0.69f,0.22f);
				break;
			case 2:
				Indicator.transform.position = new Vector3(0.08f,0.13f);
				break;
			case 3:
				Indicator.transform.position = new Vector3(0.69f,0.13f);
				break;
			default:
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
