using UnityEngine;
using System.Collections;

public class Torchelight : MonoBehaviour {
	
	public GameObject TorchLight;
	public GameObject MainFlame;
	public GameObject BaseFlame;
	public GameObject Etincelles;
	public GameObject Fumee;
	
	public float MaxLightIntensity;
	public float IntensityLight;

	private bool inZone = false;
	private bool rightOne = false;
	private bool firstTime = true;
	private GameObject guiText;
	private GameObject doors;

	private GameObject missionTxt;
	private GameObject missionTexture;



	void Start () {
		TorchLight.light.intensity=IntensityLight;
		MainFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*20f;
		BaseFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*15f;	
		Etincelles.GetComponent<ParticleSystem>().emissionRate=IntensityLight*7f;
		Fumee.GetComponent<ParticleSystem>().emissionRate=IntensityLight*12f;
		guiText = GameObject.Find ("InteractGUIText");
		guiText.guiText.text = "";

		missionTxt = GameObject.Find("MissionTxt");
		missionTexture = GameObject.Find ("MissionTexture");



		doors = GameObject.Find ("Door_pivot");
	}
	

	void Update () {
		if (IntensityLight<0) IntensityLight=0;
		if (IntensityLight>MaxLightIntensity) IntensityLight=MaxLightIntensity;		

		TorchLight.light.intensity=IntensityLight/2f+Mathf.Lerp(IntensityLight-0.1f,IntensityLight+0.1f,Mathf.Cos(Time.time*30));

		TorchLight.light.color=new Color(Mathf.Min(IntensityLight/1.5f,1f),Mathf.Min(IntensityLight/2f,1f),0f);
		MainFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*20f;
		BaseFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*15f;
		Etincelles.GetComponent<ParticleSystem>().emissionRate=IntensityLight*7f;
		Fumee.GetComponent<ParticleSystem>().emissionRate=IntensityLight*12f;		

		//float currIntensity = IntensityLight;
		//print (IntensityLight);
		if (inZone) {
			if(IntensityLight == 0 && Input.GetKeyDown(KeyCode.E)) {
				IntensityLight = 1;
				if(rightOne && firstTime) {
					doors.transform.Rotate(0, 90, 0);
					GameObject tracker = GameObject.Find ("Tracker");
					tracker.GetComponent<ObjectLabel> ().target = GameObject.Find ("Point2").transform;;
					missionTexture.guiTexture.enabled = true;
					missionTxt.guiText.enabled = true;
					missionTxt.guiText.text = "Whoa! Something just opened!";
					StartCoroutine(WaitAndPrint(3.0F));
					firstTime = false;
				}
			} else if(IntensityLight > 0 && Input.GetKeyDown(KeyCode.E)) {
				IntensityLight = 0;
				if(rightOne) {
				doors.transform.Rotate(0, -90, 0);
				}
			}
		
		}

	}

	IEnumerator WaitAndPrint(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		missionTexture.guiTexture.enabled = false;
		missionTxt.guiText.enabled = false;
		missionTxt.guiText.text = "";
	}



	void OnTriggerEnter(Collider other) {
		guiText.guiText.text = "Press E to interact";
		print ("Vstopil");
		print (this.tag);
		if (this.tag == "RightOne") {
			rightOne = true;
		}
		inZone = true;
	}
	void OnTriggerExit(Collider other) {
		guiText.guiText.text = "";
		print ("Izstopil");
		if (this.tag == "RightOne") {
			rightOne = false;
		}
		inZone = false;
	}
}
