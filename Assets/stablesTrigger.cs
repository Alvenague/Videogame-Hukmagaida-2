using UnityEngine;
using System.Collections;

public class stablesTrigger : MonoBehaviour {
	
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
			missionTxt.guiText.text = "I've just found stables.";
			StartCoroutine(WaitAndPrint(3.0F));

			GameObject newTracker = GameObject.Find("House3");
			tracker.GetComponent<ObjectLabel>().target = newTracker.transform;
			GameObject house3 = GameObject.Find ("house3Trigger");
			house3.collider.enabled = true;
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
