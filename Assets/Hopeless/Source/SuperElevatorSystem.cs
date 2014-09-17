using UnityEngine;
using System.Collections;

public class SuperElevatorSystem : MonoBehaviour {
	
	protected bool down = false;
	protected bool moving = false;
	public vp_MovingPlatform Platform = null;
	public AudioClip SoundOpenDoors = null;
	public AudioClip SoundCloseDoors = null;
	protected AudioSource m_Audio = null;
	public GameObject DoorFence = null;
	public GameObject OutsideDoorTop = null;
	public GameObject OutsideDoorBot = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator ToggleDoors () {
		m_Audio = audio;
		Debug.Log ("Toggling doors");
		if ((moving == false) & (down)) {
			Debug.Log ("Going UP");
			moving = true;
			// play the start sound, if any
			if (SoundCloseDoors != null)
					m_Audio.PlayOneShot (SoundCloseDoors);
			DoorFence.animation.Play ("close");
			OutsideDoorBot.transform.Find ("Door_Bot").animation.Play ("bot_close");
			OutsideDoorBot.transform.Find ("Door_Top").animation.Play ("top_close");
			yield return new WaitForSeconds (2);
			Platform.SendMessage ("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds (54); // 17 para 0.01 de velocidad. 54 para 0.002
			IsUp ();
		} else if ((moving == false) & (down == false)) {
			Debug.Log ("Going DOWN");
			moving = true;
			if (SoundCloseDoors != null)
					m_Audio.PlayOneShot (SoundCloseDoors);
			DoorFence.animation.Play ("close");
			OutsideDoorTop.transform.Find ("Door_Top").animation.Play ("top_close");
			OutsideDoorTop.transform.Find ("Door_Bot").animation.Play ("bot_close");
			yield return new WaitForSeconds (2);
			Platform.SendMessage ("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds (54); // 17 para 0.01 de velocidad. 54 para 0.002
			IsDown ();
		} else {
			Debug.Log ("Error");
		}
	}
	
	void IsUp () {
		down = false;
		moving = false;
		if (SoundCloseDoors != null)
			m_Audio.PlayOneShot(SoundOpenDoors);
		DoorFence.animation.Play("open");
		OutsideDoorTop.transform.Find ("Door_Top").animation.Play("top_open");
		OutsideDoorTop.transform.Find ("Door_Bot").animation.Play("bot_open");
	}
	
	void IsDown () {
		down = true;
		moving = false;
		if (SoundCloseDoors != null)
			m_Audio.PlayOneShot(SoundOpenDoors);
		DoorFence.animation.Play ("open");
		OutsideDoorBot.transform.Find ("Door_Bot").animation.Play ("bot_open");
		OutsideDoorBot.transform.Find ("Door_Top").animation.Play ("top_open");
	}
	
	void CallDown (){
		Debug.Log ("Llamada Down");
		if ((moving == false) & (down == false)) {
			Debug.Log ("Go Down");
			StartCoroutine(ToggleDoors ());
		}
	}
	
	void CallUp (){
		Debug.Log ("Llamada Up");
		if ((moving == false) & (down == true)) {
			Debug.Log ("Go Up");
			StartCoroutine(ToggleDoors ());
		}
	}
}
