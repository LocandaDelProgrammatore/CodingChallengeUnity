using TMPro;
using UnityEngine;

namespace Impiccato {

	public class CharAnswerLogic : MonoBehaviour {

		public TMP_Text text;

		private void Awake() {
			text.enabled = false;
		}


		public void UpdateText(string charAnswer) {
			text.text = charAnswer;
		}


		public void ActiveText() {
			
			text.enabled = true;
			text.CrossFadeAlpha(0,0,false);
			text.CrossFadeAlpha(1,0.5f,false);
		}
	}

}