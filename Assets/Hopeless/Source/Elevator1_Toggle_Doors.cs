using UnityEngine;
using System.Collections;

public class Elevator1_Toggle_Doors : MonoBehaviour {

	protected bool down = true;
	protected bool moving = false;
	public vp_MovingPlatform Platform = null;
	public AudioClip SoundOpenDoors = null;
	public AudioClip SoundCloseDoors = null;
	protected AudioSource m_Audio = null;

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
			moving = true;
			// play the start sound, if any
			if (SoundCloseDoors != null)
				m_Audio.PlayOneShot(SoundCloseDoors);
			GameObject.Find ("DoorElevator1_down").animation.Play ("close");
			GameObject.Find ("DoorElevator1_inside_down").animation.Play ("close");
			yield return new WaitForSeconds(2);
			Platform.SendMessage("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds(3);
			IsUp ();
		} else if ((moving == false) & (down == false)) {
			moving = true;
			if (SoundCloseDoors != null)
				m_Audio.PlayOneShot(SoundCloseDoors);
			GameObject.Find("DoorElevator1_up").animation.Play("close");
			GameObject.Find("DoorElevator1_inside_up").animation.Play("close");
			yield return new WaitForSeconds(2);
			Platform.SendMessage("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds(3);
			IsDown ();
		}
	}

	void IsUp () {
		down = false;
		moving = false;
		if (SoundCloseDoors != null)
			m_Audio.PlayOneShot(SoundOpenDoors);
		GameObject.Find("DoorElevator1_up").animation.Play("open");
		GameObject.Find("DoorElevator1_inside_up").animation.Play("open");
	}

	void IsDown () {
		down = true;
		moving = false;
		if (SoundCloseDoors != null)
			m_Audio.PlayOneShot(SoundOpenDoors);
		GameObject.Find ("DoorElevator1_down").animation.Play ("open");
		GameObject.Find ("DoorElevator1_inside_down").animation.Play ("open");
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
