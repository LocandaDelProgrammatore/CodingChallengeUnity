using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FruitNinja {
    
    public class FruitLogic : MonoBehaviour {

        public Rigidbody rigidbody;
        public float verticalForce;
        public Vector2 randomHorizontalForce;
        public float timerDestroy;
        public int pointObtain;
        public GameObject feedbackDestroyer;
        private float currentTimer;

        // Start is called before the first frame update
        void Start() {
            rigidbody.AddForce(new Vector3(Random.Range(randomHorizontalForce.x, randomHorizontalForce.y),
                verticalForce), ForceMode.Impulse);
            
        }

        // Update is called once per frame
        void Update() {
            currentTimer += Time.deltaTime;
            if (currentTimer > timerDestroy) {
                currentTimer = 0;
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.GetComponent<LineController>()) {
                FindObjectOfType<GameplayManager>().UpdatePoint(pointObtain);
                Instantiate(feedbackDestroyer, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
