using UnityEngine;
using System.Collections;

public class house5Trigger : MonoBehaviour {
	
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
			missionTxt.guiText.text = "The town has been abandoned! I must figure out what is going on here! \nMaybe I'll find something in church...";
			StartCoroutine(WaitAndPrint(12.0F));
			print ("dela");
			
			GameObject newTracker = GameObject.Find("Scroll");
			tracker.GetComponent<ObjectLabel>().target = newTracker.transform;
			GameObject scrollTrigger = GameObject.Find("ScrollTrigger");
			scrollTrigger.collider.enabled = true;

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
