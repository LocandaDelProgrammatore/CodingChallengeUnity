using TMPro;
using UnityEngine;

namespace FruitNinja {

	public class UiManager : MonoBehaviour {

		public TMP_Text textTimer;
		public GameObject panelRestart;
		public TMP_Text textPoint;
		private GameplayManager gameplayManager;
		private bool isEnded;

		private void Awake() {
			gameplayManager = FindObjectOfType<GameplayManager>();
			gameplayManager.OnFinishGame += OpenEndPanel;
			gameplayManager.OnPointsUpdated += UpdatePoints;

		}


		private void OpenEndPanel() {
			panelRestart.SetActive(true);
			isEnded = true;

		}

		private void Update() {
			if (isEnded) {
				textTimer.text = string.Format("{0:00}:{1:00}", 0, 0);
				return;
			}
			float minutes = Mathf.FloorToInt(gameplayManager.globalTimer / 60);  
			float seconds = Mathf.FloorToInt(gameplayManager.globalTimer % 60);
			textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}

		private void UpdatePoints(int point) => textPoint.text = point.ToString();



	}

}