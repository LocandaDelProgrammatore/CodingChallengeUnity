using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CutTheRope {

	public class LevelUI : MonoBehaviour {

		public GameObject panelRestart;
		public Button button;

		private void Awake() {
			button.onClick.AddListener(ChangeScene);
		}


		public void OpenPanel() {
			panelRestart.SetActive(true);
		}

		private void ChangeScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);


	}

}