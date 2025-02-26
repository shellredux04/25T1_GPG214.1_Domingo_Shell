using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextFiles : MonoBehaviour
{
    public string fileName = "PlayerSaveData.txt";
    public string textFileContent;

    [SerializeField] private HealthStats healthStats;
    [SerializeField] private RespawnLocation respawnLocation;
    [SerializeField] private PowerUpStatus powerUpStatus;

    private void Start()
    {
        // Load data from file at the start
        LoadData();
    }

    private void Update()
    {
        // Save Data
        if (Input.GetKeyUp(KeyCode.V))
        {
            SaveData();
        }

        // Load Data
        if (Input.GetKeyUp(KeyCode.L))
        {
            LoadData();
        }
    }

    void SaveData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Health: " + healthStats.playerHealth);
            writer.WriteLine("Respawn Location: " + respawnLocation.respawnPoint.x + "," + 
                                                      respawnLocation.respawnPoint.y + "," + 
                                                      respawnLocation.respawnPoint.z);
            writer.WriteLine("Power-up Active: " + powerUpStatus.hasPowerUp);
        }

        Debug.Log("Game data saved successfully.");
    }

    void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length < 2) continue;

                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "Health":
                        healthStats.playerHealth = float.Parse(value);
                        break;

                    case "Respawn Location":
                        string[] coords = value.Split(',');
                        if (coords.Length == 3)
                        {
                            float x = float.Parse(coords[0]);
                            float y = float.Parse(coords[1]);
                            float z = float.Parse(coords[2]);
                            respawnLocation.SetRespawnPoint(new Vector3(x, y, z));
                        }
                        break;

                    case "Power-up Active":
                        powerUpStatus.hasPowerUp = bool.Parse(value);
                        break;
                }
            }

            Debug.Log("Game data loaded successfully.");
        }
        else
        {
            Debug.Log("Save file not found.");
        }
    }
}
