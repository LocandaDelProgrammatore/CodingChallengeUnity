using Sirenix.OdinInspector;
using UnityEngine;

namespace TicTacToe {

	public class PlayerManager : MonoBehaviour {

		[SerializeField] Sprite playerSprite;
		public AiController aiController;

		public Sprite GetSprite() => playerSprite;
        
        
	}

}