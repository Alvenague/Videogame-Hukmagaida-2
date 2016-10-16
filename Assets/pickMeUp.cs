using UnityEngine;
using System.Collections;

public class pickMeUp : MonoBehaviour {

	// Use this for initialization
	private inventory i;
	private bool inZone;

	GameObject guitxt;
	GameObject missionTxt;
	GameObject missionTexture;
	void Start () {
		inZone = false;
		guitxt = GameObject.Find ("InteractGUIText");
		i = GetComponent<inventory> ();

		missionTxt = GameObject.Find("MissionTxt");
		missionTexture = GameObject.Find ("MissionTexture");
	}
	
	// Update is called once per frame
	void Update () {
		if (inZone) {
			if(Input.GetKeyDown(KeyCode.E)) {
				string name_of_current = this.tag;
				if(!inventory.items.Contains(name_of_current)) {
					inventory.items.Add (name_of_current);
					inventory.count_items.Add (1);
				} else {
					int index = inventory.items.IndexOf(name_of_current);
					int num = (int)inventory.count_items[index];
					num = num+1;
					inventory.count_items[index] = num;
				}

				//Pobral sem scroll
				if(name_of_current == "Scroll") {

					missionTexture.guiTexture.enabled = true;
					missionTxt.guiText.enabled = true;
					missionTxt.guiText.text = "This journal says something about the witch Hukmagaida. I don’t understand, she has been dead for centuries now. \nI must gather clues from the other houses!";
					StartCoroutine(WaitAndPrint(14.0F));
				}



				print ("Pobral");
				guitxt.guiText.text = "";
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		print ("Vstop");
		guitxt.guiText.text = "Press E to pick up";
		inZone = true;

	}

	void OnTriggerExit(Collider other) {
		inZone = false;
		print("Izstopil");
		guitxt.guiText.text = "";
	}

	IEnumerator WaitAndPrint(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		missionTexture.guiTexture.enabled = false;
		missionTxt.guiText.enabled = false;
		missionTxt.guiText.text = "";
	}
}
