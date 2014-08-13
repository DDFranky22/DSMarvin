using UnityEngine;
using System.Collections;

public class LMGUIVictory : MonoBehaviour {

	private GUIText text;

	// Use this for initialization
	void Start () {
		text = GetComponent<GUIText>();
	}

	public void ShowText(int x){
		text.enabled = true;
		text.text = "Player "+x+" win this round";
	}

	public void ShowTextRound(int x){
		text.enabled = true;
		text.text = "Player "+x+" win the game";
	}

	public void KilledPlayer(int x){
		StartCoroutine(FlashNamePlayer(x));
	}

	IEnumerator FlashNamePlayer(int x){
		text.enabled = true;
		text.text = "Player "+(x+1)+" is dead";
		yield return new WaitForSeconds(2.0f);
		text.text = "";
		text.enabled = false;
	}

}
