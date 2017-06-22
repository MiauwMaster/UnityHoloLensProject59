#pragma strict


function Update()
{
    //set the position of the target for the enemy
    transform.localPosition.y = (Camera.main.transform.position.y * -1);
}
