//this script lets the camera bob up and down, and it makes the camera the same position as its target


private var timer = 0.0; 
 var bobbingSpeed = 0.6; 
 var bobbingAmount = 0.2; 
 var midpoint = 2.0; 
public var playerHeight : Vector3;
public var target : GameObject; 
public var canHeadbob : boolean;


function Update () {


//avoid bugs
	

if(target != null)
{
//make the position the same as that of the target's
transform.position = target.transform.position+playerHeight;
	
}


if(canHeadbob)
{ 
    var waveslice = 0.0; 
    var horizontal = Input.GetAxis("Horizontal"); 
    var vertical = Input.GetAxis("Vertical"); 
    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
       timer = 0.0; 
    } 
    else { 
       waveslice = Mathf.Sin(timer); 
       timer = timer + bobbingSpeed; 
       if (timer > Mathf.PI * 2) { 
          timer = timer - (Mathf.PI * 2); 
       } 
    } 
    if (waveslice != 0) { 
       var translateChange = waveslice * bobbingAmount; 
       var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
       totalAxes = Mathf.Clamp (totalAxes, 0.0, 1.0); 
       translateChange = totalAxes * translateChange;
	 	

       
		transform.localPosition.y = translateChange + transform.position.y; 
    } 
    else { 
       transform.localPosition.y = transform.position.y; 
    }



 }
 }