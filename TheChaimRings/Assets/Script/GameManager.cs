using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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
