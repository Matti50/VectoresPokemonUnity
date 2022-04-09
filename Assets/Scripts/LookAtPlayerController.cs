using UnityEngine;

public class LookAtPlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _rotationSpeed = 100f;

    void Update()
    {
        //a partir de este calculo podemos sacar la distancia (magnitud) y la dirección (vector resultante normalizado).
        var playerRefDistance = _playerTransform.position - transform.position;

        var faceToPlayerRotation = Quaternion.LookRotation(playerRefDistance);
        transform.rotation = Quaternion.Lerp(transform.rotation, faceToPlayerRotation, _rotationSpeed * Time.deltaTime);
    }
}
