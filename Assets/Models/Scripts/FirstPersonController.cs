using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5;
	public float jumpSpeed = 7.0f;


	public float upDownRange = 60.0f; //Da ne zlomiš vratu. :)
	float verticalRotation = 0; //Ob inicializaciji gledaš naravnost

	float verticalVelocity = 0;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true; //Da se cursor ne vidi več.
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Rotation
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
     	transform.Rotate (0, rotLeftRight, 0); //Rotiraš se po Y osi. <- Gre za obračanje objekta

		//Za pogled gor dol pa gre samo za OBRAČANJE KAMERE (za razliko od zgornje kode)
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);



		//Movement
		float forwardSpeed = Input.GetAxis("Vertical")*movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal")*movementSpeed;


		//Gravitacija
		verticalVelocity += Physics.gravity.y * Time.deltaTime;


		//POGLED Z MIŠKO LEVO DESNO
		//Ker se pri premikanju mora upoštevati to, v katero smer naš karakter gleda,
		//moramo zadevo new Vector3 (sideSpeed,0, forwardSpeed ) modificirati. up
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed );
		speed = transform.rotation * speed;
	
		//Skok
		if (Input.GetButtonDown ("Jump") && characterController.isGrounded) { //Input.GetButton -> zazna vsak frame. Če vzamemo GetButtonDown zazna samo enkrat
			verticalVelocity = jumpSpeed;
		}
		characterController.Move (speed * Time.deltaTime); //cc.SimpleMove (speed); - Simple move je vredu za gravitacijo in premikanje, ampak ne za skakanje (Y koordinata je ignorirana).
		//Move nima gravitacije.


	}
}
