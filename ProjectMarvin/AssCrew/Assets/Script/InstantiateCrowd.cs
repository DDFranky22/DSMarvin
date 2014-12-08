using UnityEngine;
using System.Collections;

public class InstantiateCrowd : MonoBehaviour {
	public GameObject crowdPrefab;
	public int numberOfPeople;
	public Vector3 limits;


	public string[] bannedScene;

	public string CurrentLevel;
	public string PreviousLevel;

	void Generate () {
		foreach(string banned in bannedScene){
			if(Application.loadedLevelName==banned){
				return;
			}
		}
		GameObject[] crowd = GameObject.FindGameObjectsWithTag("NPCMenu");
		if(crowd.Length==0){
			for(int i = 0; i<numberOfPeople; i++){
				Vector3 randomPos = new Vector3(Random.Range(-limits.x,limits.x),0.0f,Random.Range(-limits.z,limits.z));
				Instantiate(crowdPrefab,randomPos,Quaternion.identity);
			}
		}
	}

	public void Start(){
		PreviousLevel = CurrentLevel = Application.loadedLevelName;
		Generate();
	}

	public void Update(){
		if(CurrentLevel=="MenuTest"&&PreviousLevel!="MenuTest"){
			Destroy(this.gameObject);
			Generate();
		}
		else
			DontDestroyOnLoad(this.gameObject);
		if(CurrentLevel!=Application.loadedLevelName){
			PreviousLevel = CurrentLevel;
			CurrentLevel = Application.loadedLevelName;
			Generate();
		}
	}
}
