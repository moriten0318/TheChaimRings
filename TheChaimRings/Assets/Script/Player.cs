using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Settings")] // ここに見出しを追加
    public GameObject pathPrefab; // ステージのプレハブ
    private Rigidbody rb; // プレイヤーのリジッドボディ
    private Vector3 velocityDirection; // プレイヤーの速度ベクトル
    private float cooldownTime = 0.5f; // クールダウンタイム
    private float lastTriggeredTime; // 最後にトリガーが呼ばれた時刻

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastTriggeredTime = -cooldownTime; // ゲーム開始時にすぐにトリガーが可能になるように設定
    }

    void Update()
    {
        // プレイヤーの速度ベクトルを更新
        velocityDirection = rb.velocity.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckGate"))
        {
            // 一定時間内に再度トリガーされないようにする
            if (Time.time - lastTriggeredTime >= cooldownTime)
            {
                Transform gateParentTransform = other.gameObject.transform.parent;
                Debug.Log($"Parent Name: {gateParentTransform.name}, Position: {gateParentTransform.position}");
                CreatePath(gateParentTransform);
                lastTriggeredTime = Time.time; // トリガー時刻を更新
            }
        }
    }

    void CreatePath(Transform gateParentTransform)
    {
        // 親オブジェクトのZ座標に基づいてプレハブを生成する位置を決定
        Vector3 spawnPosition = gateParentTransform.position + new Vector3(0, 0, 22);

        // プレイヤーの進行方向に基づいてプレハブを生成
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