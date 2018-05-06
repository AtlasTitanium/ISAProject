using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
	[SerializeField]
	Behaviour[] componentsToDisable;
	Camera sceneCamera;
	public GameObject MiddleScreen;
	public Canvas Healthbar;
	public GameObject Herochoose;
	public override void OnStartLocalPlayer ()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
		MiddleScreen.SetActive(true);
		Healthbar.enabled = false;
		Herochoose.SetActive(true);
    }
	void Start(){
		if(!isLocalPlayer){
			for (int i = 0; i < componentsToDisable.Length; i++){
				componentsToDisable[i].enabled = false;
			}
		} else {
			sceneCamera = Camera.main;
			if (sceneCamera != null){
				sceneCamera.gameObject.SetActive(false);
			}
		}
	}

	void OnDisable(){
		if(sceneCamera != null){
			sceneCamera.gameObject.SetActive(true);
		}
	}
}
