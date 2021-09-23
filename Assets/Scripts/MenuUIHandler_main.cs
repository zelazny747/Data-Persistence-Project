using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler_main : MonoBehaviour
{

    public void Back()
    {
        MainManagerMenu.instance.SavePlayerInfo();
        SceneManager.LoadScene(0);
    }

}
