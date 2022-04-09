using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _initialSpeed = 5f;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _speedIncrease = 1.5f;

    [SerializeField]
    private float _rotationSpeed = 300f;

    void Start()
    {
        _speed = _initialSpeed;
    }

    void Update()
    {
        var directionY = Input.GetAxis("Vertical");
        var directionX = Input.GetAxis("Horizontal");

        var direction = new Vector3(directionX,0f, directionY);

        var mouseX = Input.GetAxis("Mouse X");

        Move(direction);
        Rotate(mouseX); // needs to be adjusted
    }

    private void Move(Vector3 direction)
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= _speedIncrease;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
        }
        var newDirection = direction.normalized * _speed * Time.deltaTime;
        transform.Translate(newDirection , Space.Self);
    }

    private void Rotate(float direction)
    {
        transform.Rotate(new Vector3(0f, direction, 0f) * _rotationSpeed * Time.deltaTime, Space.Self);
    }
}
