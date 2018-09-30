using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO: Get convenient access the Scene and SceneManager classes
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour {

	private float enterTime;
	private bool pointerFlag = false;

	void Update () {
		if (pointerFlag) {
			if ((Time.time - enterTime) > 1.5f) {
				ResetScene ();
				pointerFlag = false;
			}
		}
	}

	public void ResetScene () {
		/// Called when the 'SignPost' game object is clicked
		/// - Reloads the scene

		// Prints to the console when the method is called
		Debug.Log ("'SignPost.ResetScene()' was called");
		// Use 'leftDoor' to get the start rotation of the 'Left_Door' game object and assign it to 'leftDoorStartRotation'

		// TODO: Reset the scene by getting a reference to the scene and reloading it
		// Declare a Scene named 'scene', then use SceneManager.GetActiveScene () to get the current scene and assign it to 'scene'
		// Use SceneManager.LoadScene() and the Scene.name property to reload the scene
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (scene.name);
	}

	public void onSignPostGaze () {
		pointerFlag = true;
		enterTime = Time.time;
	}

	public void onSignPostGazeOut () {
		pointerFlag = false;
	} 
}
