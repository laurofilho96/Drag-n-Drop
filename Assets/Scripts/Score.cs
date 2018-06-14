using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int pontuação = 0;
	Text score;

	void Start() {
		
		score = GetComponent<Text> ();
	}

	void Update () {

		score.text = "score: " + pontuação;
	}
}

/*Script de pontuação simples...
	Ele referencia o texto em que será posto como score e determina um valor de 0.*/