using UnityEngine;
using UnityEngine.Events;

public class OnAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerEnter?.Invoke();
        }
    }
}
