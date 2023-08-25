using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Header("�J�n�O�J�E���g")] private float _time_startCount = 3f;
    [SerializeField, Header("�J�n�O�J�E���g�\��")] private TMP_Text _timeUI_startCount;

    [SerializeField, Header("��������")] private float _time_count = 180f;
    [SerializeField, Header("���Ԃ�\������UI")] private TMP_Text _timeUI;

    private bool _start = false;
    private bool _end = false;

    [SerializeField, Header("�I������{�^��")] private GameObject _endButton;

    [SerializeField, Header("�X�R�A��\������UI�F�v���C��")] private TMP_Text _scoreUI_play;
    [SerializeField, Header("�X�R�A��\������UI�F�I����")] private TMP_Text _scoreUI_end;

    [SerializeField, Header("�X�|�i�[")] private GameObject _spawner;

    private void Start()
    {
        _endButton.SetActive(false);    // �I������{�^�����\���ɂ���

        _spawner.SetActive(false);      // �X�|�i�[���\���ɂ���

        _scoreUI_play.enabled = true;   // �v���C���̃X�R�AUI��\��
        _scoreUI_end.enabled = false;   // �I�����̃X�R�AUI���\��
    }

    // Update is called once per frame
    void Update()
    {
        _timeUI.text = _time_count.ToString("f1") + "�b";

        if(!_start)
        {
            _timeUI_startCount.text = _time_startCount.ToString("f0");

            _time_startCount -= Time.deltaTime;

            if(_time_startCount < 0)
            {
                _timeUI_startCount.text = "";
                _start = true;
                _spawner.SetActive(true);      // �X�|�i�[��\������

            }

            return;
        }
        else if(_start && _time_count > 0)
        {
            _time_count -= Time.deltaTime;

            if (_time_count < 0)
            {
                _end = true;        // �I���̃t���O��true�ɂ���

                _scoreUI_play.enabled = false;   // �v���C���̃X�R�AUI���\��
                _scoreUI_end.enabled = true;   // �I�����̃X�R�AUI��\��

            }
        }

        if (_end)
        {
            _endButton.SetActive(true);     // �I������{�^����\������
            _spawner.SetActive(false);      // �X�|�i�[���\���ɂ���
        }



    }
}
