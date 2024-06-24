using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int userMoney;
    private Dictionary<MiniGameType, int> gameHighScore = new Dictionary<MiniGameType, int>();

        // 테스트용 체크마크들
    [Header("Test Settings")]
    public bool saveTest;
    public bool loadTest;

    void Start()
    {
        // path를 찾은 다음에 뭔갈하는 게 좋을 듯..

        gameHighScore.Add(MiniGameType.Test, 0);
        gameHighScore.Add(MiniGameType.RopeJump, 0);
        gameHighScore.Add(MiniGameType.HighJump, 0);
        gameHighScore.Add(MiniGameType.GoGoRun, 0);
        gameHighScore.Add(MiniGameType.SwimSwim, 0);


            // 테스트
        if (saveTest) Save();
        if (loadTest) Load();
    }

    public void Save()
    {
        Debug.Log("저장 시도");

        FileStream saveStream = new FileStream(Application.dataPath + "/SaveFile/minigameHighScore.json", FileMode.OpenOrCreate);

        string jsonSaveData = JsonConvert.SerializeObject(gameHighScore);

        Debug.Log(jsonSaveData);

        byte[] saveData = Encoding.UTF8.GetBytes(jsonSaveData);

        saveStream.Write(saveData, 0, saveData.Length);
        saveStream.Close();

        //Debug.Log("저장 완료!");
    }

    public void Load()
    {
        //Debug.Log("불러오기 시도");

        string filepath = Application.dataPath + "/SaveFile/minigameHighScore.json";
        if (File.Exists(filepath))
        {
            FileStream loadStream = new FileStream(filepath, FileMode.OpenOrCreate);
            byte[] loadData = new byte[loadStream.Length];
            loadStream.Read(loadData, 0, loadData.Length);
            loadStream.Close();
            string jsonLoadData = Encoding.UTF8.GetString(loadData);

            gameHighScore = JsonConvert.DeserializeObject<Dictionary<MiniGameType, int>>(jsonLoadData);

            /* // 표시용
            foreach (var data in gameHighScore)
            {
                Debug.Log($"{data.Key}, {data.Value}");
            }
            */
        }
    }

    public int GiveHighScore(MiniGameType type)
    {
        return gameHighScore[type];
    }
    
    public int GiveTotalScore()
    {
        int totalScore = 0;
        foreach (int i in gameHighScore.Values)
        {
            totalScore += i;
        }
        return totalScore;
    }

    public bool RenewalHighScore(int curScore, MiniGameType gameType)
    {
        if (gameHighScore.ContainsKey(gameType))
        {
            if (curScore > gameHighScore[gameType])
            {
                gameHighScore[gameType] = curScore;
                Save(); // 갱신될 때마다 세이브할 것
                return true;
            }
        }
        else
        {
            Debug.Log("없는 게임 타입입니다.");
        }
        return false;
    }
}