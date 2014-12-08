using UnityEngine;
using System.Collections;

public class ChangeSpriteWithController : MonoBehaviour {

	private GUITexture texture;

	public Texture2D[] img;

	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture>();
		if(Input.GetJoystickNames().Length>0){
			texture.texture = img[0];
		}
		else{
			texture.texture = img[1];
			this.transform.localScale = new Vector2(0.6f,0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
