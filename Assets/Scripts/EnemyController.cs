using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyType _enemyType = EnemyType.LookingEnemy;

    private FollowPlayerController _movementController;
    private LookAtPlayerController _rotationController;

    void Awake()
    {
        _movementController = GetComponent<FollowPlayerController>();
        _rotationController = GetComponent<LookAtPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_enemyType)
        {
            case EnemyType.FollowingEnemy:
                SetControllers(true, false);
                break;
            case EnemyType.LookingEnemy:
                SetControllers(false, true);
                break;
            case EnemyType.LookingAndFollowingEnemy:
                SetControllers(true, true);
                break;
        }
    }

    private void SetControllers(bool enableMovement, bool enableRotation)
    {
        _movementController.enabled = enableMovement;
        _rotationController.enabled = enableRotation;
    }
}
