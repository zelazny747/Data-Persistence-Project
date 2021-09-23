using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField playerName;
    public TMP_Text bestScoreText;


    public void NewPlayerNameEntered()
    {

        MainManagerMenu.instance.playerName = playerName.text;
    }

    // Start is called before the first frame update
    void Start()
    {

        playerName.text = MainManagerMenu.instance.playerName;

        bestScoreText.text = $"Best Score: {MainManagerMenu.instance.higherScorePlayerName} {MainManagerMenu.instance.higherPlayerScore}"; 
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManagerMenu.instance.SavePlayerInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit():
#endif

    }


}
