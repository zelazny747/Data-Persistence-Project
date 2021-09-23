using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManagerMenu : MonoBehaviour
{

    public static MainManagerMenu instance;

    public string playerName;
    public int playerScore;

    public string higherScorePlayerName;
    public int higherPlayerScore;



    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerInfo();
    }

    [System.Serializable]
    class PlayerInfo
    {
        public string playerName;
        public int playerScore;
        public string higherScorePlayerName;
        public int higherPlayerScore;
    }

    public void SavePlayerInfo()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.playerName = playerName;
        playerInfo.playerScore = playerScore;
        playerInfo.higherScorePlayerName = higherScorePlayerName;
        playerInfo.higherPlayerScore = higherPlayerScore;

        string json = JsonUtility.ToJson(playerInfo);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerInfo playerInfo = JsonUtility.FromJson<PlayerInfo>(json);

            playerName = playerInfo.playerName;
            playerScore = playerInfo.playerScore;
            higherScorePlayerName = playerInfo.higherScorePlayerName;
            higherPlayerScore = playerInfo.higherPlayerScore;
        }
    }

}
