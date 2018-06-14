using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Comentários no final.
public class Menu : MonoBehaviour {

	public void StartGame(){
		
		SceneManager.LoadScene ("Mainlvl");
		Score.pontuação = 0;
	}

	public void VoltarAoMenu(){
		SceneManager.LoadScene ("Menu");
	}
		
	public void Quit(){
		
		Debug.Log ("Saiu do Jogo");
		Application.Quit ();
	}
}
/*Esse script serve só para controlar as cenas...
 * 
	Pode ser usado em qualquer tela fora do jogo em si, ou seja
	Utilizar para menus, telas de créditos, pauses, telas de game over e de vitória e outras do tipo.
	Lembrando que, toda vez que o jogador passa para a tela principal, a pontuação zera, assim
	evita que ele acumule pontos o tempo todo.*/
