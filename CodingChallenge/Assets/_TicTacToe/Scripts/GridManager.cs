using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe {

	public class GridManager : MonoBehaviour {

		public TurnManager turnManager;
		public List<GameButton> gameButtons;
		public List<GridElementControl> gridController;
		public Action<bool> OnGameFinish;
		public Action OnGameContinue;
		public AiController aiController;

		private void Awake() {
			foreach (var button in gameButtons) {
				button.OnButtonClicked += SetupValue;
			}
		}

		public void SetupValue(GameButton button) {
			StopAllButtons();
			Sprite sprite = turnManager.IsTurnP1 ? turnManager.p1.GetSprite() : turnManager.p2.GetSprite();
			button.UpdateValue(sprite);
			SetupCheck(button);
			
			if (aiController != null && aiController.isActiveAndEnabled) {
				aiController.SetLastValue(gameButtons.IndexOf(button));
			}
		}


		public void SetupValueAI(GameButton button) {
			StopAllButtons();
			Sprite sprite = turnManager.IsTurnP1 ? turnManager.p1.GetSprite() : turnManager.p2.GetSprite();
			button.UpdateValue(sprite);
			SetupCheck(button);
		}


		private void SetupCheck(GameButton button) {
			
		
			int indexButton = gameButtons.IndexOf(button);
			List<ArrayElements> arrayControl = new List<ArrayElements>();
			
			for (int i = 0; i < gridController.Count; i++) {
				if (indexButton == gridController[i].index) {
					arrayControl = gridController[i].GeyArrays();
					break;
				}
			}
			
			if (Check(button, arrayControl)) {
				OnGameFinish?.Invoke(false);
				return;
			}
			
				
			if (AllCellIsFull()) {
				OnGameFinish?.Invoke(true);
				return; 
			}

			OnGameContinue?.Invoke();

		}


		private bool AllCellIsFull() {
			
			foreach (var button in gameButtons) {
				if (!button.IsCompleted) {

					return false;
				}
			}

			return true;
		}

		private bool Check(GameButton button, List<ArrayElements> arrays) {
			bool isChecked = true;
			for (int i = 0; i < arrays.Count; i++) {
				var array = arrays[i].arrays;
				isChecked = true;
				for (int j = 0; j < array.Count; j++) {
					if (button.spriteImage.sprite != gameButtons[array[j]].spriteImage.sprite) {
						isChecked = false;
						break;
					}
				}

				if (isChecked) {
					return true;
				}
			}

			return isChecked;
		}


		private void StopAllButtons() {

			foreach (var button in gameButtons) {
				button.gameButton.enabled = false;
			}
		}

		public void ActiveAllButtons() {
			foreach (var button in gameButtons) {
				if (!button.IsCompleted) {
					button.gameButton.enabled = true;
				}
			}
		}

	}
	
	
	[Serializable]
	public class GridElementControl {
        
		public int index;
		
		public List<ArrayElements> arrayControl;


		public List<ArrayElements> GeyArrays() => arrayControl;
	}

	[Serializable]
	public class ArrayElements {

		public List<int> arrays;
	}

}