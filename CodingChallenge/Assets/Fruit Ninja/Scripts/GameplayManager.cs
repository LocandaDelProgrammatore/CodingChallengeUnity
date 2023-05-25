using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FruitNinja {
    
    public class GameplayManager : MonoBehaviour {
        // Start is called before the first frame update
       public float globalTimer;
       public Action OnFinishGame;
       public Action<int> OnPointsUpdated;
       private bool isFinish;
       public int point;

       void Start() { }

        // Update is called once per frame
        void Update() {
	        if (!isFinish) {
		        globalTimer -= Time.deltaTime;
		        if (globalTimer <= 0) {
			        OnFinishGame?.Invoke();
			        isFinish = true;
		        }
	        }
        }

        public void UpdatePoint(int points) {
	        point += points;
	        OnPointsUpdated?.Invoke(point);
        }
        

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
