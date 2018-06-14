using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Tiro : MonoBehaviour {

	/*Normalized: método utilizado para fixar a velocidade máxima de algo em 1.0f*, no caso,
	 * ele limita a velocidade da nossa bala.
		:)*/

	//Rigidbodys da bala(Objeto) e do gancho(Ponto de partida).
	public Rigidbody2D rb;
	public Rigidbody2D gancho;

	//Bala seguinte.
	public GameObject proxBala;

	//Boleano para checar se o botão foi pressionado E solto.
	private bool apertou = false;

	//Tempo para a Bala sair do gancho/ Distância da puxada.
	public float tSoltar = .15f;
	public float pDistancia = 2f;

	void Update() {

		//Se Apertou...
		if (apertou) {
			
			//Coloca um valor a uma variavel mouse, que será associado a posição do mouse com relação à camera principal.
			Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			//SE a distância do mouse com o gancho for maior do que a Distância da puxada...
			if (Vector3.Distance (mouse, gancho.position) > pDistancia) {

				/*A posição do objeto será igual a posição do gancho + (variável mouse - a posição do gancho)
					.normalizado * Distância da puxada.*/
				rb.position = gancho.position + (mouse - gancho.position).normalized * pDistancia;

				//Senão, a posição da bala é a posição do mouse.
			} else {
				rb.position = mouse;
			}
		}
	}
	//Quando o botão do mouse for pressionado...
	void OnMouseDown() {
		
		/* Apertou será verdadeiro,
		 * o corpo estará livre de colisões e outros efeitos da física.
			Lembrando que, o botão foi pressionado, mas não solto.*/
		apertou = true;
		rb.isKinematic = true;
	}
	//Quando o botão do mouse for solto...
	void OnMouseUp() {
		
		//Apertou voltará a ser falso,
		//o corpo irá obedecer as leis da física novamente.
		apertou = false;
		rb.isKinematic = false;

		//Chama a função Soltar.
		StartCoroutine(Soltar ());
	}

	//Soltando a bala.
	IEnumerator Soltar() {

		//Espera um tempo para soltar a bala.
		yield return new WaitForSeconds (tSoltar);

		//Solta a corda, liberando a Bala,
		//desativando-a logo em seguida, para o jogador não utiliza-la novamente.
		GetComponent<SpringJoint2D> ().enabled = false;
		this.enabled = false;

		//Espere por 2segundos...
		yield return new WaitForSeconds (2f);

		//Se a proxima bala for diferente de nulo....
		if(proxBala != null){

			//Ativa a proxima bala
			proxBala.SetActive(true);
		}else{
			/*Senão, espera por 5 seg(Para caso a última bala atinga algum alvo),
			 * e então dá game over.*/
			yield return new WaitForSeconds (5f);
			SceneManager.LoadScene ("GameOver"); 
		}
	}
}
