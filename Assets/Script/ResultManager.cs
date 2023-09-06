using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    [SerializeField, Header("累計スコア")] private TMP_Text _totalScoreUI;
    [SerializeField, Header("タイトルに戻る方法の表示")] private TMP_Text _returnTitle;
    [SerializeField, Header("点滅間隔")] private float _textFlashTime = 1.0f;

    private float _textFlashTimeCount = 0;      // _returnTitleを点滅させるための時間のカウント

    // プレイヤースクリプトからスコアの値を取得
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
            if(_returnTitle.enabled) _returnTitle.enabled = false;  // 表示中の場合非表示にする
            else _returnTitle.enabled = true;               // 非表示の場合表示する

            _textFlashTimeCount = 0;
        }

        _textFlashTimeCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }

    }


}
