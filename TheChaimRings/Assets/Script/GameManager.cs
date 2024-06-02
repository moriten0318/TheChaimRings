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
                // Gate�^�O�I�u�W�F�N�g�ɐG�ꂽ���̏���
                HandleTouchGate();
                break;

        }
    }

    void HandleTouchGate()
    {
        // Gate Forward�ɐG�ꂽ���̏����������ɏ���
        // �Ⴆ�΁A�X�R�A�𑝂₷�A�A�C�e�����l������Ȃ�
    }

}
