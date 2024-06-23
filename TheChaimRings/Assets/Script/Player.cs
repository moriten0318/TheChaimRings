using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Settings")] // �����Ɍ��o����ǉ�
    public GameObject pathPrefab; // �X�e�[�W�̃v���n�u
    private Rigidbody rb; // �v���C���[�̃��W�b�h�{�f�B
    private Vector3 velocityDirection; // �v���C���[�̑��x�x�N�g��
    private float cooldownTime = 0.5f; // �N�[���_�E���^�C��
    private float lastTriggeredTime; // �Ō�Ƀg���K�[���Ă΂ꂽ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastTriggeredTime = -cooldownTime; // �Q�[���J�n���ɂ����Ƀg���K�[���\�ɂȂ�悤�ɐݒ�
    }

    void Update()
    {
        // �v���C���[�̑��x�x�N�g�����X�V
        velocityDirection = rb.velocity.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckGate"))
        {
            // ��莞�ԓ��ɍēx�g���K�[����Ȃ��悤�ɂ���
            if (Time.time - lastTriggeredTime >= cooldownTime)
            {
                Transform gateParentTransform = other.gameObject.transform.parent;
                Debug.Log($"Parent Name: {gateParentTransform.name}, Position: {gateParentTransform.position}");
                CreatePath(gateParentTransform);
                lastTriggeredTime = Time.time; // �g���K�[�������X�V
            }
        }
    }

    void CreatePath(Transform gateParentTransform)
    {
        // �e�I�u�W�F�N�g��Z���W�Ɋ�Â��ăv���n�u�𐶐�����ʒu������
        Vector3 spawnPosition = gateParentTransform.position + new Vector3(0, 0, 22);

        // �v���C���[�̐i�s�����Ɋ�Â��ăv���n�u�𐶐�
        Instantiate(pathPrefab, spawnPosition, Quaternion.identity);
    }
}

public class PlayerEventParams
{
    public enum Type
    {
        TouchGate
    }

    public Type EventType { get; private set; }

    public PlayerEventParams(Type eventType)
    {
        EventType = eventType;
    }
}