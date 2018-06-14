using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	/*Referência ao efeito de morte,
	 * vida do inimigo*/
	public GameObject efeito;
	public float vida = 4f;

	//Quantidade de inimigos vivos.
	public static int inimigosVivos = 0;

	void Start() {

		//Adiciona a quantidade de inimigos vivos.
		inimigosVivos++;
	}

	//Quando se colidir com algo...
	void OnCollisionEnter2D(Collision2D col) {

		//Se a magnitude da velocidade for maior que sua vida...
		if (col.relativeVelocity.magnitude > vida) {

			/*Aumenta a pontuação,
			 * inimigo morre*/
			Score.pontuação += 5;
			Morreu ();
		}
	}

	//Precisa comentar???
	void Morreu(){

		//Instancia o efeito de morte na posição do inimigo.
		Instantiate (efeito, transform.position, Quaternion.identity);

		//Decrescenta a quantidade de inimigos.
		inimigosVivos--;

		//Se todos os inimigos morrerem...
		if (inimigosVivos <= 0) {

			//Passa para a próxima cena.
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);			
		}
		//Destroi o inimigo.
		Destroy (gameObject);
	}
}
