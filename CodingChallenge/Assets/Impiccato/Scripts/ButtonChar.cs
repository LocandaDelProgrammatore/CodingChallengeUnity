using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Impiccato {

	public class ButtonChar : MonoBehaviour {

		public string word;
		public Action<string> OnWordRequired;
		public Button buttonWord;
		public TMP_Text text;

		private void Awake() {
			buttonWord.onClick.AddListener(SetWord);
		}

		public void Init(string initWord) {
			text.text = initWord;
			word = initWord;
		}


		public void SetWord() {
			OnWordRequired?.Invoke(word);
			buttonWord.interactable = false;
		}


		public void StopButtons() => buttonWord.interactable = false;
	}

}