using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour {
	public Health PlayerHealth;
	public PlayerMotor PlayerMotor;
	public PlayerController PlayerController;
	public PlayerSetup PlayerSetup;
	public Shooting PlayerShooting;
	public ChangeCicle PlayerCircle;
	public HeroChange HeroChange;
	public GameObject PlayerFPS;
	public GameObject PlayerHealthbar;
	public Button[] HeroChoices;
	private bool alreadyClicked = true;
	public GameObject Child;
	public Camera MyOwnCamera;
	// Use this for initialization
	void Start () {
		MyOwnCamera.enabled = false;
		Button btn = HeroChoices[0].GetComponent<Button>();
        Button btn2 = HeroChoices[1].GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn.onClick.AddListener(OnHero1);
		btn2.onClick.AddListener(OnHero2);
	}
	
	void OnHero1(){
		HeroChange.Hero1();
		Cursor.lockState = CursorLockMode.Locked; 
		PlayerFPS.SetActive(true);
		PlayerHealthbar.SetActive(true);
		PlayerHealth.enabled = true;
		PlayerMotor.enabled = true;
		PlayerController.enabled = true;
		PlayerSetup.enabled = true;
		PlayerShooting.enabled = true;
		PlayerCircle.enabled = true;
		alreadyClicked = false;
		Child.SetActive(false);
		MyOwnCamera.enabled = false;
	}
	void OnHero2(){
		HeroChange.Hero2();
		Cursor.lockState = CursorLockMode.Locked; 
		PlayerFPS.SetActive(true);
		PlayerHealthbar.SetActive(true);
		PlayerHealth.enabled = true;
		PlayerMotor.enabled = true;
		PlayerController.enabled = true;
		PlayerSetup.enabled = true;
		PlayerShooting.enabled = true;
		PlayerCircle.enabled = true;
		alreadyClicked = false;
		Child.SetActive(false);
		MyOwnCamera.enabled = false;
	}

	void Update(){
		if(!alreadyClicked){
			if(Input.GetKeyDown(KeyCode.Escape)){
				PlayerFPS.SetActive(false);
				PlayerHealthbar.SetActive(false);
				PlayerHealth.enabled = false;
				PlayerMotor.enabled = false;
				PlayerController.enabled = false;
				PlayerSetup.enabled = false;
				PlayerShooting.enabled = false;
				PlayerCircle.enabled = false;
				Child.SetActive(true);
				MyOwnCamera.enabled = false;
				alreadyClicked = true;
			}
		}
	}
}
