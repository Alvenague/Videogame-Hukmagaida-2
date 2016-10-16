using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {
	GameObject inv_text;
	public static ArrayList items = new ArrayList();
	public static ArrayList count_items = new ArrayList ();

	private bool visible;
	// Use this for initialization
	void Start () {
		visible = false;
		this.guiTexture.enabled = false;
		this.transform.position = new Vector3 (0.5f, 0.5f, -0.5f);
	
		inv_text = GameObject.Find("Inventory_text");
		inv_text.guiText.enabled = false;
		items.Add("Gold");
		count_items .Add(1);

		items.Add ("Sword");
		count_items.Add ("5");

		items.Add("Apple");
		count_items .Add(2);
		
		items.Add ("New item");
		count_items.Add ("2");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			visible = !visible;

			string refresh_txt = "";
			for(int i=0; i<items.Count; i++) {
				refresh_txt += items[i] + "   " + count_items[i] + "\n";
			}

			inv_text.guiText.text = refresh_txt;

			if(!visible) {
				this.guiTexture.enabled = false;
				inv_text.guiText.enabled = false;
			} else {
				this.guiTexture.enabled = true;
				inv_text.guiText.enabled = true;
			}
		}



	}
}
