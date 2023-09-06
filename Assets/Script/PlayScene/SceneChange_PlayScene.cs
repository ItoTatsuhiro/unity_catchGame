using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange_PlayScene : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    public void changeButton_PlayScene()
    {
        PlayerPrefs.SetInt("Score", _player._score);
        SceneManager.LoadScene("ResultScene");
    }

}
