using UnityEngine;

[RequireComponent(typeof(Transform))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            _transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.A))
            _transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }
}
