using UnityEngine;

namespace CutTheRope {

	public class LevelManager : MonoBehaviour {

		private LevelUI levelUI;
		private CharacterLogic characterLogic;

		private void Awake() {
			levelUI = FindObjectOfType<LevelUI>();
			characterLogic = FindObjectOfType<CharacterLogic>();
			characterLogic.OnBallEnter += levelUI.OpenPanel;
		}
	}

}