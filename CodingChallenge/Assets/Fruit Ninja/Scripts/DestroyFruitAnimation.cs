using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja {

    public class DestroyFruitAnimation : MonoBehaviour {

        [SerializeField] RectTransform endLeftPosition;
        [SerializeField] RectTransform endRightPosition;
        [SerializeField] private Image leftImage;
        [SerializeField] private Image rightImage;
        [SerializeField] private float timer;

        IEnumerator DestoyCor() {
            float t = 0;
            var initPosLeft = leftImage.rectTransform.position;
            var initPosRight = rightImage.rectTransform.position;
            var finalPosLeft = endLeftPosition.transform.position;
            var finalPosRight = endRightPosition.transform.position;
            leftImage.CrossFadeAlpha(0,timer,false);
            rightImage.CrossFadeAlpha(0,timer,false);
            
            while (t <timer) {
                leftImage.rectTransform.position = Vector3.Lerp(initPosLeft,finalPosLeft,t/timer);
                rightImage.rectTransform.position = Vector3.Lerp(initPosRight,finalPosRight,t/timer);
                t += Time.deltaTime;
                yield return null;
            }
            
            Destroy(gameObject);
            

        }

        // Start is called before the first frame update
        void Start() {
            //StartCoroutine(DestoyCor());
        }


        public void DestroyObject() => Destroy(gameObject);
        // Update is called once per frame
        void Update() { }
    }

}
