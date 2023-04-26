using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe {

	public class GameButton : MonoBehaviour {
        
		public Action<GameButton> OnButtonClicked;
        
		public Button gameButton;
		public Image spriteImage;
		private bool isCompleted;

		public bool IsCompleted => isCompleted;

		private void Awake() {
			gameButton.onClick.AddListener(() => OnButtonClicked?.Invoke(this));
			spriteImage.enabled = false;
		}


		public void UpdateValue(Sprite playerSprite) {
			spriteImage.sprite = playerSprite;
			gameButton.enabled = false;
			spriteImage.enabled = true;
			isCompleted = true;
		}

	}

}