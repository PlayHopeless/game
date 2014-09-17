//with this script you can enable/disable ragdoll

var boneParent : GameObject; //the parent object that contains all the bones
var excludeExternalModels : GameObject[];
var useAutoRootObject = true;

	
function Start()
{		
DisableRagdoll();
}







function DisableRagdoll() {

//boneParent.SetActive(false);
/*
   for (var models : GameObject in excludeExternalModels){
        models.SetActive(true);
    }
*/

    // Get all transforms in Children, including our own
    var children = GetComponentsInChildren( Transform );
     
    // Iterate trough all child transforms and set the layer
    var child:Transform;
    for(child in children)
    {
    	if(child.rigidbody != null)
    	{
          child.rigidbody.isKinematic = true;
          child.rigidbody.Sleep();
          child.collider.enabled = false;
          child.collider.isTrigger = true;
    	}
    		
    }
    
    

	/*
    var rb:Rigidbody;
    for (rb in GetComponentsInChildren(Rigidbody)) {
    rb.isKinematic = true;
	rb.Sleep();
    }

var cl:CapsuleCollider;
    for (cl in GetComponentsInChildren(CapsuleCollider)) {
    cl.enabled = false;
	cl.isTrigger = true;
    }*/

}




function EnableRagdoll()
{
	boneParent.SetActive(true);
	
	var children = GetComponentsInChildren( Transform );
    // Iterate trough all child transforms and set the layer
    var child:Transform;
    for(child in children)
    {
    	if(child.rigidbody != null && child.collider != null)
    	{
          child.rigidbody.isKinematic = false;
          child.rigidbody.WakeUp();
          child.collider.enabled = true;
          child.collider.isTrigger = false;
    	}
    	
    }

/*
var rb:Rigidbody;
    for (rb in GetComponentsInChildren(Rigidbody)) {
    rb.isKinematic = false;
	rb.WakeUp();
    }

var cl:CapsuleCollider;
    for (cl in GetComponentsInChildren(CapsuleCollider)) {
    cl.enabled = true;
	cl.isTrigger = false;
    }*/

}