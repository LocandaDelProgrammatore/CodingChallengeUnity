using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe {

	public class UiManager : MonoBehaviour {

		
		public TMP_Text currentPlayer;
		public TMP_Text victoryText;
		public Button restart;
		public string initialStringText = "è il turno di ";

		private void Awake() {
			currentPlayer.text = initialStringText + "player1";
			restart.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
			restart.gameObject.SetActive(false);
		}

		
		public void UpdateText(bool isP1) {
			var stringPlayer = isP1 ? "player1" : "player2";
			currentPlayer.text = initialStringText + stringPlayer;
		}

		public void ActiveTextVictory(bool isP1,bool hasDraw) {

			victoryText.enabled = true;
			currentPlayer.enabled = false;
			
			if (hasDraw) {
				victoryText.text = " è finita in pareggio";
			}
			else {
				var stringPlayer = isP1 ? " player1" : " player2";
				victoryText.text += stringPlayer;
			}
			
			restart.gameObject.SetActive(true);
		}
		
		
		
		
	}

}