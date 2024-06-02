using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        EventManager.Instance.playerEvent.AddListener(OnPlayerEvent);
    }

    void OnPlayerEvent(PlayerEventParams eventParams)
    {
        switch (eventParams.EventType)
        {
            case PlayerEventParams.Type.TouchGate:
                Debug.Log("Player touched Gate Forward");
                // Gateタグオブジェクトに触れた時の処理
                HandleTouchGate();
                break;

        }
    }

    void HandleTouchGate()
    {
        // Gate Forwardに触れた時の処理をここに書く
        // 例えば、スコアを増やす、アイテムを獲得するなど
    }

}
