using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Impiccato {

	[CreateAssetMenu(menuName = "Impiccato/WordDatabase",fileName = "WordDatabase")]
	public class WordDatabase : ScriptableObject {
		public List<string> words = new List<string>();

		public string GetWord() {
			return words[Random.Range(0, words.Count)];
		}


		[Button]
		public void AddWords(string path) {
			
			var fileData = System.IO.File.ReadAllText(path);
			var lines  = fileData.Split("\n"[0]);
			foreach (var line in lines) {
				words.Add(line);
			}
		}
	}

}