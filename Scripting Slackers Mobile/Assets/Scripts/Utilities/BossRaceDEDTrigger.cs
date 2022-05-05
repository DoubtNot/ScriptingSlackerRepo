using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRaceDEDTrigger : MonoBehaviour {

	[SerializeField] string[] scenes;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Boss")
		{
			LoadRandomLevel();
		}
		
	}

	public void LoadRandomLevel() {
		if (scenes.Length > 0) {
			int index = UnityEngine.Random.Range(0, scenes.Length);
			SceneManager.LoadScene(scenes[index]);
		}
	}
}
