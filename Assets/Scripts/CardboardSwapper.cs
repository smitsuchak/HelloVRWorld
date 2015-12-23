using UnityEngine;
using System.Collections;

public class CardboardSwapper : MonoBehaviour {

	public GameObject[] cardboardObjects;
	public GameObject[] monoObjects;

	// Turn on or off VR mode
	void ActivateVRMode(bool goToVR) {
		foreach (GameObject cardboardThing in cardboardObjects) {
			cardboardThing.SetActive(goToVR);
		}
		foreach (GameObject monoThing in monoObjects) {
			monoThing.SetActive(!goToVR);
		}
		Cardboard.SDK.VRModeEnabled = goToVR;

		// Tell the game over screen to redisplay itself if necessary
		gameObject.GetComponent<GameController>().RefreshGameOver();
	}

	public void Switch() {
		ActivateVRMode(!Cardboard.SDK.VRModeEnabled);
	}

	void Update () {
		if (Cardboard.SDK.BackButtonPressed) {
			Switch();
		}
	}

	void Start() {
		ActivateVRMode(false);
	}

}
