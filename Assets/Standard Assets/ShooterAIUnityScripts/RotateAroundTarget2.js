//rotate with target
//!!SCRIPT HAS TO BE IN "STANDARD ASSESTS" FOLDER FOR THE NEWTWORK MANAGER TO SEE IT


var target : GameObject;
var rotSpeed = 1.0;
var canRotate : boolean;

function Update () 
{
if(canRotate == true)
{
    var dir = target.transform.forward; // get camera forward vector...
    
    dir.y = 0; // but keep only the horizontal direction
    
    var rot = Quaternion.LookRotation(dir); // now get the desired rotation
    
    transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);

	//transform.rotation.y = target.transform.rotation.y;

	
    }

}