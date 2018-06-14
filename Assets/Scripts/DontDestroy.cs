using System;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroy : MonoBehaviour {

	//Não destruir o objeto após passar as cenas.

	public static DontDestroy instancia;

	void Awake(){

		if (instancia == null) {
			instancia = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
	}
}
