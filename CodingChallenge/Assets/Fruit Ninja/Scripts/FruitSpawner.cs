using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja {
    

    public class FruitSpawner : MonoBehaviour {

        public GameObject fruit;
        public float timerSpawn;
        private float currentTimer;
        private Camera mainCamera;
        [SerializeField] float ySpawn = -1.2f;
        [SerializeField] private Vector2 xSpawn = new Vector2(0.2f, 0.8f);
        private GameplayManager gameplayManager;
        private bool canSpawn;
        
        // Start is called before the first frame update
        void Start() {
            mainCamera = FindObjectOfType<Camera>();
            gameplayManager = FindObjectOfType<GameplayManager>();
            gameplayManager.OnFinishGame += () => canSpawn = true;
        }

        
        // Update is called once per frame
        void Update() {
            if (!canSpawn) {
                currentTimer += Time.deltaTime;
                if (timerSpawn < currentTimer) {
                    currentTimer = 0;
                    Spawn();
                }
            }

        }

        void Spawn() {
            float xPos = Random.Range(xSpawn.x, xSpawn.y);
            Vector3 pos = mainCamera.ViewportToWorldPoint(new Vector3(xPos, ySpawn,0));
            pos = new Vector3(pos.x, pos.y, 0);
            Instantiate(fruit, pos, Quaternion.identity);
        }
    }

}