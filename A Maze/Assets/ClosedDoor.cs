using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour {

	public Animator leftDoorAnimator;
	public Animator rightDoorAnimator;

	// Use this for initialization
	void Start () {
		leftDoorAnimator.StartPlayback ();
		rightDoorAnimator.StartPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closedDoorClicked(){
		leftDoorAnimator.StopPlayback ();
		rightDoorAnimator.StopPlayback ();
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		print ("Hello");
		yield return new WaitForSecondsRealtime(2);
		print ("World");
		leftDoorAnimator.StartPlayback ();
		rightDoorAnimator.StartPlayback ();
	}

}
