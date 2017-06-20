#pragma strict


function Update()
{
    transform.localPosition.y = (Camera.main.transform.position.y * -1);
}
