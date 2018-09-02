﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	public GameObject leftDoor;
	public GameObject rightDoor;

	public AudioClip doorLockedClip;
	public AudioClip doorOpeningClip;

	// TODO: Create variables to reference the components we need access to
	// Declare an AudioSource named 'audioSource' and get a reference to the audio source in Start()
	public AudioSource audioSource;

	public OpenChest chestObject;

	public ClosedDoor closedDoor;


	// TODO: Create variables to track the gameplay states
	private bool locked = true;
	private bool opening = false;

	// TODO: Create variables to hold rotations used when animating the door opening
	// Declare a Quaternion named 'leftDoorStartRotation' to hold the start rotation of the 'Left_Door' game object
	private Quaternion leftDoorStartRotation;
	// Declare a Quaternion named "leftDoorEndRotation" to hold the end rotation of the 'Left_Door' game object
	private Quaternion leftDoorEndRotation;
	// Declare a Quaternion named 'rightDoorStartRotation' to hold the start rotation of the 'Right_Door' game object
	private Quaternion rightDoorStartRotation;
	// Declare a Quaternion named 'rightDoorEndRotation' to hold the end rotation of the 'Right_Door' game object
	private Quaternion rightDoorEndRotation;

	// TODO: Create variables to control the speed of the interpolation when animating the door opening
	// Declare a float named 'timer' to track the Quaternion.Slerp() interpolation and initialize it to for example '0f'
	private float timer = 0f;
	// Declare a float named 'rotationTime' to set the Quaternion.Slerp() interpolation speed and initialize it to for example '10f'
	private float rotationTime = 10f;

	void Start () {
		// TODO: Get a reference to the audio source
		// Use GetComponent<>() to get a reference to the AudioSource component and assign it to the 'audioSource'
		//audioSource = GetComponent<AudioSource>();

		// TODO: Set start and end rotation values used when animating the door opening
		// Use 'leftDoor' to get the start rotation of the 'Left_Door' game object and assign it to 'leftDoorStartRotation'
		leftDoorStartRotation = leftDoor.transform.rotation;
		// Use 'leftDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Left_Door' game object and assign it to 'leftDoorEndRotation'
		leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0,0,90);
		// Use 'rightDoor' to get the start rotation of the 'Right_Door' game object and assign it to 'rightDoorStartRotation'
		rightDoorStartRotation = rightDoor.transform.rotation;
		// Use 'rightDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Right_Door' game object and assign it to 'rightDoorEndRotation'
		rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0,0,-90);

	}


	void Update () {
		// TODO: If the door is opening, animate the 'Left_Door' and 'Right_Door' game objects rotating open
		// Use 'opening' to check if the door is opening...
		// ... use Quaternion.Slerp() to interpolate from 'leftDoorStartRotation' to 'leftDoorEndRotation' by the interpolation time 'timer / rotationTime' and assign it to the 'leftDoor' rotation
		// ... use Quaternion.Slerp() to interpolate from 'rightDoorStartRotation' to 'rightDoorEndRotation' by the interpolation time 'timer / rotationTime' and assign it to the 'leftDoor' rotation
		// ... use Time.deltaTime to increment 'timer'
		if (opening) {
			leftDoor.transform.rotation = Quaternion.Slerp (leftDoorStartRotation, leftDoorEndRotation, timer);
			rightDoor.transform.rotation = Quaternion.Slerp (rightDoorStartRotation, rightDoorEndRotation, timer);
			timer = timer + Time.deltaTime;
		}

//		if (closedDoorFlag) {
//			
//			closedDoorFlag = false;
//			Debug.Log ("Flag" + closedDoorFlag);
//		}
	}


	public void OnDoorClicked () {
		/// Called when the 'Left_Door' or 'Right_Door' game object is clicked
		/// - Starts opening the door if it has been unlocked
		/// - Plays an audio clip when the door starts opening

		// Prints to the console when the method is called
		Debug.Log ("'Door.OnDoorClicked()' was called");


		// TODO: If the door is unlocked, start animating the door rotating open and play a sound to indicate the door is opening
		// Use 'locked' to check if the door is locked and ...
		// ... start the animation defined in Update() by changing the value of 'opening'
		// ... use 'audioSource' to play the AudioClip assigned to the AudioSource component
		if (!locked) {
			opening = true;
			audioSource.clip = doorOpeningClip;
			audioSource.Play ();
			chestObject.playChestAudio ();
		} else {
			audioSource.clip = doorLockedClip;
			audioSource.Play ();
			closedDoor.closedDoorClicked ();
		}
	}



	public void Unlock () {
		/// Called from Key.OnKeyClicked(), i.e. the Key.cs script, when the 'Key' game object is clicked
		/// - Unlocks the door

		// Prints to the console when the method is called
		Debug.Log ("'Door.Unlock()' was called");
	


		// TODO: Unlock the door 
		// Unlock the door by changing the value of 'locked'
		locked = false;
	}
}
