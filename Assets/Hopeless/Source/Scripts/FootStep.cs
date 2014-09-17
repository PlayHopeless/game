using UnityEngine;
using System.Collections;

public class FootStep : MonoBehaviour {
	
	public AudioClip[] SonidoMetal;
	public AudioClip[] SonidoMadera;
	public AudioClip[] SonidoDefault;
	public AudioClip[] SonidoConcrete;
	public AudioClip[] SonidoTerreno;
	private CharacterController controller;
	private float delayTime;
	private float NextPlay;
	
	void PlayFootStepSound()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 10f) & Time.time > NextPlay)
		{
			NextPlay = delayTime + Time.time;
			delayTime = Random.Range(0.25f, 0.5f);
			switch (hit.collider.tag)
			{
			case "FootStep_Metal":
				audio.clip = SonidoMetal[Random.Range (0, SonidoMetal.Length)];
				audio.Play();
				break;
			case "FootStep_Wood":
				audio.clip = SonidoMadera[Random.Range(0, SonidoMadera.Length)];
				audio.Play ();
				break;
			case "FootStep_Default":
				audio.clip = SonidoDefault[Random.Range(0, SonidoDefault.Length)];
				audio.Play();
				break;
			case "FootStep_Concrete":
				audio.clip = SonidoConcrete[Random.Range(0, SonidoConcrete.Length)];
				audio.Play();
				break;
			default:
				audio.clip = SonidoTerreno[Random.Range (0, SonidoTerreno.Length)];
				audio.Play();
				break;
			}
		}
	}
	
	// Funcion start para inicializar el juego
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Funcion update para determinar frame por frame y mandar llamar objetos establecidos en el constructor
	void Update () 
	{
		if (controller.isGrounded & controller.velocity.magnitude > 0.5)
		{
			PlayFootStepSound();
		}
	}
}
