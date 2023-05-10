using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Impiccato {

    public class WordManager : MonoBehaviour {

        [SerializeField] Transform content;
        [SerializeField] private WordDatabase wordDatabase;
        [SerializeField] private TMP_Text feedbackEndGame;
        [SerializeField] GameObject charAnswerObject;
        private HumanContainer humanContainer;
        private PlayerController playerController;
        private string wordToCheck;
        private List<CharAnswerLogic> charAnswerLogics = new List<CharAnswerLogic>();
        private int counter;

        private void Awake() {
            humanContainer = FindObjectOfType<HumanContainer>();
            playerController = FindObjectOfType<PlayerController>();
            humanContainer.OnLoseRequired += Lose;
            playerController.OnCheckWordRequired += CheckWord;
            feedbackEndGame.enabled = false;
            Init();
        }

        public void Init() {
            wordToCheck = wordDatabase.GetWord();
            for (int i = 0; i < wordToCheck.Length; i++) {
                var charAnswer = Instantiate(charAnswerObject, content.position, Quaternion.identity, content);
                var charAnswerComponent = charAnswer.GetComponent<CharAnswerLogic>();
                charAnswerComponent.UpdateText(wordToCheck[i].ToString());
                charAnswerLogics.Add(charAnswerComponent);
            }
            humanContainer.Init();
            playerController.Init();

        }


        private void CheckWord(string word) {
            bool isCorrect = false;

            if (word.Length == 1) {
                char wordElement = word[0];
                for (int i = 0; i < wordToCheck.Length; i++) {
                    if (wordToCheck[i].Equals(wordElement)) {
                        charAnswerLogics[i].ActiveText();
                        isCorrect = true;
                        counter++;
                    }
                }

                if (!isCorrect) {
                    humanContainer.ActiveNewPiece();
                    return;
                }

                TryCheckWin();
                return;
            }

            if (wordToCheck.Equals(word)) {

                Win();
                return;
            }
            
            humanContainer.ActiveNewPiece();
        }

        private void TryCheckWin() {
            if (counter == wordToCheck.Length) {
                Win();
            }
        }

        private void Win() {
            for (int i = 0; i < charAnswerLogics.Count; i++) {
                charAnswerLogics[i].ActiveText();
            }
            feedbackEndGame.enabled = true;
            feedbackEndGame.text = "Hai vinto";
            playerController.StopButton();
            StartCoroutine(WaitBeforeRestart());
        }

        private void Lose() {
            feedbackEndGame.enabled = true;
            feedbackEndGame.text = "Hai perso," + " la parola era: " + wordToCheck;
            playerController.StopButton();
            StartCoroutine(WaitBeforeRestart());
        }


        IEnumerator WaitBeforeRestart() {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}
