﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HeroChange : NetworkBehaviour {
	public GameObject[] typeOfBullets;
	public Shooting theGunScript;
	private Rigidbody rb;
	private Shooting shootingScript;
	public int heronumber = 0;
	private int thrust = 300;
	private float ycods;
	private bool KeyERestrict = false;
	private bool KeyQRestrict = false;
	private bool KeyMouseRestrict = false;

	void Start(){
		if (!isLocalPlayer)
        {
            return;
        }

		shootingScript = this.GetComponent<Shooting>();
		rb = this.GetComponent<Rigidbody>();
		Debug.Log(rb);
	}

	void Update(){
		if(heronumber == 1){
			theGunScript.bulletPrefab = typeOfBullets[0];
			theGunScript.Bulletspeed = 18;
			theGunScript.BulletLife = 0.4f;
			if(!KeyERestrict){
				if(Input.GetKeyDown("e")){
				Debug.Log("do the hero 1 special");
				rb.AddForce(transform.forward * thrust/2);
				rb.AddForce(transform.up * thrust);
				StartCoroutine(waitforDrop(0.8f));
				KeyERestrict = true;
			}
			}
			if(Input.GetMouseButtonDown(1)){
				Debug.Log("do the hero 1 second click");
			}
			if(Input.GetKeyDown("q")){
				Debug.Log("do the hero 1 Ult");
			}
		}
		if(heronumber == 2){
			theGunScript.bulletPrefab = typeOfBullets[1];
			theGunScript.Bulletspeed = 50;
			theGunScript.BulletLife = 2f;
			if(Input.GetKeyDown("e")){
				Debug.Log("do the hero 2 special");
			}
			if(Input.GetMouseButtonDown(1)){
				Debug.Log("do the hero 2 second click");
			}
			if(Input.GetKeyDown("q")){
				Debug.Log("do the hero 2 Ult");
			}
		}
	}

	public void Hero1(){
		heronumber = 1;
	}
	public void Hero2(){
		heronumber = 2;
	}

	IEnumerator waitforDrop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
		rb.AddForce(-transform.up * thrust*2);
		Debug.Log("goinDown");
		yield return new WaitForSeconds(0.2f);
		ycods = shootingScript.bulletSpawn.transform.position.y;
		shootingScript.bulletSpawn.transform.eulerAngles = new Vector3(0,shootingScript.bulletSpawn.transform.eulerAngles.y,shootingScript.bulletSpawn.transform.eulerAngles.z);
		shootingScript.bulletSpawn.transform.position = new Vector3(shootingScript.bulletSpawn.transform.position.x,0.5f,shootingScript.bulletSpawn.transform.position.z);
		shootingScript.bulletSpawn.transform.localPosition = new Vector3(shootingScript.bulletSpawn.transform.localPosition.x,shootingScript.bulletSpawn.transform.localPosition.y + 1f,shootingScript.bulletSpawn.transform.localPosition.z);
		shootingScript.bulletSpawn.transform.Rotate(Vector3.down * 22.5f);
		for(int i = 0; i < 200; i++){
			shootingScript.CmdFire();
			shootingScript.bulletSpawn.transform.Rotate(Vector3.up/4);
		}
		shootingScript.bulletSpawn.transform.localPosition = new Vector3(shootingScript.bulletSpawn.transform.localPosition.x,shootingScript.bulletSpawn.transform.localPosition.y - 1f,shootingScript.bulletSpawn.transform.localPosition.z);
		shootingScript.bulletSpawn.transform.position = new Vector3(shootingScript.bulletSpawn.transform.position.x,ycods,shootingScript.bulletSpawn.transform.position.z);
		shootingScript.bulletSpawn.transform.Rotate(Vector3.forward);
		KeyERestrict = false;
    }
}
