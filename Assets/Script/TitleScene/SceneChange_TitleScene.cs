using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange_TitleScene : MonoBehaviour
{


    public void changeButton_PlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
