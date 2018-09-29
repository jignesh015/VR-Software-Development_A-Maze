using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	// Declare a GameObject named 'keyPoofPrefab' and assign the 'KeyPoof' prefab to the field in Unity
	// Declare a Door named 'door' and assign the top level 'Door' game object to the field in Unity

	public GameObject keyPoofPrefab;
	public Door door;


	void Update () {
		// OPTIONAL-CHALLENGE: Animate the key rotating
		transform.Rotate(0.0f, 0.0f, 100*Time.deltaTime, Space.Self);
	}


	public void OnKeyClicked () {
		/// Called when the 'Key' game object is clicked
		/// - Unlocks the door (handled by the Door class)
		/// - Displays a poof effect (handled by the 'KeyPoof' prefab)
		/// - Plays an audio clip (handled by the 'KeyPoof' prefab)
		/// - Removes the key from the scene

		// Prints to the console when the method is called
		Debug.Log ("'Key.OnKeyClicked()' was called");

		// TODO: Unlock the door, display the poof effect, and remove the key from the scene
		door.Unlock(); // Unlocks door

		Instantiate(keyPoofPrefab, transform.position,Quaternion.Euler(-90,0,0)); // Instantiates KeyPoof Prefab

		Destroy(gameObject,0.3f); // Destroys Key
	}

	public void onKeyGaze () {
		StartCoroutine ("delayClick");
	}

	IEnumerator delayClick() {
		yield return new WaitForSeconds (1.5f);
		OnKeyClicked ();
	}
}
