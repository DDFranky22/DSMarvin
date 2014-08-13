using UnityEngine;
using System.Collections;

public class SpawnOwnBar : MonoBehaviour {

	public GameObject prefab;
	public LMPlayerMovement scriptMovement;
	private GUITexture scriptTexture;
	private GameObject Indicator;
	private GameObject Bar;
	private GUIText scriptText;
	private LMGameSettings settings;
	// Use this for initialization
	void Start () {
		settings = GameObject.Find ("GameSettingsManager").GetComponent<LMGameSettings> ();
		scriptMovement = GetComponent<LMPlayerMovement> ();
		Indicator = Instantiate(prefab, prefab.transform.position, Quaternion.identity) as GameObject;
		Bar = Indicator.transform.GetChild(0).gameObject;
		scriptMovement.BarObject = Bar;
		scriptTexture = Bar.GetComponent<GUITexture> ();
		int PlayerNumber = scriptMovement.Number;
		scriptText = Indicator.GetComponent<GUIText> ();
		scriptText.text = "Player "+(PlayerNumber+1);
		switch (PlayerNumber) {
		case 0:
			if(settings.GetTeam()){
				scriptText.color = Color.blue;
			}
			Indicator.transform.position = new Vector3(0.08f,0.22f);
			break;
		case 1:
			if(settings.GetTeam()){
				scriptText.color = Color.red;
			}
			Indicator.transform.position = new Vector3(0.75f,0.22f);
			break;
		case 2:
			if(settings.GetTeam()){
				scriptText.color = Color.green;
			}
			Indicator.transform.position = new Vector3(0.08f,0.13f);
			break;
		case 3:
			if(settings.GetTeam()){
				scriptText.color = Color.black;
			}
			Indicator.transform.position = new Vector3(0.75f,0.13f);
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
