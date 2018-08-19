using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	// Declare a GameObject named 'coinPoofPrefab' and assign the 'CoinPoof' prefab to the field in Unity
	public GameObject coinPoofPrefab;


	void Update () {
		// OPTIONAL-CHALLENGE: Animate the coin rotating
		transform.Rotate(0.0f, 100*Time.deltaTime, 0.0f, Space.Self);
	}


	public void OnCoinClicked () {
		/// Called when the 'Coin' game object is clicked
		/// - Displays a poof effect (handled by the 'CoinPoof' prefab)
		/// - Plays an audio clip (handled by the 'CoinPoof' prefab)
		/// - Removes the coin from the scene

		// Prints to the console when the method is called
		Debug.Log ("'Coin.OnCoinClicked()' was called");

		// TODO: Display the poof effect and remove the coin from the scene
		Instantiate(coinPoofPrefab, transform.position,Quaternion.Euler(-90,0,0)); // Instantiates CoinPoof Prefab

		Destroy(gameObject,0.2f); //Destroys Coin
	}
}
