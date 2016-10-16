using UnityEngine;
using System.Collections;

public class openDoorCollider : MonoBehaviour {

	// Use this for initialization
	GameObject interactGUI;
	bool inZone;

	void Start () {
		interactGUI = GameObject.Find ("InteractGUIText");
		inZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inZone) {
			if(Input.GetKeyDown(KeyCode.E)) {
				Application.LoadLevel("village");
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		interactGUI.guiText.text = "Press E to open the door.";
		inZone = true;
	}
	void OnTriggerExit(Collider other) {
		interactGUI.guiText.text = "";
		inZone = false;
	}
}
