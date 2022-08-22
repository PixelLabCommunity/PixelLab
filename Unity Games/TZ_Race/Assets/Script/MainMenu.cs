using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _bestTime;
    [Serializable]
    class SaveData
    {
        public float bestTime;
        public int numberAttepts;
    }
    
    public void  OnPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Rating()
    {
        
    }

    void BestTime(float time)
    {
        Destroy(_bestTime.gameObject);
        _bestTime.text = time.ToString("0.0000");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/ScoreTable.csv"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoreTable.csv", FileMode.Open);
            SaveData data = (SaveData)formatter.Deserialize(file);
            file.Close();
            BestTime(data.bestTime);
        }
    }
}
