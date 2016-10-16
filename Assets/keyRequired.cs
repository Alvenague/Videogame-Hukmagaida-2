using UnityEngine;
using System.Collections;

public class keyRequired : MonoBehaviour {
	
	// Use this for initialization
	inventory inv;
	private bool firstTime = true;
	private GameObject missionTxt;
	private GameObject missionTexture;
	void Start () {
		missionTxt = GameObject.Find("MissionTxt");
		missionTexture = GameObject.Find ("MissionTexture");
		inv = GetComponent<inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(!inventory.items.Contains("Key")){
			missionTexture.guiTexture.enabled = true;
			missionTxt.guiText.enabled = true;
			missionTxt.guiText.text = "It is locked. I have to find a key.";
			StartCoroutine(WaitAndPrint(5.0F));
			firstTime = false;
		} else {
		/*	missionTexture.guiTexture.enabled = true;
			missionTxt.guiText.enabled = true;
			missionTxt.guiText.text = "Ql, u can enter"; */
			GameObject openDoorCollider = GameObject.Find ("openDoorCollider");
			openDoorCollider.collider.enabled = true;
			StartCoroutine(WaitAndPrint(2.0F));
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
