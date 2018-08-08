using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour {

	public void Start() {
		transform.GetChild(0).GetComponent<Button>().Select();
	}

	private void Update() {
		Cursor.visible = false;
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
