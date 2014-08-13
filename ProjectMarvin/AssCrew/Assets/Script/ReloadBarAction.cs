using UnityEngine;
using System.Collections;

public class ReloadBarAction : MonoBehaviour {

	public GUITexture texture;
	private float DimX;
	private float DimY;
	private float PosX;
	private float PosY;

	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture> ();
		DimX = texture.pixelInset.width;
		DimY = texture.pixelInset.height;
		PosX = texture.pixelInset.x;
		PosY = texture.pixelInset.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CoolDown(){
		for (int i = 0; i<=100.0f; i++) {
			texture.pixelInset = new Rect(PosX,PosY,(i)*(DimX/100),DimY);
			yield return new WaitForSeconds(1.0f/(25.0f*4));
		}
	}

	public void Attacked(){
		StartCoroutine (CoolDown ());
	}

}
