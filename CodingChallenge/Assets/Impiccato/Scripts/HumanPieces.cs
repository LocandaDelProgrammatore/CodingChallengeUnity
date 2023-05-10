using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Impiccato {

	public class HumanPieces : MonoBehaviour {

		public Action OnCheckLose;
		[SerializeField] private Image humanImage;

		private void Awake() {
			humanImage =  GetComponent<Image>();
		}

		public void ActiveImage() {

			StartCoroutine(FillImage());
		}


		IEnumerator FillImage() {
            
			float t = 0f;
			while (t < 0.5f ) {
				humanImage.fillAmount = Mathf.Lerp(0, 1, t / 0.5f);
				t += Time.deltaTime;
				yield return null;
			}

			humanImage.fillAmount = 1;
			OnCheckLose?.Invoke();
		}
	}

}