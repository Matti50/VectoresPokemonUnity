using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _lerpSpeed = 10f;
    
    [SerializeField]
    private Transform _playerPosition;

    [SerializeField]
    private float _minimumDistance = 2f;

    // Update is called once per frame
    void Update()
    {
        var playerRefDistance = _playerPosition.position - transform.position;
        var distanceToPlayer = playerRefDistance.magnitude;
        var playerDirection = playerRefDistance.normalized;
        var targetPosition = transform.position + playerDirection * _speed * Time.deltaTime;

        if(distanceToPlayer > _minimumDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed * Time.deltaTime);
        }
    }
}
