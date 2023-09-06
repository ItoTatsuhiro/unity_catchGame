using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange_TitleScene : MonoBehaviour
{

    [SerializeField, Header("次のシーンに移るキーの表示")] private TMP_Text _startKeyText;
    [SerializeField, Header("点滅間隔")] private float _textFlashTime = 1.0f;

    private float _textFlashTimeCount = 1.0f;

    private void Update()
    {
        if (_textFlashTimeCount >= _textFlashTime)
        {
            if (_startKeyText.enabled) _startKeyText.enabled = false;  // 表示中の場合非表示にする
            else _startKeyText.enabled = true;               // 非表示の場合表示する

            _textFlashTimeCount = 0;
        }

        _textFlashTimeCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }

    }

}
