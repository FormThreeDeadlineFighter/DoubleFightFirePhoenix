using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    public Vector3 followPlayer(Transform playerPosition, Vector3 followRange)
    {
        Vector3 playerDir = new Vector3(0,0,playerPosition.position.z);     
        Vector3 _position = followRange + playerDir;
        return _position;
    }
}
