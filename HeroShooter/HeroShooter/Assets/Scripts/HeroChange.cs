using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroChange : MonoBehaviour {
	public GameObject[] typeOfBullets;
	public Shooting theGunScript;
	public void Hero1(){
		theGunScript.bulletPrefab = typeOfBullets[0];
		theGunScript.Bulletspeed = 18;
		theGunScript.BulletLife = 0.4f;
	}
	public void Hero2(){
		theGunScript.bulletPrefab = typeOfBullets[1];
		theGunScript.Bulletspeed = 50;
		theGunScript.BulletLife = 2f;
	}
}
