using UnityEngine;
using UnityEngine.Events;

public class OffAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerOuit;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerOuit?.Invoke();
        }
    }
}
