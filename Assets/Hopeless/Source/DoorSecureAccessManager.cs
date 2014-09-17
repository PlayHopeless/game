using UnityEngine;
using System.Collections;

public class DoorSecureAccessManager : MonoBehaviour {

	public bool door_open = false;
	public GameObject door = null;
	protected bool moving = false;
	protected AudioSource m_Audio = null;
	public AudioClip SoundOpenDoors = null;
	public AudioClip SoundCloseDoors = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ToggleDoor () {
		m_Audio = audio;
		Debug.Log ("Toggling door");
		if ((moving == false) & (door_open)) {
			Debug.Log ("closing");
			moving = true;
			// play the start sound, if any
			if (SoundCloseDoors != null)
				m_Audio.PlayOneShot(SoundCloseDoors);
			door.transform.Find ("Door_Top").animation.Play ("top_close");
			door.transform.Find ("Door_Bot").animation.Play ("bot_close");
			yield return new WaitForSeconds(2);
			IsClose();
		} else if ((moving == false) & (door_open == false)) {
			Debug.Log ("opening");
			moving = true;
			// play the start sound, if any
			if (SoundCloseDoors != null)
				m_Audio.PlayOneShot(SoundCloseDoors);
			door.transform.Find ("Door_Top").animation.Play ("top_open");
			door.transform.Find ("Door_Bot").animation.Play ("bot_open");
			yield return new WaitForSeconds(2);
			IsOpen();
		}
	}

	void IsClose () {
		door_open = false;
		moving = false;
	}

	void IsOpen () {
		door_open = true;
		moving = false;
	}
}
