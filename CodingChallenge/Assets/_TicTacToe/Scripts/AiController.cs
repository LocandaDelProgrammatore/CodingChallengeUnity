using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe {

	public class AiController : MonoBehaviour {

		public GridManager gridManager;
		public float waitTimer;
		private bool isFirstTime;
		[SerializeField] int lastMovePlayer;
		[SerializeField] int lastMoveAi;

		private void Awake() {
			isFirstTime = true;
		}

		public IEnumerator WaitBeforeThink() {
			yield return new WaitForSeconds(waitTimer);
			Think();
		}

		public void SetLastValue(int lastValuePlayer) {
			lastMovePlayer = lastValuePlayer;
		}


		private void Think() {
		
            
			if (isFirstTime) {
				SetFirstValue();
				return;
			}

			if (TryWin()) {
				return;
			}

			if (TryStopPlayer()) {
				return;
			}
            
			RandomMove();
		}



		private bool TryWin() {
			var arrayControl = new List<ArrayElements>();
            
			for (int i = 0; i < gridManager.gridController.Count; i++) {
				if (lastMoveAi == gridManager.gridController[i].index) {
					arrayControl = gridManager.gridController[i].GeyArrays();
					break;
				}
			}
            
			for (int i = 0; i <arrayControl.Count; i++) {
				var intList = arrayControl[i].arrays;
				for (int j = 0; j < intList.Count; j++) {
					if (gridManager.gameButtons[lastMoveAi].spriteImage == gridManager.gameButtons[intList[j]].spriteImage) {
						gridManager.SetupValue(gridManager.gameButtons[intList[j]]);
						lastMoveAi = intList[j];
						return true;
					}
				}

			}

			return false;

		}

		private bool TryStopPlayer() {
			var arrayControl = new List<ArrayElements>();
            
			foreach (GridElementControl element in gridManager.gridController) {
				if (lastMovePlayer == element.index) {
					arrayControl = element.GeyArrays();
					break;
				}
			}

			var spritePlayer = gridManager.gameButtons[lastMovePlayer].spriteImage.sprite;
            
			for (int i = 0; i <arrayControl.Count; i++) {
                
				List<int> intList = arrayControl[i].arrays;
				GameButton spriteFirstElementArray = gridManager.gameButtons[intList[0]];
				GameButton spriteSecondElementArray = gridManager.gameButtons[intList[1]];
				
				

				if (spriteFirstElementArray.spriteImage.sprite == spritePlayer && !spriteSecondElementArray.IsCompleted) {
					gridManager.SetupValueAI(spriteSecondElementArray);
					lastMoveAi = gridManager.gameButtons.IndexOf(spriteSecondElementArray);
					return true;
				}

				if (spriteSecondElementArray.spriteImage.sprite == spritePlayer && !spriteFirstElementArray.IsCompleted) {
					gridManager.SetupValueAI(spriteFirstElementArray);
					lastMoveAi = gridManager.gameButtons.IndexOf(spriteFirstElementArray);
					return true;
				}
			}

			return false;

		}

		private void RandomMove() {
			foreach (var gameButton in gridManager.gameButtons) {
				if (!gameButton.IsCompleted) {
					gridManager.SetupValueAI(gameButton);
					lastMoveAi = gridManager.gameButtons.IndexOf(gameButton);
					return;
				}
			}
		}

		private void SetFirstValue() {
            
			lastMoveAi = !gridManager.gameButtons[4].IsCompleted ? 4 : 6;
			gridManager.SetupValueAI(!gridManager.gameButtons[4].IsCompleted ? gridManager.gameButtons[4] : gridManager.gameButtons[6]);
			isFirstTime = false;
            
		}
        
        
        
	}

}