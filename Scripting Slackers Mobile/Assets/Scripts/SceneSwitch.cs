using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public string level;

	public void LoadScene(string name) {
		SceneManager.LoadScene(name);
	}
	public void ReloadScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void SetLevel(string name) {
		level = name;
	}
	public void LoadLevel() {
		SceneManager.LoadScene(level);
	}
}
