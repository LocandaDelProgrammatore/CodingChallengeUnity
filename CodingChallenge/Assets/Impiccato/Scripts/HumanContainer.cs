using System;
using System.Collections.Generic;
using UnityEngine;

namespace Impiccato {

	public class HumanContainer : MonoBehaviour {

		public Action OnLoseRequired;
		public List<HumanPieces> humanPiecesList;
		private int index;
		private int wordLength;

		public void Init() {
			foreach (var humanPiece in humanPiecesList) {
				humanPiece.OnCheckLose += CheckLose;
			}
		}

		public void ActiveNewPiece() {
			if (index < humanPiecesList.Count) {
				humanPiecesList[index].ActiveImage();
			}
			index++;
		}

		private void CheckLose() {
			if (index >= humanPiecesList.Count) {
				OnLoseRequired?.Invoke();
			}
		}

	}

}