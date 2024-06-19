using UnityEngine;
using Cinemachine;

namespace StarterAssets
{
    public class Change_FPScamera : MonoBehaviour
    {
        // �o�[�`�����J�����ꗗ
        [SerializeField] private CinemachineVirtualCamera[] _virtualCameraList;

        // ��I�����̃o�[�`�����J�����̗D��x
        [SerializeField] private int _unselectedPriority = 0;

        // �I�����̃o�[�`�����J�����̗D��x
        [SerializeField] private int _selectedPriority = 10;

        // �I�𒆂̃o�[�`�����J�����̃C���f�b�N�X
        private int _currentCamera = 0;

        // �v���C���[�̓��͂��擾���邽�߂̕ϐ�
        private StarterAssetsInputs _input;

        // �o�[�`�����J�����̗D��x������
        private void Awake()
        {
            // �o�[�`�����J�������ݒ肳��Ă��Ȃ���΁A�������Ȃ�
            if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
                return;

            // �o�[�`�����J�����̗D��x��������
            for (var i = 0; i < _virtualCameraList.Length; ++i)
            {
                _virtualCameraList[i].Priority =
                    (i == _currentCamera ? _selectedPriority : _unselectedPriority);
            }

            // �v���C���[�̓��̓R���|�[�l���g���擾
            _input = GetComponent<StarterAssetsInputs>();
        }

        // �t���[���X�V
        private void Update()
        {
            // �o�[�`�����J�������ݒ肳��Ă��Ȃ���΁A�������Ȃ�
            if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
                return;

            // �v���C���[�̈ړ���X�v�����g�̏�Ԃ��`�F�b�N
            if (_input.move != Vector2.zero || _input.sprint)
            {
                // ��ڂ̃J�����ɐ؂�ւ���
                SwitchToCamera(1);
            }
            else
            {
                // ��ڂ̃J�����ɖ߂�
                SwitchToCamera(0);
            }
        }

        // �J������؂�ւ��郁�\�b�h
        private void SwitchToCamera(int cameraIndex)
        {
            if (cameraIndex >= _virtualCameraList.Length)
                return;

            // �ȑO�̃o�[�`�����J�������I��
            _virtualCameraList[_currentCamera].Priority = _unselectedPriority;

            // ���̃o�[�`�����J������I��
            _currentCamera = cameraIndex;
            _virtualCameraList[_currentCamera].Priority = _selectedPriority;
        }
    }
}
