using UnityEngine;
using System.Collections;

public class missions : MonoBehaviour {

	public GameObject player;
	public GameObject missionTexture;
	public GameObject missionTxt;
	public string place;
	// Use this for initialization
	void Start () {
		missionTexture = GameObject.Find ("missionTexture");
		missionTxt = GameObject.Find ("missionTxt");
		player = GameObject.Find ("Player 1");
		place = "Cave Start"; 
	}
	
	// Update is called once per frame
	void Update () {
		//missionTexture.guiTexture.enabled= true;
		if (place == "CaveStart") {
			missionTxt.guiText.text = "Cave Start";
		}
	}
}