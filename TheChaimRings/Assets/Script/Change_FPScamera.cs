using UnityEngine;
using Cinemachine;

namespace StarterAssets
{
    public class Change_FPScamera : MonoBehaviour
    {
        // バーチャルカメラ一覧
        [SerializeField] private CinemachineVirtualCamera[] _virtualCameraList;

        // 非選択時のバーチャルカメラの優先度
        [SerializeField] private int _unselectedPriority = 0;

        // 選択時のバーチャルカメラの優先度
        [SerializeField] private int _selectedPriority = 10;

        // 選択中のバーチャルカメラのインデックス
        private int _currentCamera = 0;

        // プレイヤーの入力を取得するための変数
        private StarterAssetsInputs _input;

        // バーチャルカメラの優先度初期化
        private void Awake()
        {
            // バーチャルカメラが設定されていなければ、何もしない
            if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
                return;

            // バーチャルカメラの優先度を初期化
            for (var i = 0; i < _virtualCameraList.Length; ++i)
            {
                _virtualCameraList[i].Priority =
                    (i == _currentCamera ? _selectedPriority : _unselectedPriority);
            }

            // プレイヤーの入力コンポーネントを取得
            _input = GetComponent<StarterAssetsInputs>();
        }

        // フレーム更新
        private void Update()
        {
            // バーチャルカメラが設定されていなければ、何もしない
            if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
                return;

            // プレイヤーの移動やスプリントの状態をチェック
            if (_input.move != Vector2.zero || _input.sprint)
            {
                // 二つ目のカメラに切り替える
                SwitchToCamera(1);
            }
            else
            {
                // 一つ目のカメラに戻す
                SwitchToCamera(0);
            }
        }

        // カメラを切り替えるメソッド
        private void SwitchToCamera(int cameraIndex)
        {
            if (cameraIndex >= _virtualCameraList.Length)
                return;

            // 以前のバーチャルカメラを非選択
            _virtualCameraList[_currentCamera].Priority = _unselectedPriority;

            // 次のバーチャルカメラを選択
            _currentCamera = cameraIndex;
            _virtualCameraList[_currentCamera].Priority = _selectedPriority;
        }
    }
}
