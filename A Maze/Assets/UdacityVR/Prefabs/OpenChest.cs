using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

	public GameObject leftDoorCheck;

	public Animator openChest;

	public AudioSource chestAudioSource;

	public AudioClip chestAudioClip;

	// Use this for initialization
	void Start () {
		openChest.StartPlayback ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (leftDoorCheck.transform.rotation.eulerAngles.z);
		if (leftDoorCheck.transform.eulerAngles.y > 175) {
			openChest.StopPlayback ();
		}
	}

	public void playChestAudio(){
		Debug.Log ("Play Audio");
		chestAudioSource.clip = chestAudioClip;
		chestAudioSource.PlayDelayed (1);
	}


}
