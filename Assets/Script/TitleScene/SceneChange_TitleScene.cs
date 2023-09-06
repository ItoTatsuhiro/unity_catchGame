using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange_TitleScene : MonoBehaviour
{

    [SerializeField, Header("���̃V�[���Ɉڂ�L�[�̕\��")] private TMP_Text _startKeyText;
    [SerializeField, Header("�_�ŊԊu")] private float _textFlashTime = 1.0f;

    private float _textFlashTimeCount = 1.0f;

    private void Update()
    {
        if (_textFlashTimeCount >= _textFlashTime)
        {
            if (_startKeyText.enabled) _startKeyText.enabled = false;  // �\�����̏ꍇ��\���ɂ���
            else _startKeyText.enabled = true;               // ��\���̏ꍇ�\������

            _textFlashTimeCount = 0;
        }

        _textFlashTimeCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }

    }

}
