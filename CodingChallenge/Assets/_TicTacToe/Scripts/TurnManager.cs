using System;
using System.Collections;
using UnityEngine;

namespace TicTacToe {

    public class TurnManager : MonoBehaviour {

        
        public PlayerManager p1;
        public PlayerManager p2;
        [SerializeField] private GridManager gridManager;
        [SerializeField] private UiManager uiManager;
        [SerializeField] private float timerWait;
        private bool isTurnP1;

        public bool IsTurnP1 => isTurnP1;

        private void Awake() {
            isTurnP1 = true;
            gridManager.OnGameContinue += ChangeTurn;
            gridManager.OnGameFinish += EndGame;
        }


        private void EndGame(bool hasDraw) {
            
            if (hasDraw) {
                uiManager.ActiveTextVictory(isTurnP1,true);
            }
            else {
                uiManager.ActiveTextVictory(isTurnP1,false);
            }
        }

        private void ChangeTurn() {
            StartCoroutine(WaitBeforeChangeTurn());
        }

        IEnumerator WaitBeforeChangeTurn() {
            yield return new WaitForSeconds(timerWait);
            isTurnP1 = !isTurnP1;
            SetNextTurn();
        }

        void SetNextTurn() {
            
            uiManager.UpdateText(isTurnP1);
            
            if (isTurnP1) {
                if (p1.aiController != null) {
                    StartCoroutine(p1.aiController.WaitBeforeThink());
                    return;
                }
            }
            else {
                if (p2.aiController != null) {
                    StartCoroutine(p2.aiController.WaitBeforeThink());
                    return;
                }    
            }
            
            gridManager.ActiveAllButtons();
        }
            
        
    }

}