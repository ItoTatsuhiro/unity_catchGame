using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    [SerializeField, Header("�݌v�X�R�A")] private TMP_Text _totalScoreUI;
    [SerializeField, Header("�^�C�g���ɖ߂���@�̕\��")] private TMP_Text _returnTitle;
    [SerializeField, Header("�_�ŊԊu")] private float _textFlashTime = 1.0f;

    private float _textFlashTimeCount = 0;      // _returnTitle��_�ł����邽�߂̎��Ԃ̃J�E���g

    // �v���C���[�X�N���v�g����X�R�A�̒l���擾
    int _totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        _totalScore = PlayerPrefs.GetInt("Score");
        _totalScoreUI.text = _totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(_textFlashTimeCount >= _textFlashTime)
        {
            if(_returnTitle.enabled) _returnTitle.enabled = false;  // �\�����̏ꍇ��\���ɂ���
            else _returnTitle.enabled = true;               // ��\���̏ꍇ�\������

            _textFlashTimeCount = 0;
        }

        _textFlashTimeCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }

    }


}
