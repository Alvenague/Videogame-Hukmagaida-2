using UnityEngine;
using System.Collections;

public class findHousesStart : MonoBehaviour {
	
	// Use this for initialization
	private bool firstTime = true;
	private GameObject missionTxt;
	private GameObject missionTexture;
	void Start () {
		missionTxt = GameObject.Find("MissionTxt");
		missionTexture = GameObject.Find ("MissionTexture");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		GameObject tracker = GameObject.Find ("Tracker");
		if (firstTime) {
			missionTexture.guiTexture.enabled = true;
			missionTxt.guiText.enabled = true;
			missionTxt.guiText.text = "This is really strange, not a single soul around. \nThis town should’ve been bursting with chatter from festivals this time of the year. \nI must check the local houses to see if I can find anybody.";
			StartCoroutine(WaitAndPrint(11.0F));
			GameObject newTracker = GameObject.Find("StablesPoint4");
			tracker.GetComponent<ObjectLabel>().target = newTracker.transform;
			GameObject stables = GameObject.Find ("stablesTrigger");
			stables.collider.enabled = true;

			firstTime = false;
		}
	}
	
	IEnumerator WaitAndPrint(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		missionTexture.guiTexture.enabled = false;
		missionTxt.guiText.enabled = false;
		missionTxt.guiText.text = "";
	}
	
}
