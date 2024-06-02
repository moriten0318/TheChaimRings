using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public UnityEvent<PlayerEventParams> playerEvent = new UnityEvent<PlayerEventParams>();

    public void TriggerPlayerEvent(PlayerEventParams eventParams)
    {
        playerEvent.Invoke(eventParams);
    }
}
