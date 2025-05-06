using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    public Vector3 followPlayer(Transform origin, Transform playerPosition)
    {
        Vector3 playerDir = new Vector3(0,0,playerPosition.position.z);     
        Vector3 _newPosition = origin.position + playerDir;
        return _newPosition;
    }
}
