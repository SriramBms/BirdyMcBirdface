using UnityEngine;
using System.Collections;

public class RemoveFromScreen : MonoBehaviour {


	//keep track of whether or not it has ever been on the screen (visible by the camera)
	private bool hasBeenSeen = false;


	void Update () 
	{
		checkRemoveFromScreen ();
	}

	protected void checkRemoveFromScreen(){

		//see if is it currently able to be seen by the camera
		bool currentlyVisible = isVisible ();

		if(!hasBeenSeen){
			//if it hasn't been seen yet, then just store its current visibility
			hasBeenSeen = currentlyVisible;
		}else if(!currentlyVisible){
			//if it has ever been seen, and it is not currently visible to the camera, then we can get rid of it
			//it has been on screen, and has moved off
			Destroy (gameObject);
		}
	}

	protected bool hasBeenOnScreen(){
		return hasBeenSeen;
	}

	protected bool isVisible(){
		//this is another function in Extensions.cs - it lets us know if the Camera can currently see the object
		return GetComponent<Renderer>().IsVisibleFrom(Camera.main);
	}
}
