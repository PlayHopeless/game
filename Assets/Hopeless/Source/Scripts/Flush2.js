#pragma strict

var flushClip:AudioClip;
var isFlush = false;

function OnTriggerEnter(o:Collider){
	Debug.Log("The trigger fired enter");
	isFlush = true;
}

function OnTriggerExit(o:Collider){
	Debug.Log("The trigger fired");
	
		if(isFlush == true){
			playFlush();
		}	
}

	function playFlush(){
		audio.PlayOneShot(flushClip);
		isFlush = false;
}