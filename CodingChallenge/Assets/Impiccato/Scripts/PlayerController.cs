using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Impiccato {

	public class PlayerController : MonoBehaviour {

		public Action<string> OnCheckWordRequired;
		public Button confirmButton;
		public string confirmString;
		public TMP_InputField textField;
		public List<char> elementsControlledYet = new List<char>();
		public List<ButtonChar> buttonChars;
		

		private void Awake() {
			confirmButton.onClick.AddListener(TryUpdateWord);
		}

		public void Init() {
			char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
			for (int i = 0; i < buttonChars.Count; i++) {
				buttonChars[i].Init(az[i].ToString());
				buttonChars[i].OnWordRequired += UpdateWord;
			}
			
		}

		private void UpdateWord(string s) => OnCheckWordRequired?.Invoke(s);

		private void Update() {
			confirmButton.interactable = textField.text.Length > 0 && textField.interactable;
		}

		private void TryUpdateWord() {
			confirmString = textField.text;
			if (confirmString.Length == 1) {
				if (elementsControlledYet.Contains(confirmString[0])) {
					confirmString = "";
					textField.text = "";
					return;
				}
				
				OnCheckWordRequired?.Invoke(confirmString);
				elementsControlledYet.Add(confirmString[0]);
				confirmString = "";
				textField.text = "";
				
				return;
			}
			OnCheckWordRequired?.Invoke(confirmString);
			confirmString = "";
			textField.text = "";
		}

		public void StopButton() {
			textField.interactable = false;
			confirmButton.interactable = false;
			if (buttonChars.Count > 0) {
				foreach (var button in buttonChars) {
					button.StopButtons();
				}
			}
		}



	}

}