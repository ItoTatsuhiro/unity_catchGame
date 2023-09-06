using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Header("開始前カウント")] private float _time_startCount = 3f;
    [SerializeField, Header("開始前カウント表示")] private TMP_Text _timeUI_startCount;

    private float _secCount = 0;     // 1秒をカウントする用

    [SerializeField, Header("制限時間")] private float _time_count = 180f;
    [SerializeField, Header("時間を表示するUI")] private TMP_Text _timeUI;



    private bool _start = false;
    private bool _end = false;

    [SerializeField, Header("終了するボタン")] private GameObject _endButton;

    [SerializeField, Header("スコアを表示するUI：プレイ中")] private TMP_Text _scoreUI_play;
    [SerializeField, Header("終了時の表示")] private TMP_Text _finishText;

    [SerializeField, Header("スポナー")] private GameObject _spawner;

    private void Start()
    {
        //_time_startCount += 1f;

        _endButton.SetActive(false);    // 終了するボタンを非表示にする

        _spawner.SetActive(false);      // スポナーを非表示にする

        _scoreUI_play.enabled = true;   // プレイ中のスコアUIを表示
        _finishText.enabled = false;   // 終了時のスコアUIを非表示
    }

    // Update is called once per frame
    void Update()
    {
        _timeUI.text = _time_count.ToString("f1") + "秒";

        if(!_start)
        {
            if(_secCount > 1)
            {
                --_time_startCount;
                _secCount = 0;
            }

            _timeUI_startCount.text = _time_startCount.ToString("f0");

            _secCount += Time.deltaTime;

            if(_time_startCount == 0)
            {
                _timeUI_startCount.text = "Start!";
                _spawner.SetActive(true);      // スポナーを表示する
            }

            if(_time_startCount < 0)
            {
                _timeUI_startCount.text = "";
                _start = true;
                //_spawner.SetActive(true);      // スポナーを表示する

            }

            return;
        }
        else if(_start && _time_count > 0)
        {
            _time_count -= Time.deltaTime;

            if (_time_count < 0)
            {
                _end = true;        // 終了のフラグをtrueにする

                //_scoreUI_play.enabled = false;   // プレイ中のスコアUIを非表示
                _finishText.enabled = true;   // 終了時の表示を表示

            }
        }

        if (_end)
        {
            _endButton.SetActive(true);     // 終了するボタンを表示する
            _spawner.SetActive(false);      // スポナーを非表示にする
        }



    }
}
