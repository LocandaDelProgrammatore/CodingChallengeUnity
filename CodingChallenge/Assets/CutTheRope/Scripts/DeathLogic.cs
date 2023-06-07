using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLogic : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Ball")) {
			Destroy(other.gameObject);
			StartCoroutine(WaitBeforeReload());
		}
	}



	IEnumerator WaitBeforeReload() {
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
