using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _playerPosition;   
    [SerializeField] Vector3 _followRange;
    void Start()
    {
        _followRange.x = Random.Range(-10, 10);
        _followRange.y = Random.Range(-10, 10);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        followPlayer(_playerPosition);
    }
    
    void followPlayer(Transform playerPosition)
    {
        if(_playerPosition != null)
        {
            Vector3 _position = new Vector3(_followRange.x, _followRange.y,_playerPosition.position.z + _followRange.z);
            transform.position = _position;
        }   
    }
}
