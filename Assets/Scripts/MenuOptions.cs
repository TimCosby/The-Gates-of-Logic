using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuOptions : MonoBehaviour {

	private Button CurrentButton;

	public void Start() {
		CurrentButton = transform.GetChild(0).GetComponent<Button>();
		CurrentButton.Select();
	}

	private void Update() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		GameObject temp = EventSystem.current.currentSelectedGameObject;

		if (temp == null || temp.GetComponents<Button>() == null) {
			CurrentButton.Select();
		}
		else {
			CurrentButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
		}
	}

	public void NewGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void GoToScene(string Scene) {
		SceneManager.LoadScene(Scene);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
